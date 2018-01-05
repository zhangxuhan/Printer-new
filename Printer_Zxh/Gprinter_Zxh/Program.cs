using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

public class TSCLIB_DLL
{
    //[System.Runtime.InteropServices.DllImport("tsclib.dll")]
    //private static extern void windowsfont(int a, int b, int c, int d, int e, int f, string g, string h);
    //[System.Runtime.InteropServices.DllImport("tsclib.dll")]
    //private static extern void openport(string printername);
    //[System.Runtime.InteropServices.DllImport("tsclib.dll")]
    //private static extern void closeport();
    //[System.Runtime.InteropServices.DllImport("tsclib.dll")]
    //private static extern void sendcommand(string command);
    //[System.Runtime.InteropServices.DllImport("tsclib.dll")]
    //private static extern void setup(string width, string height, string speed, string density, string sensor, string vertical, string offset);
    //[System.Runtime.InteropServices.DllImport("tsclib.dll")]
    //private static extern void clearbuffer();
    //[System.Runtime.InteropServices.DllImport("tsclib.dll")]
    //private static extern void printlabel(string Set, string Copy);


    [DllImport("TSCLIB.dll", EntryPoint = "about")]
    public static extern int about();

    [DllImport("TSCLIB.dll", EntryPoint = "openport")]
    public static extern int openport(string printername);

    [DllImport("TSCLIB.dll", EntryPoint = "barcode")]
    public static extern int barcode(string x, string y, string type,
                   string height, string readable, string rotation,
                   string narrow, string wide, string code);

    [DllImport("TSCLIB.dll", EntryPoint = "clearbuffer")]
    public static extern int clearbuffer();

    [DllImport("TSCLIB.dll", EntryPoint = "closeport")]
    public static extern int closeport();

    [DllImport("TSCLIB.dll", EntryPoint = "downloadpcx")]
    public static extern int downloadpcx(string filename, string image_name);

    [DllImport("TSCLIB.dll", EntryPoint = "formfeed")]
    public static extern int formfeed();

    [DllImport("TSCLIB.dll", EntryPoint = "nobackfeed")]
    public static extern int nobackfeed();

    [DllImport("TSCLIB.dll", EntryPoint = "printerfont")]
    public static extern int printerfont(string x, string y, string fonttype,
                       string rotation, string xmul, string ymul,
                       string text);

    [DllImport("TSCLIB.dll", EntryPoint = "printlabel")]
    public static extern int printlabel(string set, string copy);

    [DllImport("TSCLIB.dll", EntryPoint = "sendcommand")]
    public static extern int sendcommand(string printercommand);

    [DllImport("TSCLIB.dll", EntryPoint = "setup")]
    public static extern int setup(string width, string height,
                 string speed, string density,
                 string sensor, string vertical,
                 string offset);

    [DllImport("TSCLIB.dll", EntryPoint = "windowsfont")]
    public static extern int windowsfont(int x, int y, int fontheight,
        int rotation, int fontstyle, int fontunderline,
                       string szFaceName, string content);
    //"sendBinaaryData()";
    //"windowsfontUnicode(a,b,c,d,e,f,g,h)";
    //"usbportqueryprinter()"

}



namespace Gprinter_Zxh
{


    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
       
            /**
                   * 当前用户是管理员的时候，直接启动应用程序
                   * 如果不是管理员，则使用启动对象启动程序，以确保使用管理员身份运行
                   */
            //获得当前登录的Windows用户标示
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            //判断当前登录用户是否为管理员
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                //如果是管理员，则直接运行
                Application.Run(new Form1());
            }
            else
            {
                //创建启动对象
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.UseShellExecute = true;
                startInfo.WorkingDirectory = Environment.CurrentDirectory;
                startInfo.FileName = Application.ExecutablePath;
                //设置启动动作,确保以管理员身份运行
                startInfo.Verb = "runas";
                try
                {
                    System.Diagnostics.Process.Start(startInfo);
                }
                catch
                {
                    return;
                }
                //退出
                Application.Exit();
            }
        }
    }
}