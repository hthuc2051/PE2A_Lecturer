
using System.Collections.Generic;

namespace PE2A_WF_Lecturer
{
    public static class Constant
    {
        // Application's PORT
        public const int LECTURER_LISTENING_PORT = 9999;
        public const int STUDENT_LISTENING_PORT = 9998;
        public const int SOCKET_STUDENT_POINT_LISTENING_PORT = 9997;
        public const int SOCKET_STUDENT_SUBMISSION_LISTENING_PORT = 9996;
        public const int UPD_LISTENING_PORT = 5656;
        public const int MAXIMUM_REQUEST = 100;

        // Common messages
        public static string EXISTED_IP_MESSAGE = "You Have Connected To Server";
        public static string EXIST_CONFIRM = "Do you want to Exit?";
        public static string[] STATUSLIST = { "Connected", "Submitted", "Evaluated", "Error"};
        public static string CLIENT_SOCKET_CLOSED_MESSAGE = "Clients closed their connection!!!";
        public static string PROTOCOL = "http://";
        public static string PROTOCOL_HTTPS = "http://";
        public static string ENDPOINT = ":2020/api/submission";
        public static string REMOVE_STUDENT_MESSAGE = "Do you want to remove ";
        public static string REEVALUATE_STUDENT_MESSAGE = "Do you want to re evaluate ";
        public static string ENROLL_NAME_NOT_NULL_MESSAGE = "EnrollName is must NOT empty please";
        public static string PASSWORD_NOT_NULL_MESSAGE = "Password is must NOT empty please";
        public static string CANNOT_CONNECT_API_MESSAGE = "Can not connect to online webservice";
        public static string ONLINE_API_URL = "localhost:2021/api/practical-exam/lecturer/enroll";
        // Check duplicated code on webservice
        public static string ONLINE_API_CHECK_DUPLICATED_CODE_URL = "localhost:2021/api/practical-exam/check-code";
        public static string CLOSE_SPRING_BOOT_SERVER = "localhost:2020/close";
        public static List<string> HIDDEN_COLUMN = new List<string> { "TcpClient", "ListQuestions", "Id", "SubmitPath", "CodingConvention", "ErrorMsg"};
        public static string CLASS_EMPTY_MESSAGE = "Your class have no student please check again";
        public static string SCRIPT_PREFIX = "DE";
        public static string HEADER_COLUMN_STUDENTNAME = "Name";
        public static string HEADER_COLUMN_STUDENTCODE = "Code";
        public static string HEADER_COLUMN_SCRIPTCODE = "Script";
        public static int MAXIMUM_SEND_TIME = 3;

        // Custom data grid view width
        public static int COLUMN_WIDTH_A_LETTER = 20;
        public static int COLUMN_NO_LETTER = 2;
        public static int COLUMN_POINT_LETTER = 4;
        public static int COLUMN_RESULT_LETTER = 4;
        public static int COLUMN_STUDENTCODE_LETTER = 5;
        public static int COLUMN_SCRIPTCODE_LETTER = 3;
        public static int COLUMN_CLOSE_LETTER = 3;

        public static string COLUMN_SCRIPTCODE_NAME = "ScriptCodes";

        // 
        public static string ZIP_EXTENSION = ".zip";
        public static string RAR_EXTENSION = ".rar";
        public const string SCRIPT_FILE_PATH = @"\submission\PracticalExams";
        public const string SUBMISSION_FOLDER_PATH = @"\submission";
        public const string PRACTICAL_INFO = "practical-info.json";

        // read student list from csv
        public static string STUDENT_LIST_FILE_NAME = "Student_List.csv";
        public static int STUDENT_CODE_INDEX = 1;
        public static int STUDENT_NAME_INDEX = 2;
        public static int SCRIPT_CODE_INDEX = 3;
        public static int SUBMITTED_TIME_INDEX = 4;
        public static int EVALUATED_TIME_INDEX = 5;
        public static int CODING_CONVENTION_INDEX = 6;
        public static int RESULT_INDEX= 7;
        public static int TOTAL_POINT_INDEX= 8;
        public static int QUESTION_DETAIL_INDEX= 10;
        public static int ERROR_INDEX= 9;

        public static string[] PRACTICAL_STATUS = {"DONE","NOT_EVALUATE","ERROR" };
        public static string SUMISSION_FOLDER_NAME = "Submissions";

        // read exam script 
        public static string EXAM_SCIPT_FOLDER_NAME = "ExamDocuments";
        public static string WORD_FILE_EXTENSION = ".docx";

        // TCP code
        public static string RETURN_URL_CODE = "[RETURN_URL]";
        public static string RETURN_EXAM_SCIPT = "[RETURN_EXAM_SCRIPT]";
        public static string RETURN_POINT = "[RETURN_POINT]";

        public static string REGEX_NUMBER = @"[0-9]+$";

        public const string ACTION_UPDATE = "UPDATE";
        public const string ACTION_REMOVE = "REMOVE";
        public const string ACTION_ADD = "ADD";

        // re-evaluate folder
        public const string RE_EVALUATE_FOLDER = @"\Submited Files";
        public const string WEBAPP_FOLDER = @"\webapp";
        public const string WORK_FOLDER = @"\work";
        public const string WORK_WEBPAGE_PATH = @"\work\JavaWebTemplate\web";
        public const string STUDENT_FOLDER_JAVAWEB = @"work\JavaWebTemplate\src\java\com\practicalexam\student";
        public const string STUDENT_FOLDER_JAVA = @"work\JavaTemplate\src\com\practicalexam\student";
        public const string STUDENT_FOLDER_CSharp = @"work\CSharpTemplate\CSharpTemplate\Practical\student";
        public const string STUDENT_FOLDER_C = @"work\CTemplate\student";

        // Practical Exam type 
        public static string PRACTICAL_EXAM_JAVA = "JAVA";
        public static string PRACTICAL_EXAM_JAVA_WEB = "JAVAWEB";
        public static string PRACTICAL_EXAM_C_SHARP = "CSHARP";
        public static string PRACTICAL_EXAM_C = "C";

        //Log file
        public static string LOG_FILE = "Log_file.txt";

        // Run CMD
        public const string SUBMISSION_SERVE_FOLDER = "Server";
        public const string CMD_COMMAND_RUN_SUBMISSION_SERVER = "/k mvn spring-boot:run";

        // Open Check Duplicated Code result on react app
        public static string DUPLICATED_LOCALHOST_DOMAIN = "http://localhost:1998/practicalexam/";
        public static string DUPLICATED_ONLINE_DOMAIN = "ADD LATER";

        // Update Practical exam state 
        public static string UPDATE_PRACTICALEXAM_STATE_LOCALHOST = "localhost:2021/api/practical-exam/set-state";
        public static string UPDATE_PRACTICALEXAM_STATE_ONLINE = "ADD LATER";
    }
}
