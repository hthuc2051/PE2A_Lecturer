using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PE2A_WF_Lecturer
{
    public class StudentDTO
    {
        public int NO { get; set; }
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public string ScriptCode { get; set; }
        public string Status { get; set; }
        public TcpClient TcpClient { get; set; }

        // Student point details
        public Dictionary<string, string> ListQuestions { get; set; }
        public string TotalPoint { get; set; }
        public string SubmitTime { get; set; }
        public string EvaluateTime { get; set; }
        public string CodingConvention { get; set; }
        public string Result { get; set; }
        public string ErrorMsg { get; set; }

        public int Id { get; set; }
        public string SubmitPath { get; set; }
        public Image Close { get; set; }

        public StudentDTO(string studentCode, TcpClient tcpClient)
        {
            StudentCode = studentCode;
            TcpClient = tcpClient;
        }

        public StudentDTO(int no, string studentCode, TcpClient tcpClient, string status, Image close)
        {
            this.NO = no;
            StudentCode = studentCode;
            TcpClient = tcpClient;
            this.Status = status;
            this.Close = close;
        }

        public StudentDTO()
        {
        }
        public object Shallowcopy()
        {
            return this.MemberwiseClone();
        }

    }
}
