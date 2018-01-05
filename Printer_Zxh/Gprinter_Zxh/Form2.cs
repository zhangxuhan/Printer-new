using System;
using System.Windows.Forms;
using GprinterTest;
using System.Threading;
using System.IO;
using System.Drawing;

namespace Gprinter_Zxh
{
    public partial class Form2 : Form
    {
        internal object UserName;
        //private IntPtr Gp_IntPtr;                   //驱动打印句柄
        private libUsbContorl.UsbOperation NewUsb = new libUsbContorl.UsbOperation();

        public Form2()
        {
            InitializeComponent();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否退出", "提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            NewUsb.FindUSBPrinter();
            for (int k = 0; k < NewUsb.USBPortCount; k++)
            {
                int i = 0;
                if (NewUsb.LinkUSB(k))
                {
                    byte[] shiftsize = { 0x1d, 0x57, 0xd0, 0x01 };//偏移量
                    byte[] KanjiMode = { 0x1c, 0x26 };//汉字模式

                    SendData2USB(shiftsize);
                    SendData2USB(KanjiMode);

                    #region 打印信息测试
                    string strPrintwidth = "48毫米";
                    string strPrintDensity = "384点/行";
                    string strPrintSpeed = "90毫米/秒";
                    string strPrintLiftTime = "50公里";
                    string strPowerSupply = "DC 12V/4A";
                    string strSerialInfo = "有";
                    string strParInfo = "无";
                    string strUSBInfo = "USB2.0协议";
                    string strWirelessInfo = "无";
                    string strNetInfo = "无";

                    //string strSend;
                    byte[] SendData = { 0x1b, 0x61, 0x01, 0x1b, 0x21, 0x30, 0x1c, 0x57, 0x01 };//字体
                    byte[] enddata = { 0x0a };//换行

                    SendData2USB(SendData);

                    string strSendData = "联机测试";
                    SendData2USB(strSendData);

                    SendData2USB(new byte[] { 0x0a, 0x0a });
                    SendData2USB(new byte[] { 0x1b, 0x61, 0x00, 0x1b, 0x21, 0x00, 0x1c, 0x57, 0x00 });

                    SendData2USB("技术指标：");
                    SendData2USB(enddata);
                    SendData2USB("*打印宽度" + strPrintwidth);
                    SendData2USB(enddata);
                    SendData2USB("*打印速度" + strPrintSpeed);
                    SendData2USB(enddata);
                    SendData2USB("*打印浓度" + strPrintDensity);
                    SendData2USB(enddata);
                    SendData2USB("*使用寿命" + strPrintLiftTime);
                    SendData2USB(enddata);
                    SendData2USB("*电源要求" + strPowerSupply);
                    SendData2USB(enddata);
                    SendData2USB("*打印宽度" + strPrintwidth);
                    SendData2USB(enddata);
                    SendData2USB("*串行接口" + strSerialInfo);
                    SendData2USB(enddata);
                    SendData2USB("*并行接口" + strParInfo);
                    SendData2USB(enddata);
                    SendData2USB("*USB接口" + strUSBInfo);
                    SendData2USB(enddata);
                    SendData2USB("*无线接口" + strWirelessInfo);
                    SendData2USB(enddata);
                    SendData2USB("*网络接口" + strNetInfo);
                    SendData2USB(enddata);
                    SendData2USB(enddata);
                    #endregion

                    #region 字体打印测试


                    SendData2USB(KanjiMode);
                    SendData2USB(SendData);
                    string strSendData2 = "字体打印测试";
                    SendData2USB(strSendData2);//字体加粗加大
                    SendData2USB(new byte[] { 0x0a });//换行
                    SendData2USB(new byte[] { 0x1b, 0x61, 0x00, 0x1b, 0x21, 0x00, 0x1c, 0x57, 0x00 });//结束加粗

                    SendData = new byte[16];
                    int linecount = 3;
                    byte bit = 0xa1, Zone = 0xa1;
                    for (i = 0; i < 16; i += 2)//一行的8个字
                    {
                        SendData[i] = Zone;//zone不变，保持A0-F
                        SendData[i + 1] = bit;//A1-A8
                        bit++;
                    }
                    SendData2USB(enddata);
                    SendData2USB(SendData);

                    Zone = 0xb0;
                    bit = 0xa1;
                    for (i = 0; i < linecount; i++)//三行字
                    {
                        for (int j = 0; j < 16; j += 2)
                        {
                            SendData[j] = Zone;
                            SendData[j + 1] = bit;
                            Zone++;
                        }
                        bit++;//一行A1：B0-B7，一行A2：B8-BF，一行A3：C0-C7
                        SendData2USB(enddata);
                        SendData2USB(SendData);
                    }
                    SendData2USB(enddata);
                    SendData2USB(enddata);
                    #endregion

                    SendData2USB(new byte[] { 0x10, 0x04, 0x01 });//查询状态
                    byte[] readData = new byte[] { };
                    NewUsb.ReadDataFmUSB(ref readData);
                    NewUsb.CloseUSBPort();
                }
            }
        }

        private void SendData2USB(byte[] str)
        {
            NewUsb.SendData2USB(str, str.Length);
        }

        private void SendData2USB(string str)
        {
            byte[] by_SendData = System.Text.Encoding.GetEncoding(54936).GetBytes(str);
            SendData2USB(by_SendData);
        }

        private void button2_Click(object sender, EventArgs e)////打印走纸LF
        {
            byte[] enddata = { 0x0a };//换行
            NewUsb.FindUSBPrinter();
            for (int k = 0; k < NewUsb.USBPortCount; k++)
            {
                //int i = 0;
                if (NewUsb.LinkUSB(k))
                {
                    byte[] shiftsize = { 0x0A };
                    SendData2USB("a");
                    SendData2USB(shiftsize);
                    SendData2USB("b");
                    SendData2USB(shiftsize);
                    SendData2USB("c");
                    SendData2USB(shiftsize);

                    //SendData2USB(enddata);
                    SendData2USB(new byte[] { 0x10, 0x04, 0x01 });//查询状态
                    byte[] readData = new byte[] { };
                    NewUsb.ReadDataFmUSB(ref readData);
                    NewUsb.CloseUSBPort();
                }
            }
        }

        private void 查看帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("版本：v1.0 作者：zxh", "使用帮助", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string printdouble = "";
            if (rdoNo.Checked)
            {
                printdouble = rdoNo.Text;
            }
            else if (rdoYes.Checked)
            {
                printdouble = rdoYes.Text;
            }
            string underline = cboUnderline.Text;
            MessageBox.Show(printdouble + underline);
        }

        private void 查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string printdouble = "";
            if (rdoNo.Checked)
            {
                printdouble = rdoNo.Text;
            }
            else if (rdoYes.Checked)
            {
                printdouble = rdoYes.Text;
            }
            string underline = cboUnderline.Text;
            MessageBox.Show(printdouble + underline);
        }

        private void btnPrintdouble_Click(object sender, EventArgs e)//双重打印
        {
            byte[] enddata = { 0x0a };//换行
            NewUsb.FindUSBPrinter();
            for (int k = 0; k < NewUsb.USBPortCount; k++)
            {
                //int i = 0;
                if (NewUsb.LinkUSB(k))
                {
                    //string printer_state = "";
                    if (rdoYes.Checked)
                    {
                        byte[] size = { 0x1B, 0x47, 0x01 };
                        SendData2USB(size);
                        SendData2USB("测试文本012345LMNOPQabcdefg");
                        SendData2USB(enddata);
                        SendData2USB(enddata);
                    }
                    else if (rdoNo.Checked)
                    {
                        byte[] size = { 0x1B, 0x47, 0x00 };
                        SendData2USB(size);
                        SendData2USB("测试文本012345LMNOPQabcdefg");
                        SendData2USB(enddata);
                        SendData2USB(enddata);
                    }
                    //SendData2USB(enddata);
                    SendData2USB(new byte[] { 0x10, 0x04, 0x01 });//查询状态
                    byte[] readData = new byte[] { };
                    NewUsb.ReadDataFmUSB(ref readData);
                    NewUsb.CloseUSBPort();
                }

                //private void btnOpen_Click(object sender, EventArgs e)//MDI
                //{
                //    FormChild child = new FormChild();
                //    child.MdiParent = this;//父窗体是当前窗体
                //    child.Show();
                //}
            }
        }

        private void btnUnderline_Click(object sender, EventArgs e)//下划线模式
        {
            byte[] enddata = { 0x0a };//换行
            NewUsb.FindUSBPrinter();
            for (int k = 0; k < NewUsb.USBPortCount; k++)
            {
                //int i = 0;
                if (NewUsb.LinkUSB(k))
                {
                    string underline = cboUnderline.Text;
                    if (underline == "取消下划线")
                    {
                        byte[] size = { 0x1B, 0x2D, 0x00, 0x30 };
                        SendData2USB(size);
                        SendData2USB("测试文本012345LMNOPQabcdefg");
                        SendData2USB(enddata);
                        SendData2USB(enddata);
                    }
                    else if (underline == "1点宽下划线")
                    {
                        byte[] size = { 0x1B, 0x2D, 0x01, 0x31 };
                        SendData2USB(size);
                        SendData2USB("测试文本012345LMNOPQabcdefg");
                        SendData2USB(enddata);
                        SendData2USB(enddata);
                    }
                    else if (underline == "2点宽下划线")
                    {
                        byte[] size = { 0x1B, 0x2D, 0x02, 0x32 };
                        SendData2USB(size);
                        SendData2USB("测试文本012345LMNOPQabcdefg");
                        SendData2USB(enddata);
                        SendData2USB(enddata);
                    }
                    //SendData2USB(enddata);
                    SendData2USB(new byte[] { 0x10, 0x04, 0x01 });//查询状态
                    byte[] readData = new byte[] { };
                    NewUsb.ReadDataFmUSB(ref readData);
                    NewUsb.CloseUSBPort();
                }
            }
        }



        /// <summary>
        /// 重写metset
        /// </summary>
        /// <param name="buf">设置的数组</param>
        /// <param name="val">设置的数据</param>
        /// <param name="size">数据长度</param>
        /// <returns>void</returns>     
        public void memset(byte[] buf, byte val, int size)
        {
            int i;
            for (i = 0; i < size; i++)
                buf[i] = val;
        }

        /// <summary>
        /// 将 Stream 转成 byte[]
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }

        public void sendGSBmpStream(string filename, byte printMod)
        {
            byte[] setHBit = { 0x80, 0x40, 0x30, 0x10, 0x08, 0x04, 0x02, 0x01 };    //算法辅助
            byte[] clsLBit = { 0x7F, 0xBF, 0xDF, 0xEF, 0xF7, 0xFB, 0xFD, 0xFE };    //算法辅助

            uint sendWidth = 0;      //实际发送的宽
            uint sendHeight = 0;    //实际发送的高
            byte[] SendBmpData = new byte[] { };

            if (filename != "")
            {//支持4，8位 位图
                StreamReader srReadFile = new StreamReader(filename);

                byte[] byteReaddata = StreamToBytes(srReadFile.BaseStream);//获取读取文件的byte[]数据
                srReadFile.Close();

                byte bmpBitCount = byteReaddata[0x1c]; //获取位图 位深度

                Stream str1 = new MemoryStream();
                Image getimage = Image.FromFile(filename);

                sendWidth = (uint)getimage.Width;      //实际发送的宽
                sendHeight = (uint)getimage.Height;    //实际发送的高

                if (getimage.Height % 8 != 0)
                    sendHeight = sendHeight + 8 - sendHeight % 8;
                if (getimage.Width % 8 != 0)
                    sendWidth = sendWidth + 8 - sendWidth % 8;

                Bitmap getbmp = new Bitmap(getimage);
                //                     Bitmap BmpCopy = new Bitmap(getimage.Width, getimage.Height, PixelFormat.Format32bppArgb);

                SendBmpData = new byte[sendWidth * sendHeight / 8];

                #region 求灰度平均值
                Double redSum = 0, geedSum = 0, blueSum = 0;
                Double total = sendWidth * sendHeight;
                byte[] huiduData = new byte[sendWidth * sendHeight / 8];
                for (int i = 0; i < getimage.Width; i++)
                {
                    int ta = 0, tr = 0, tg = 0, tb = 0;
                    for (int j = 0; j < getimage.Height; j++)
                    {
                        Color getcolor = getbmp.GetPixel(i, j);//取每个点颜色
                        ta = getcolor.A;
                        tr = getcolor.R;
                        tg = getcolor.G;
                        tb = getcolor.B;
                        redSum += tr;
                        geedSum += tg;
                        blueSum += tb;
                    }
                }
                int meanr = (int)(redSum / total);
                int meang = (int)(geedSum / total);
                int meanb = (int)(blueSum / total);
                #endregion 求灰度平均值

                #region 抖动效果

                #endregion 抖动效果

                for (int j = 0; j < getimage.Height; j++)
                {
                    for (int i = 0; i < getimage.Width; i++)
                    {
                        Color getcolor = getbmp.GetPixel(i, j);//取每个点颜色
                        if ((getcolor.R * 0.299) + (getcolor.G * 0.587) + (getcolor.B * 0.114) < ((meanr * 0.299) + (meang * 0.587) + (meanb * 0.114)))//颜色转灰度(可调 0-255)
                            SendBmpData[j * sendWidth / 8 + i / 8] |= setHBit[i % 8];
                        //                         if (getcolor.R < meanr)//颜色转灰度(可调 0-255)
                        //                             SendBmpData[i * sendHeight / 8 + j / 8] |= setHBit[j % 8];
                    }
                }
                getimage.Dispose();
                getbmp.Dispose();
            }
            byte[] cmd1 = new byte[] { 0X1B, 0X40, 0X1D, 0X76, 0X30 };//1B 40--初始化
            byte[] cmd2 = new byte[5];
            cmd2[0] = printMod;
            cmd2[1] = (byte)(sendWidth / 8 % 256);
            cmd2[2] = (byte)(sendWidth / 8 / 256);
            cmd2[3] = (byte)(sendHeight % 256);
            cmd2[4] = (byte)(sendHeight / 256);
            NewUsb.FindUSBPrinter();

            for (int k = 0; k < NewUsb.USBPortCount; k++)
            {

                if (NewUsb.LinkUSB(k))
                {
                    SendData2USB(cmd1);//初始化指令                                   
                    SendData2USB(cmd2);//参数设置
                    SendData2USB(SendBmpData);//位图数据

                }
            }



            uint showwide = sendWidth / 8;
            if (showwide > 48)
                showwide = 48;
            if (cb_SaveFile.Checked == true)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "文本文件(*.txt)|*.txt";
                sfd.Title = "保存的点阵文件";

                DialogResult r1 = sfd.ShowDialog();
                sfd.Dispose();
                if (r1 == DialogResult.OK)
                {
                    string savepath = sfd.FileName;

                    FileStream temp = File.Create(savepath);//TEST
                    string textstr = "";
                    int index = 0;

                    textstr += "命令:0x1B 0x40 0x1D 0x76 0x30 0x" + cmd2[0].ToString("X").PadLeft(2, '0') + " ";
                    textstr += "0x" + cmd2[1].ToString("X").PadLeft(2, '0') + " ";
                    textstr += "0x" + cmd2[2].ToString("X").PadLeft(2, '0') + " ";
                    textstr += "0x" + cmd2[3].ToString("X").PadLeft(2, '0') + " ";
                    textstr += "0x" + cmd2[4].ToString("X").PadLeft(2, '0') + " ";
                    textstr += "\r\n位图数据:\r\n";
                    foreach (byte currbyte in SendBmpData)
                    {
                        textstr += "0x" + currbyte.ToString("X").PadLeft(2, '0') + ",";
                        index++;
                        if (index == showwide)
                        {
                            textstr += "\r\n";
                            index = 0;
                        }
                    }
                    byte[] sendata = System.Text.Encoding.Default.GetBytes(textstr);
                    temp.Write(sendata, 0, sendata.Length);
                    temp.Close();
                }
            }
        }



        private void btnPrintphoto_Click(object sender, EventArgs e)
        {
            btnPrintphoto.Enabled = false;
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "位图文件(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|ALL files(*.*)|*.*";
            //             fd.InitialDirectory = Application.StartupPath + "\\Temp\\";//设定初始目录
            fd.ShowReadOnly = true;
            fd.Multiselect = true;//单选
            Thread showPicsThread = new Thread(new ParameterizedThreadStart(delegate
            {
                DialogResult r1 = fd.ShowDialog();
                fd.Dispose();

                if (r1 == DialogResult.OK)
                {
                    string[] strReadFilePaths = fd.FileNames;
                    uint sendDatabuf = 0;

                    foreach (string strReadFilePath in strReadFilePaths)
                    {
                        StreamReader srReadFile = new StreamReader(strReadFilePath);
                        byte[] byteReaddata = StreamToBytes(srReadFile.BaseStream);//获取读取文件的byte[]数据
                        srReadFile.Close();
                        byte bmpBitCount = byteReaddata[0x1c]; //获取位图 位深度
                        if (byteReaddata[0] != 'B' || byteReaddata[1] != 'M')
                        {
                            MessageBox.Show("文件不支持");
                            this.Invoke(new MethodInvoker(delegate
                            {
                                btnPrintphoto.Enabled = true;
                            }));
                            return;
                        }

                        uint byteLeght = (uint)byteReaddata.Length;
                        if (byteLeght > 1024000)
                        {
                            MessageBox.Show("所选文件过大");
                            this.Invoke(new MethodInvoker(delegate
                            {
                                btnPrintphoto.Enabled = true;
                            }));
                            return;
                        }
                        uint BMPWidth = (uint)(byteReaddata[0x15] * 0x1000000 + byteReaddata[0x14] * 0x10000 + byteReaddata[0x13] * 0x100 + byteReaddata[0x12]);
                        uint BMPHeight = (uint)(byteReaddata[0x19] * 0x1000000 + byteReaddata[0x18] * 0x10000 + byteReaddata[0x17] * 0x100 + byteReaddata[0x16]);

                        uint sendWidth = BMPWidth;      //实际发送的宽
                        uint sendHeight = BMPHeight;    //实际发送的高
                        if (BMPHeight % 8 != 0)
                            sendHeight = BMPHeight + 8 - BMPHeight % 8;
                        if (BMPWidth % 8 != 0)
                            sendWidth = BMPWidth + 8 - BMPWidth % 8;

                        sendDatabuf += 4 + sendWidth * sendHeight / 8;
                        #region lbBMPSize.Text = "已选择" + strReadFilePath.Length.ToString() + "张图片\r\n";
                        //                 if (sendDatabuf > 8096)
                        //                 {
                        //                     lbBMPSize.Text = "要发送的数据超过8096字节,请重新选择\r\n";
                        //                     lbBMPSize.Text += "已选择" + strReadFilePath.Length.ToString() + "张图片\r\n";
                        //                     disShowPic();
                        //                     strReadFilePath = new string[] { "" };
                        //                 }
                        //                 else
                        #endregion

                        byte printMod;
                        btnPrintphoto.Invoke(new MethodInvoker(delegate
                        {
                            btnPrintphoto.Enabled = true;
                            printMod = (byte)cb_1D_76_30.SelectedIndex;
                            sendGSBmpStream(strReadFilePath, printMod);
                        }));
                    }
                }
                else
                {
                    btnPrintphoto.Invoke(new MethodInvoker(delegate
                    {
                        btnPrintphoto.Enabled = true;
                    }));
                }
            }));//Thread showPicsThread
            showPicsThread.SetApartmentState(ApartmentState.STA);
            showPicsThread.Start();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        int index = 0;
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (index < imageList1.Images.Count - 1)
            {
                index = index + 1;

            }
            else
            {
                index = 0;
            }
            pictureBox1.Image = imageList1.Images[index];
        }

        private void cboUnderline_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_BackFront_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();//打开窗体
            this.Hide();
        }
    }
}

