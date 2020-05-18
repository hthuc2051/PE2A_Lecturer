using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using SharpCompress.Archives.Rar;
using SharpCompress.Common;
using SharpCompress.Archives;
using SharpCompress.Archives.Zip;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PE2A_WF_Lecturer
{
    public class Util
    {
        private static Socket listeningSocket;
        private static Socket listeningSockets;
        private static System.Diagnostics.Process process;
        public static void SendBroadCast(string message, int receiverListeningPort)
        {
            try
            {
                IPEndPoint ipEnd = new IPEndPoint(IPAddress.Broadcast, receiverListeningPort);
                Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                byte[] bytes = Encoding.ASCII.GetBytes(message);
                clientSock.SetSocketOption(SocketOptionLevel.Socket,
                SocketOptionName.Broadcast, 1);
                clientSock.SendTo(bytes, ipEnd);
                clientSock.Close();
            }
            catch (Exception ex)
            {
                LogException("SendBroadCast", ex.Message);

            }

        }

        public static string GetMessageFromTCPConnection(int listeningPort, int maximumRequest)
        {
            try
            {
                listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] buffer = new byte[1024];
                IPEndPoint senders = new IPEndPoint(IPAddress.Any, listeningPort);
                listeningSocket.Bind(senders);
                listeningSocket.Listen(maximumRequest);
                Socket conn = listeningSocket.Accept();
                int size = conn.Receive(buffer);
                ASCIIEncoding eEncpding = new ASCIIEncoding();
                string receivedMessage = eEncpding.GetString(buffer);
                listeningSocket.Close();
                return receivedMessage.Substring(0, size);
            }
            catch (Exception ex)
            {
                LogException("GetMessageFromTCPConnection", ex.Message);

            }
            return null;
        }

        public static string GetMessageFromTCPConnections(int listeningPort, int maximumRequest)
        {
            try
            {
                listeningSockets = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] buffer = new byte[1024];
                IPEndPoint senders = new IPEndPoint(IPAddress.Any, listeningPort);
                listeningSockets.Bind(senders);
                listeningSockets.Listen(maximumRequest);
                Socket conn = listeningSockets.Accept();
                int size = conn.Receive(buffer);
                ASCIIEncoding eEncpding = new ASCIIEncoding();
                string receivedMessage = eEncpding.GetString(buffer);
                listeningSockets.Close();
                return receivedMessage.Substring(0, size);
            }
            catch (Exception ex)
            {
                LogException("GetMessageFromTCPConnections", ex.Message);

            }
            return null;
        }

        public static IPAddress GetLocalIPAddress()
        {
            try
            {
                string hostName = Dns.GetHostName();
                string ip = Dns.GetHostByName(hostName).AddressList[0].ToString();
                return IPAddress.Parse(ip);
            }
            catch (Exception ex)
            {
                LogException("GetLocalIPAddress", ex.Message);
            }
            return null;
        }
        public static string ReceiveMessage(byte[] bytes)
        {
            try
            {
                string message = System.Text.Encoding.Unicode.GetString(bytes);

                string messageToPrint = null;
                foreach (var nullChar in message)
                {
                    if (nullChar != '\0')
                    {
                        messageToPrint += nullChar;
                    }
                }
                return messageToPrint;
            }
            catch (Exception ex)
            {
                LogException("receiveMessage", ex.Message);

            }
            return null;

        }
        public static void SendMessage(byte[] bytes, TcpClient client)
        {
            try
            {
                // Client must be connected to   
                client.GetStream() // Get the stream and write the bytes to it  
                      .Write(bytes, 0,
                      bytes.Length); // Send the stream  
            }
            catch (Exception ex)
            {
                LogException("sendMessage", ex.Message);

            }


        }
        public static void UnarchiveFile(string filePath, string destDirectory)
        {
            try
            {
                string filenameExtension = Path.GetExtension(filePath);

                if (Directory.Exists(destDirectory))
                {
                    if (filenameExtension.Equals(Constant.ZIP_EXTENSION, StringComparison.OrdinalIgnoreCase))
                    {
                        using (var zipArchive = ZipArchive.Open(filePath))
                        {
                            foreach (var entry in zipArchive.Entries)
                            {
                                entry.WriteToDirectory(destDirectory, new ExtractionOptions()
                                {
                                    Overwrite = true,
                                    ExtractFullPath = true,
                                });
                            }
                        }
                    }
                    else if (filenameExtension.Equals(Constant.RAR_EXTENSION, StringComparison.OrdinalIgnoreCase))
                    {
                        using (var rarArchive = RarArchive.Open(filePath))
                        {
                            foreach (var entry in rarArchive.Entries)
                            {
                                entry.WriteToDirectory(destDirectory, new ExtractionOptions()
                                {
                                    Overwrite = true,
                                    ExtractFullPath = true,
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogException("UnarchiveFile", ex.Message);
            }
        }

        private static byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] keyBytes)
        {
            try
            {
                byte[] encryptedBytes = null;

                // Set your salt here, change it to meet your flavor:
                // The salt bytes must be at least 8 bytes.
                var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

                using (MemoryStream ms = new MemoryStream())
                {
                    using (RijndaelManaged AES = new RijndaelManaged())
                    {
                        var key = new Rfc2898DeriveBytes(keyBytes, saltBytes, 1000);

                        AES.KeySize = 256;
                        AES.BlockSize = 128;
                        AES.Key = key.GetBytes(AES.KeySize / 8);
                        AES.IV = key.GetBytes(AES.BlockSize / 8);

                        AES.Mode = CipherMode.CBC;

                        using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                            cs.Close();
                        }

                        encryptedBytes = ms.ToArray();
                    }
                }

                return encryptedBytes;
            }
            catch (Exception ex)
            {
                LogException("Encrypt", ex.Message);
            }
            return null;
        }
        public static string Encode(string plainText, string key)
        {
            try
            {
                if (plainText == null)
                {
                    return null;
                }

                if (key == null)
                {
                    key = String.Empty;
                }

                // Get the bytes of the string
                var bytesToBeEncrypted = Encoding.UTF8.GetBytes(plainText);
                var keyBytes = Encoding.UTF8.GetBytes(key);

                // Hash the key with SHA256
                keyBytes = SHA256.Create().ComputeHash(keyBytes);

                var bytesEncrypted = Encrypt(bytesToBeEncrypted, keyBytes);

                return Convert.ToBase64String(bytesEncrypted);
            }
            catch (Exception ex)
            {
                LogException("Encode", ex.Message);

            }
            return null;
        }

        public static string GetProjectDirectory()
        {
            try
            {
                var appDomainDir = Util.ExecutablePath();
                //var projectNameDir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                return appDomainDir;
            }
            catch (Exception ex)
            {
                LogException("GetProjectDirectory", ex.Message);

            }
            return null;

        }


        /*
        * 
        * This block is for release app
        * 
        */
        public static string ExecutablePath()
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            return appPath + @"\Lecturer";
        }

        /*
        * 
        * This block is for local test (IDE test)
        * 
        */
        //public static string ExecutablePath()
        //{
        //    try
        //    {
        //        string startupPath = System.IO.Directory.GetCurrentDirectory();
        //        string projectDirectory = Directory.GetParent(startupPath).Parent.FullName;
        //        return projectDirectory + @"\Lecturer";
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException("ExecutablePath", ex.Message);
        //    }
        //    return null;
        //}
        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            try
            {
                DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
                DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);
                CopyAll(diSource, diTarget);
            }
            catch (Exception ex)
            {
                LogException("Copy", ex.Message);
            }

        }
        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            try
            {
                Directory.CreateDirectory(target.FullName);

                // Copy each file into the new directory.
                foreach (FileInfo fi in source.GetFiles())
                {
                    Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                    fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
                }

                // Copy each subdirectory using recursion.
                foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
                {
                    DirectoryInfo nextTargetSubDir =
                        target.CreateSubdirectory(diSourceSubDir.Name);
                    CopyAll(diSourceSubDir, nextTargetSubDir);
                }
            }
            catch (Exception ex)
            {
                LogException("CopyAll", ex.Message);
            }

        }
        public static void LogException(String methodName, String errorMessage)
        {
            try
            {
                String currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                String logging = currentTime + methodName + " error : " + "\r\n";
                logging += errorMessage + "\r\n";
                String filePath = ExecutablePath() + @"\" + Constant.LOG_FILE;
                File.AppendAllText(filePath, logging);
            }
            catch (Exception ex)
            {
                Console.WriteLine("LogException error :" + ex.Message);
            }

        }
        public static void OpenBrowser(String url)
        {
            try
            {
                System.Diagnostics.Process.Start(url);

            }
            catch (Exception ex)
            {
                LogException("OpenBrowser", ex.Message);
            }
        }

        public static void RefreseServerSubmission(String url)
        {
            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception ex)
            {
                LogException("RefreseServerSubmission", ex.Message);
            }
        }
        public static void RunCmd(String cmdPath, String mavenCmd)
        {
            try
            {
                process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = mavenCmd;
                startInfo.WorkingDirectory = cmdPath;
                process.StartInfo = startInfo;
                process.Start();
            }
            catch (Exception ex)
            {
                LogException("RunCmd", ex.Message);

            }

        }
        private static async void CloseSpringbootServer()
        {
            string apiUrl = Constant.CLOSE_SPRING_BOOT_SERVER;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                try
                {
                    string result = await CloseServer(client, apiUrl);

                }
                catch (Exception ex)
                {

                    Util.LogException("CloseSpringbootServer", ex.Message);
                }
            }

        }

        private static async Task<string> CloseServer(HttpClient client, string uri)
        {
            string message = "";
            try
            {
                string url = "http://localhost:2020/close";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                
            }
            return message;
        }
        public static void CloseCMD()
        {
            try
            {
                CloseSpringbootServer();
                process.CloseMainWindow();
                process.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
