using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gprinter_Zxh
{
    public partial class Form3 : Form
    {
        private IntPtr Gp_IntPtr;                   //驱动打印句柄
        private libUsbContorl.UsbOperation NewUsb = new libUsbContorl.UsbOperation();
        public Form3()
        {
            InitializeComponent();
        }




        public string UserName { get; internal set; }

   
        private void SendData2USB(byte[] str)
        {
            NewUsb.SendData2USB(str, str.Length);
        }
        private void SendData2USB(string str)
        {
            byte[] by_SendData = System.Text.Encoding.GetEncoding(54936).GetBytes(str);
            SendData2USB(by_SendData);
        }

        private void btn_test_Click(object sender, EventArgs e)//测试按钮
        {
            //TSCLIB_DLL.about();                                                                //Show the DLL version
            TSCLIB_DLL.openport("TSC TDP-245");                                          //Open specified printer driver
            TSCLIB_DLL.setup("100", "63.5", "4", "8", "0", "0", "0");                          //Setup the media size and sensor type info
            TSCLIB_DLL.clearbuffer();                                                          //Clear image buffer
            TSCLIB_DLL.about();
            TSCLIB_DLL.barcode("100", "100", "128", "100", "1", "0", "2", "2", "Barcode Test"); //Drawing barcode
            TSCLIB_DLL.printerfont("100", "250", "TSS24.BF2", "0", "1", "1", "Print Font 测试");       //Drawing printer font
           // TSCLIB_DLL.windowsfont(100, 300, 24, 0, 0, 0, "GBK", "测试"); //Draw windows font       
           // TSCLIB_DLL.downloadpcx("UL.PCX", "UL.PCX");                                         //Download PCX file into printer                                                
            TSCLIB_DLL.sendcommand("PUTPCXL.PC 100,400,\"UL.PCX\"");                               //Drawing PCX graphic
            TSCLIB_DLL.printlabel("1", "1");                                                   //Print labels
            TSCLIB_DLL.closeport();                                                            //Close specified printer driver

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//LF
        {
            TSCLIB_DLL.openport("TSC TDP-245");
            //TSCLIB_DLL.setup("100", "63.5", "4", "8", "0", "0", "0");
            //TSCLIB_DLL.clearbuffer();
            //TSCLIB_DLL.formfeed();
            TSCLIB_DLL.sendcommand("FEED 400");
            TSCLIB_DLL.closeport();
        }

        private void btnBack_Click(object sender, EventArgs e)//退纸
        {
            TSCLIB_DLL.openport("TSC TDP-245");

            int data = Convert.ToInt32(nudBack.Value);
            if (cb_Back.Checked)
            {
                TSCLIB_DLL.sendcommand("BACKFEED " + data);
            }
            else
            {
                TSCLIB_DLL.sendcommand("BACKUP " + data);
            }


            TSCLIB_DLL.closeport();
        }

        private void btn_Box_Click(object sender, EventArgs e)//bar测试
        {
            TSCLIB_DLL.openport("TSC TDP-245");

            TSCLIB_DLL.sendcommand("CLS");
            TSCLIB_DLL.sendcommand("SIZE 80 mm,50 mm");
            TSCLIB_DLL.sendcommand("BAR 24,0,0,400");
            TSCLIB_DLL.sendcommand("BAR 30,0,3,400");
            TSCLIB_DLL.sendcommand("BAR 42,0,6,400");
            TSCLIB_DLL.sendcommand("BAR 60,0,9,400");
            TSCLIB_DLL.sendcommand("BAR 80,0,12,400");
            TSCLIB_DLL.sendcommand("BAR 114,0,15,400");
            TSCLIB_DLL.sendcommand("BAR 150,0,18,400");
            TSCLIB_DLL.sendcommand("BAR 192,0,21,400");
            TSCLIB_DLL.sendcommand("BAR 240,0,24,400");
            TSCLIB_DLL.sendcommand("BAR 294,0,27,400");
            TSCLIB_DLL.sendcommand("BAR 354,0,30,400");
            TSCLIB_DLL.sendcommand("BAR 420,0,33,400");
            TSCLIB_DLL.sendcommand("BAR 24,0,400,0");
            TSCLIB_DLL.sendcommand("BAR 24,6,400,3");
            TSCLIB_DLL.sendcommand("BAR 24,18,400,6");
            TSCLIB_DLL.sendcommand("BAR 24,36,400,9");
            TSCLIB_DLL.sendcommand("BAR 24,60,400,12");
            TSCLIB_DLL.sendcommand("BAR 24,90,400,15");
            TSCLIB_DLL.sendcommand("BAR 24,126,400,18");
            TSCLIB_DLL.sendcommand("BAR 24,168,400,21");
            TSCLIB_DLL.sendcommand("BAR 24,216,400,24");
            TSCLIB_DLL.sendcommand("BAR 24,270,400,27");
            TSCLIB_DLL.sendcommand("BAR 24,330,400,30");
            TSCLIB_DLL.sendcommand("BAR 24,396,400,33");

            TSCLIB_DLL.sendcommand("PRINT 1");

            TSCLIB_DLL.closeport();
        }
    }
}
