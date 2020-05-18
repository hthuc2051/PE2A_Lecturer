using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE2A_WF_Lecturer
{
    public partial class ImportScriptForm : Form
    {

        private LecturerEnroll enrollForm;
        private int scriptFileCounter;
        public List<PracticalDTO> PracticalList { get; set; }
        private List<StudentDTO> StudentList = new List<StudentDTO>();
        public ImportScriptForm(LecturerEnroll enrollForm)
        {
            InitializeComponent();
            this.enrollForm = enrollForm;


            scriptFileCounter = 0;

            InitDgvScriptFilesStyle();
            //  LoadTemplateHistory();

        }

        //private void LoadTemplateHistory()
        //{
        //    var submissionFolderPath = Path.Combine(GetProjectDirectory() + Constant.SCRIPT_FILE_PATH);
        //    DirectoryInfo directoryInfo = new DirectoryInfo(submissionFolderPath);
        //    DirectoryInfo[] directories = directoryInfo.GetDirectories();

        //    if (directories.Length > 0)
        //    {
        //        scriptFileCounter = 0;
        //        dgvScriptFiles.Rows.Clear();
        //        for (int i = 0; i < directories.Length; i++)
        //        {
        //            scriptFileCounter++;
        //            dgvScriptFiles.Rows.Add(new string[] { scriptFileCounter.ToString(), directories[i].ToString() });
        //        }
        //    }
        //}

        private void LoadPractical()
        {
            try
            {
                if (PracticalList != null)
                {
                    if (PracticalList.Count > 0)
                    {
                        scriptFileCounter = 0;
                        dgvScriptFiles.Rows.Clear();
                        for (int i = 0; i < PracticalList.Count; i++)
                        {
                            scriptFileCounter++;
                            PracticalDTO dto = PracticalList[i];
                            string buttonText = "View";
                            if (dto.State.Equals(Constant.PRACTICAL_STATUS[1]))
                            {
                                buttonText = "Import";
                            }
                            dgvScriptFiles.Rows.Add( scriptFileCounter.ToString(), dto.Code, dto.SubjectCode, dto.Date, dto.State,buttonText );
                           
                        }
                       
                    }
                }
                else
                {
                    MessageBox.Show("Practical list is empty!");
                }
            }
            catch (Exception ex)
            {
                Util.LogException("LoadPractical", ex.Message);
            }
        }

        private void InitDgvScriptFilesStyle()
        {
            try
            {
                dgvScriptFiles.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvScriptFiles.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
                dgvScriptFiles.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                Util.LogException("InitDgvScriptFilesStyle", ex.Message);

            }

        }

        //private string GetProjectDirectory()
        //{
        //    /*
        //    * 
        //    * This block is for local test (IDE test)
        //    * 
        //    */

        //    var appDomainDir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
        //    var projectNameDir = Path.GetFullPath(Path.Combine(appDomainDir, @"..\.."));

        //    /*
        //     * 
        //     * This block is for release app
        //     * 
        //     */

        //    //var projectNameDir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

        //    return projectNameDir;
        //}

        private void ImportTemplate(string apiPracticalExamCode)
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

                        var destinationPath = Path.Combine(Util.ExecutablePath() + Constant.SCRIPT_FILE_PATH);
                        var submissionPath = Path.Combine(Util.ExecutablePath() + Constant.SUBMISSION_FOLDER_PATH); 
                        // Get zip file name without extension
                        var filename = Path.GetFileNameWithoutExtension(filePath);

                        // Get script folder
                        var scriptFolder = Path.Combine(destinationPath, filename);

                        // Compare zip file name with practical exam code from api
                        if (apiPracticalExamCode.Equals(filename))
                        {
                            if (Directory.Exists(destinationPath))
                            {
                                Util.UnarchiveFile(filePath, destinationPath);
                                // LoadTemplateHistory();

                                CopyPracticalInfoToSubmissionFolder(scriptFolder);
                                // MessageBox.Show("Import success!", "Information");
                                var practicalExamCode = openFileDialog.SafeFileName.Split('.')[0];
                                // Point the Submission Server Path
                                ShowLecturerForm(practicalExamCode, Constant.PRACTICAL_STATUS[1], submissionPath);
                            }
                            else
                            {
                                MessageBox.Show("Can not import script file!", "Error occurred");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Script name does not match the exam code!", "Information");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not import script file!", "Error occurred");
                Util.LogException("ImportTemplate", ex.Message);
            }
        }

        private void ShowLecturerForm(string practicalExamCode, string practicalStatus, string submissionServerPath)
        {
            try
            {
                Util.RunCmd(submissionServerPath, Constant.CMD_COMMAND_RUN_SUBMISSION_SERVER);
                GetListStudentFromCSV(practicalExamCode);
                LecturerForm lecturerForm = new LecturerForm();
                //AddData();
                lecturerForm.ListStudent = StudentList;
                List<StudentDTO> listTemp = new List<StudentDTO>();
                listTemp.AddRange(StudentList);
                lecturerForm.ListStudentBackUp = listTemp;
                lecturerForm.PracticalExamStatus = practicalStatus;
                lecturerForm.PracticalExamCode = practicalExamCode;
                lecturerForm.Show();
                Hide();
            }
            catch (Exception ex)
            {
                Util.LogException("ShowLecturerForm", ex.Message);

            }

        }
        

        private void CopyPracticalInfoToSubmissionFolder(string scriptFolder)
        {
            try
            {
                if (Directory.Exists(scriptFolder))
                {
                    // copy practical-info.json to submission folder
                    string[] fileEntries = Directory.GetFiles(scriptFolder, "*.json");
                    if (fileEntries.Length > 0
                        && Path.GetFileName(fileEntries[0]).Equals(Constant.PRACTICAL_INFO, StringComparison.OrdinalIgnoreCase))
                    {
                        var sourceFile = fileEntries[0];
                        var destinationFile = Path.Combine(Util.GetProjectDirectory() + Constant.SUBMISSION_FOLDER_PATH, Constant.PRACTICAL_INFO);
                        File.Copy(sourceFile, destinationFile, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Util.LogException("CopyPracticalInfoToSubmissionFolder", ex.Message);

            }

        }

        private void ImportScriptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            enrollForm.Show();
        }

        private void ImportScriptForm_Load(object sender, EventArgs e)
        {
            LoadPractical();
        }

        private void dgvScriptFiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0 || index > PracticalList.Count - 1) return;
            PracticalDTO dto = PracticalList[index];
            if (Constant.PRACTICAL_STATUS[1].Equals(dto.State))
            {
                ImportTemplate(dto.Code);
            }
            else
            {
                var submissionFol = Path.Combine(Util.GetProjectDirectory() + Constant.SUBMISSION_FOLDER_PATH);
                ShowLecturerForm(dto.Code, dto.State, submissionFol);
            }
        }

        private void GetListStudentFromCSV(string practicalExamCode)
        {
            try
            {
                string practicalExam = practicalExamCode;
                int count = 0;
                var appDomainDir = Util.GetProjectDirectory();
                var destinationPath = Path.Combine(appDomainDir + Constant.SCRIPT_FILE_PATH);
                string listStudentPath = destinationPath + "\\" + practicalExam + "\\" + Constant.STUDENT_LIST_FILE_NAME;
                using (var reader = new StreamReader(listStudentPath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (count != 0)
                        {
                            StudentDTO dto = new StudentDTO();
                            try
                            {
                                var values = line.Split(',');
                                dto.StudentCode = values[Constant.STUDENT_CODE_INDEX];
                                dto.StudentName = values[Constant.STUDENT_NAME_INDEX];
                                dto.ScriptCode = values[Constant.SCRIPT_CODE_INDEX];
                                dto.SubmitTime = values[Constant.SUBMITTED_TIME_INDEX];
                                dto.EvaluateTime = values[Constant.EVALUATED_TIME_INDEX];
                                dto.CodingConvention = values[Constant.CODING_CONVENTION_INDEX];
                                dto.Result = values[Constant.RESULT_INDEX];
                                dto.TotalPoint = values[Constant.TOTAL_POINT_INDEX];
                                dto.ErrorMsg = values[Constant.ERROR_INDEX];
                                Dictionary<string, string> listQuestion = new Dictionary<string, string>();
                                try
                                {
                                    int index = Constant.QUESTION_DETAIL_INDEX;
                                    while (true)
                                    {
                                        string nextQuestion = values[index];
                                        string[] tempQuestion = nextQuestion.Split(':');
                                        listQuestion.Add(tempQuestion[0], tempQuestion[1] + ":" + tempQuestion[2]);
                                        index++;
                                    }
                                }
                                catch (Exception e)
                                {
                                    // end reading quesiton
                                }
                                dto.ListQuestions = listQuestion;

                            }
                            catch (Exception ex)
                            {
                                Util.LogException("GetListStudentFromCSV", ex.Message);
                            }
                            StudentList.Add(dto);
                        }
                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                Util.LogException("GetListStudentFromCSV", ex.Message);

            }

            //                /*
            //                 * 
            //                 * This block is for release app
            //                 * 
            //                 */

            //                //var projectNameDir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            //                //var destinationPath = Path.Combine(projectNameDir + Constant.SCRIPT_FILE_PATH);
            //foreach (StudentDTO dto in listStudent)
            //{
            //    Console.WriteLine(dto.StudentName);
            //}
        }
    }
}
