using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using InstaTest;
using System.Diagnostics;

using System.Web;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        static string fullProxy;
        static string email;
        static string pass;
        static string proxy;
        static string port;
        static string proxyLogin;
        static string proxyPass;
        static string name;
        static string nickname;

        private static string coockieUrl = "chrome-extension://fngmhnnpilhplaeedifhccceomclgfbg/popup.html?url=https://www.instagram.com/";

        string midCoockie = "Vtmq0AAEAAHzRAsP6Tmc1C5AnjI8";

        public static void ParsingProxy()
        {
            var xx = new StreamReader("proxy.txt");
            string input = xx.ReadLine();
            string pattern = @"(.*):(.*)@(.*):(.*)";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);
            fullProxy = match.Groups[0].Value;
            proxyLogin = match.Groups[1].Value;
            proxyPass = match.Groups[2].Value;
            proxy = match.Groups[3].Value;
            port = match.Groups[4].Value;
            xx.Close();
            OperationsWithFile.DeleteFirstLineFromFile("proxy.txt");
            xx.Close();
        }

        public static void GetNameFromFile()
        {
            var xx = new StreamReader("name.txt");
            string input = xx.ReadLine();
            name = input;
            xx.Close();
            OperationsWithFile.DeleteFirstLineFromFile("name.txt");
        }

        public static void GetEmailFromFile()
        {
            var xx = new StreamReader("email.txt");
            string input = xx.ReadLine();
            email = input;
            xx.Close();
            OperationsWithFile.DeleteFirstLineFromFile("email.txt");
        }

        public static void GetPassFromFile()
        {
            var xx = new StreamReader("pass.txt");
            string input = xx.ReadLine();
            pass = input;
            xx.Close();
            OperationsWithFile.DeleteFirstLineFromFile("pass.txt");
        }

        public static void WriteFinalInfoInFile()
        {
            string finalInfo = nickname + ":" + pass + ";" + fullProxy + "\n";
            File.AppendAllText("finalResult.txt", finalInfo); //write in file
        }


        private void button1_Click(object sender, EventArgs e)

        {
            Process.Start("C:\\Users\\Пользователь\\Desktop\\Свойства браузера - Ярлык");
            /*int count = File.ReadAllLines("proxy.txt").Length;*/ // number of line in file

            Process.Start("C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", "--window-position=0,0 --window-size=800,600  ");

            for (int i = 0; i < 1; i++)
            {

                System.Threading.Thread.Sleep(2999);
                ParsingProxy();
                System.Threading.Thread.Sleep(1000);
                OperationsWithFile.DeleteFirstLineFromFile("proxy.txt"); // delete first line from file




                System.Threading.Thread.Sleep(2999);
                Process.Start("www.instagram.com");
                System.Threading.Thread.Sleep(3000);

                Process.Start("C:\\Users\\Пользователь\\Desktop\\Свойства браузера - Ярлык");
                System.Threading.Thread.Sleep(2999);
                Cursor.Position = new Point(320, 510); //"настройка сети"
                System.Threading.Thread.Sleep(2999);
                VirtualMouse.LeftClick();
                System.Threading.Thread.Sleep(2999);
                Cursor.Position = new Point(150, 355); //input proxy
                System.Threading.Thread.Sleep(2999);
                VirtualMouse.LeftClick();
                System.Threading.Thread.Sleep(2999);
                //VirtualMouse.DoubleLeftClick();
                SendKeys.Send("^(a)");
                System.Threading.Thread.Sleep(3000);
                Clipboard.SetText(proxy);
                SendKeys.SendWait("^(v)");
                System.Threading.Thread.Sleep(2999); //input port
                Cursor.Position = new Point(240, 355);
                System.Threading.Thread.Sleep(2999);
                VirtualMouse.LeftClick();
                System.Threading.Thread.Sleep(2999);
                SendKeys.Send("^(a)");
                System.Threading.Thread.Sleep(2999);
                Clipboard.SetText(port);
                SendKeys.SendWait("^(v)");
                System.Threading.Thread.Sleep(2999);
                SendKeys.SendWait("{Enter}");

                System.Threading.Thread.Sleep(2999);
                Cursor.Position = new Point(550, 150);
                VirtualMouse.LeftClick();
                System.Threading.Thread.Sleep(2999);
                SendKeys.SendWait("{F5}");

                System.Threading.Thread.Sleep(2999);
                Clipboard.SetText(proxyLogin); //insert proxyName
                SendKeys.SendWait("^(v)");
                System.Threading.Thread.Sleep(2999);
                SendKeys.SendWait("{Tab}"); System.Threading.Thread.Sleep(2999);
                Clipboard.SetText(proxyPass);
                System.Threading.Thread.Sleep(2999);
                Clipboard.SetText(proxyPass);
                SendKeys.SendWait("^(v)");
                System.Threading.Thread.Sleep(2999);
                SendKeys.SendWait("{Tab}");
                System.Threading.Thread.Sleep(2999);
                SendKeys.SendWait("{Enter}");


                System.Threading.Thread.Sleep(2999); //midCoockie
                Cursor.Position = new Point(80, 65);
                System.Threading.Thread.Sleep(2999);
                VirtualMouse.LeftClick();
                Cursor.Position = new Point(745, 65);
                System.Threading.Thread.Sleep(2999);
                VirtualMouse.LeftClick();
                System.Threading.Thread.Sleep(2999);
                Cursor.Position = new Point(400, 300);
                System.Threading.Thread.Sleep(2999);
                VirtualMouse.LeftClick();
                System.Threading.Thread.Sleep(2999);
                SendKeys.Send("^(a)");
                System.Threading.Thread.Sleep(2999);
                Clipboard.SetText(midCoockie);
                SendKeys.SendWait("^(v)");
                Cursor.Position = new Point(480, 530);
                VirtualMouse.LeftClick();
                System.Threading.Thread.Sleep(2999);
                Cursor.Position = new Point(80, 65);
                System.Threading.Thread.Sleep(2999);
                VirtualMouse.LeftClick();

                System.Threading.Thread.Sleep(2999); //input registration data
                SendKeys.SendWait("{Tab}");
                System.Threading.Thread.Sleep(1500);
                SendKeys.SendWait("{Tab}");
                System.Threading.Thread.Sleep(1500);
                GetEmailFromFile();
                System.Threading.Thread.Sleep(1500);
                Clipboard.SetText(email);
                System.Threading.Thread.Sleep(1500);
                SendKeys.SendWait("^(v)");
                System.Threading.Thread.Sleep(1500);
                SendKeys.SendWait("{Tab}");
                System.Threading.Thread.Sleep(1500);
                GetNameFromFile();
                System.Threading.Thread.Sleep(1500);
                Clipboard.SetText(name);
                System.Threading.Thread.Sleep(1500);
                SendKeys.SendWait("^(v)");
                System.Threading.Thread.Sleep(1500);
                SendKeys.SendWait("{Tab}");
                System.Threading.Thread.Sleep(1500);
                SendKeys.SendWait("{Tab}");
                System.Threading.Thread.Sleep(1500);
                SendKeys.SendWait("{Enter}");


                System.Threading.Thread.Sleep(1500);
                SendKeys.SendWait("{Tab}");
                System.Threading.Thread.Sleep(1500);
                GetPassFromFile();
                System.Threading.Thread.Sleep(1500);
                Clipboard.SetText(pass);
                System.Threading.Thread.Sleep(2999);
                SendKeys.Send("^{v}");
                System.Threading.Thread.Sleep(1500);

                System.Threading.Thread.Sleep(1500);
                Cursor.Position = new Point(350, 490);// 
                VirtualMouse.LeftClick();
                System.Threading.Thread.Sleep(1500);
                SendKeys.Send("^{a}");
                System.Threading.Thread.Sleep(1500);
                SendKeys.Send("^{c}");
                System.Threading.Thread.Sleep(1500);
                nickname = Clipboard.GetText(TextDataFormat.Text);
                WriteFinalInfoInFile();


                SendKeys.SendWait("{Tab}");
                SendKeys.SendWait("{Tab}");
                SendKeys.SendWait("{Tab}");
                System.Threading.Thread.Sleep(1500);
                SendKeys.SendWait("{Enter}");
                System.Threading.Thread.Sleep(3000);

                Cursor.Position = new Point(745, 65);
                System.Threading.Thread.Sleep(1500);
                VirtualMouse.LeftClick();
                System.Threading.Thread.Sleep(1500);
                Cursor.Position = new Point(250, 100);
                System.Threading.Thread.Sleep(1500);
                VirtualMouse.LeftClick();
                System.Threading.Thread.Sleep(1500);
                Cursor.Position = new Point(150, 200);
                System.Threading.Thread.Sleep(1500);
                VirtualMouse.LeftClick();
                VirtualMouse.LeftClick();
                SendKeys.SendWait("{Esc}");
                SendKeys.Send("^{w}");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

