using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE2A_WF_Lecturer
{
    public partial class PointDetailMsgBox : Form
    {
        private StudentDTO studentDTO;
        public string PracticalExamCode { get; set; }
        public string SubmitAPIUrl { get; set; }

        public PointDetailMsgBox(StudentDTO studentDTO)
        {
            InitializeComponent();
            this.studentDTO = studentDTO;
            DisplayResultMessage();
        }

        private void DisplayResultMessage()
        {
            try
            {
                if (studentDTO != null)
                {
                    // Set form title to student name
                    Text = studentDTO.StudentName;

                    // Update result to tree view
                    tvPointDetail.Nodes[0].Text = "No                   : " + studentDTO.NO;
                    tvPointDetail.Nodes[1].Text = "Student code         : " + studentDTO.StudentCode;
                    tvPointDetail.Nodes[2].Text = "Student name         : " + studentDTO.StudentName;
                    tvPointDetail.Nodes[3].Text = "Exam code            : " + studentDTO.ScriptCode;
                    tvPointDetail.Nodes[4].Text = "List questions       : ";
                    if (studentDTO.ListQuestions != null)
                    {
                        foreach (var item in studentDTO.ListQuestions)
                        {
                            //tvPointDetail.Nodes[4].Nodes.Add(item.Key + " : " + item.Value);
                            tvPointDetail.Nodes[4].Nodes.Add(formatResult(item.Key, item.Value));
                        }
                    }
                    tvPointDetail.Nodes[5].Text = "Result               : " + studentDTO.Result;
                    tvPointDetail.Nodes[6].Text = "Coding convention    : " + studentDTO.CodingConvention;
                    tvPointDetail.Nodes[7].Text = "Total point          : " + studentDTO.TotalPoint;
                    tvPointDetail.Nodes[8].Text = "Submitted time       : " + studentDTO.SubmitTime;
                    tvPointDetail.Nodes[9].Text = "Evaluated time       : " + studentDTO.EvaluateTime;
                    tvPointDetail.Nodes[10].Text = "Message              : " + studentDTO.ErrorMsg;
                }
            }
            catch(Exception ex)
            {
                Util.LogException("DisplayResultMessage", ex.Message);

            }
           
        }

        private string formatResult (string topic,string inputStr)
        {
            string result = "";
            result = string.Format("{0,-35} : {1,15}", topic, inputStr);
            return result;
        }

        private async void btnReEvaluate_Click(object sender, System.EventArgs e)
        {
            try
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Supported file formats|*.zip;*.rar|ZIP files|*.zip|RAR files|*.rar";
                    openFileDialog.Multiselect = false;
                    openFileDialog.RestoreDirectory = true;
                    if (openFileDialog.ShowDialog().Equals(DialogResult.OK))
                    {
                        // Get full zip file path
                        var filePath = openFileDialog.FileName;
                        var destinationPath = Path.Combine(Util.GetProjectDirectory() + Constant.RE_EVALUATE_FOLDER);
                        string safeFileName = openFileDialog.SafeFileName;
                        // Get zip file name without extension
                        var filename = Path.GetFileNameWithoutExtension(filePath);
                        if (filename.Equals(studentDTO.StudentCode))
                        {
                            string zipFileInRevaluateFol = Path.Combine(destinationPath, safeFileName);
                            File.Copy(filePath, zipFileInRevaluateFol, true);
                            string result = "";
                            string practicalExamType = GetPracticalExamType(PracticalExamCode);
                            if (practicalExamType == Constant.PRACTICAL_EXAM_JAVA_WEB)
                            {
                                result = await SendFileJavaWeb(zipFileInRevaluateFol);
                            }
                           else if (practicalExamType.Equals(Constant.PRACTICAL_EXAM_JAVA))
                            {
                                 result = await SendFile(zipFileInRevaluateFol, Constant.STUDENT_FOLDER_JAVA);
                            }
                              else if (practicalExamType.Equals(Constant.PRACTICAL_EXAM_C_SHARP))
                            {
                                result = await SendFile(zipFileInRevaluateFol,Constant.STUDENT_FOLDER_CSharp);
                            }
                            else if (practicalExamType.Equals(Constant.PRACTICAL_EXAM_C))
                            {
                                result = await SendFile(zipFileInRevaluateFol,Constant.STUDENT_FOLDER_C);
                            }
                            MessageBox.Show(result);
                        }
                        else
                        {
                            MessageBox.Show("File name must match with student code", "Error occurred");
                        }

                        //// Get script folder
                        //var scriptFolder = Path.Combine(destinationPath, filename);

                        //// Compare zip file name with practical exam code from api
                        //if (apiPracticalExamCode.Equals(filename))
                        //{
                        //    if (Directory.Exists(destinationPath))
                        //    {
                        //        Util.UnarchiveFile(filePath, destinationPath);
                        //        // LoadTemplateHistory();

                        //        CopyPracticalInfoToSubmissionFolder(scriptFolder);
                        //        // MessageBox.Show("Import success!", "Information");
                        //        var practicalExamCode = openFileDialog.SafeFileName.Split('.')[0];
                        //        ShowLecturerForm(practicalExamCode, Constant.PRACTICAL_STATUS[1]);
                        //    }
                        //    else
                        //    {
                        //        MessageBox.Show("Can not import script file!", "Error occurred");
                        //    }
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Script name does not match the exam code!", "Information");
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("Can not import script file!", "Error occurred");
            }
        }
        private async Task<string> SendFile(String fileName, string srcFolder)
        {
            string startupPath = Util.GetProjectDirectory();
            string destinationPath = startupPath + Constant.RE_EVALUATE_FOLDER;
            string workPath = destinationPath + Constant.WORK_FOLDER;
            //    //extract
            Util.UnarchiveFile(fileName, workPath);

            string srcCodePath = Path.Combine(destinationPath, srcFolder);

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            ZipFile.CreateFromDirectory(srcCodePath, fileName, CompressionLevel.NoCompression, true);
            var uri = new Uri(SubmitAPIUrl);
            string fileExtension = fileName.Substring(fileName.IndexOf('.'));
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var stream = File.ReadAllBytes(fileName);
                    MultipartFormDataContent form = new MultipartFormDataContent();
                    HttpContent content = new StreamContent(new FileStream(fileName, FileMode.Open));
                    content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "file",
                        FileName = studentDTO.StudentCode + fileExtension
                    };
                    form.Add(content, "file");
                    form.Add(new StringContent(studentDTO.StudentCode), "studentCode");
                    form.Add(new StringContent(studentDTO.ScriptCode), "scriptCode");
                    using (var message = await client.PostAsync(uri, form))
                    {
                        var result = await message.Content.ReadAsStringAsync();
                        //time.Stop();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Util.LogException("SendFileJavaWeb", ex.Message);

            }
            return "Error !";
        }

        private async Task<string> SendFileJavaWeb(string fileName)
        {

            string startupPath = Util.GetProjectDirectory();
            string destinationPath = startupPath + Constant.RE_EVALUATE_FOLDER;
            string webappPath = destinationPath + Constant.WEBAPP_FOLDER;
            string workPath = destinationPath + Constant.WORK_FOLDER;
            string workWebPagePath = destinationPath + Constant.WORK_WEBPAGE_PATH;
            string webPageZip = destinationPath + @"\" + studentDTO.StudentCode + "_WEB.zip";
            //    //extract
            Util.UnarchiveFile(fileName, workPath);
            //    //copy

            //    //Now Create all of the directories
            Util.Copy(workWebPagePath, webappPath);
            //    // Directory.Move(destinationPath, webappPath);
            //    // File.Copy()

            string srcCodePath = Path.Combine(destinationPath, Constant.STUDENT_FOLDER_JAVAWEB);

            if (File.Exists(webPageZip))
            {
                File.Delete(webPageZip);
            }
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            //    //       zipFile(webPagePath, true);
            ZipFile.CreateFromDirectory(webappPath, webPageZip, CompressionLevel.NoCompression, true);
            ZipFile.CreateFromDirectory(srcCodePath, fileName, CompressionLevel.NoCompression, true);
            var uri = new Uri(SubmitAPIUrl);
            string fileExtension = fileName.Substring(fileName.IndexOf('.'));
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var stream = File.ReadAllBytes(fileName);
                    MultipartFormDataContent form = new MultipartFormDataContent();
                    HttpContent content = new StreamContent(new FileStream(fileName, FileMode.Open));
                    content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "file",
                        FileName = studentDTO.StudentCode + fileExtension
                    };
                    HttpContent webContent = new StreamContent(new FileStream(webPageZip, FileMode.Open));
                    webContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "webFile",
                        FileName = studentDTO.StudentCode + "_WEB" + fileExtension
                    };
                    form.Add(content, "file");
                    form.Add(webContent, "webFile");
                    form.Add(new StringContent(studentDTO.StudentCode), "studentCode");
                    form.Add(new StringContent(studentDTO.ScriptCode), "scriptCode");
                    using (var message = await client.PostAsync(uri, form))
                    {
                        var result = await message.Content.ReadAsStringAsync();
                        //time.Stop();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Util.LogException("SendFileJavaWeb", ex.Message);

            }
            return "Error !";

        }
        private string GetPracticalExamType(string practicalExamCode)
        {
            try
            {
                if (practicalExamCode.ToUpper().Contains(Constant.PRACTICAL_EXAM_JAVA_WEB))
                {
                    return Constant.PRACTICAL_EXAM_JAVA_WEB;
                }
                else if (practicalExamCode.ToUpper().Contains(Constant.PRACTICAL_EXAM_JAVA))
                {
                    return Constant.PRACTICAL_EXAM_JAVA;
                }
                else if (practicalExamCode.ToUpper().Contains(Constant.PRACTICAL_EXAM_C_SHARP))
                {
                    return Constant.PRACTICAL_EXAM_C_SHARP;
                }
                else
                {
                    return Constant.PRACTICAL_EXAM_C;
                }
            }
            catch(Exception ex)
            {
                Util.LogException("GetPracticalExamType", ex.Message);

            }
            return null;
           
        }

        private void PointDetailMsgBox_Load(object sender, EventArgs e)
        {
            string workFol = Util.GetProjectDirectory() + Constant.RE_EVALUATE_FOLDER + Constant.WORK_FOLDER;
            string webappFol = Util.GetProjectDirectory() + Constant.RE_EVALUATE_FOLDER + Constant.WEBAPP_FOLDER;
            if (Directory.Exists(workFol) || Directory.Exists(webappFol))
            {
                Directory.Delete(workFol, true);
                Directory.Delete(webappFol, true);
            }
            Directory.CreateDirectory(workFol);
            Directory.CreateDirectory(webappFol);
        }

        private void btnSimilarity_Click(object sender, EventArgs e)
        {
            string url = Constant.DUPLICATED_LOCALHOST_DOMAIN + PracticalExamCode + @"/" + studentDTO.StudentCode;
            Util.OpenBrowser(url);
        }
    }

}
