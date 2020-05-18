
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE2A_WF_Lecturer
{
    public partial class LecturerEnroll : Form
    {
        public LecturerEnroll()
        {
            InitializeComponent();
            ShowControls(true);
        }

        private void ShowControls(bool isVisble)
        {
            labelRollNumber.Visible = isVisble;
            txtEnrollKey.Visible = isVisble;
            btnEnroll.Visible = isVisble;
            loadingBox.Visible = !isVisble;
        }

        List<PracticalDTO> listPractical;
        private void btnEnroll_Click(object sender, EventArgs e)
        {
            string enrollKey = txtEnrollKey.Text.ToUpper().Trim();
            if (!CheckInput(enrollKey)) return;
            ShowControls(false);
            GetPracticalList(enrollKey);
            ImportScriptForm importScriptForm = new ImportScriptForm(this);
        }


        private bool CheckInput(string enrollKey)
        {
            if (enrollKey == null || enrollKey.Equals(""))
            {
                MessageBox.Show(Constant.ENROLL_NAME_NOT_NULL_MESSAGE);
                return false;
            }
            return true;
        }

        private async Task<string> GetPracticalListFromAPI(HttpClient client, string uri, string enrollKey)
        {
            string message = "";
            try
            {
                uri = "http://" + uri;
                var values = new Dictionary<string, string>{
                { "code", enrollKey }
                };
                HttpContent content = new FormUrlEncodedContent(values);
                HttpResponseMessage response = await client.PostAsync(new Uri(uri), content);
                if (response.IsSuccessStatusCode)
                {
                    message = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Util.LogException("GetPracticalListFromAPI", ex.Message);
            }
            return message;
        }

        private async void GetPracticalList(string enrollKey)
        {
            string apiUrl = Constant.ONLINE_API_URL;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string result = await GetPracticalListFromAPI(client, apiUrl, enrollKey);
                    listPractical = JsonConvert.DeserializeObject<List<PracticalDTO>>(result);
                    ImportScriptForm importScript = new ImportScriptForm(this);
                    importScript.PracticalList = listPractical;
                    importScript.Show();
                    this.InvokeEx(f => ShowControls(true));
                    this.InvokeEx(f => this.Hide());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Constant.CANNOT_CONNECT_API_MESSAGE);
                    Util.LogException("GetPracticalList", ex.Message);
                }
            }
        }
    }
}
