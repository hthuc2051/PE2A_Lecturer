using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE2A_WF_Lecturer
{
    class StudentPointDTO
    {
        public string StudentCode { get; set; }
        public Dictionary<string, string> ListQuestions { get; set; }
        public string TotalPoint { get; set; }
        public string SubmitTime { get; set; }
        public string EvaluateTime { get; set; }
        public string CodingConvention { get; set; }
        public string Result { get; set; }
        public string ErrorMsg { get; set; }

        public StudentPointDTO() { }

        public StudentPointDTO(
            string studentCode, 
            Dictionary<string, string> listQuestions, 
            string totalPoint, 
            string submitTime, 
            string evaluateTime, 
            string codingConvention,
            string result, 
            string errorMsg)
        {
            StudentCode = studentCode;
            ListQuestions = listQuestions;
            TotalPoint = totalPoint;
            SubmitTime = submitTime;
            EvaluateTime = evaluateTime;
            CodingConvention = codingConvention;
            Result = result;
            ErrorMsg = errorMsg;
        }
    }
}
