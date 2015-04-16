using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace _2048
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Class1 c;
        _2048messageBox mes = new _2048messageBox();
        Bitmap bit = new Bitmap(400, 400);
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("D:\\2048记录")) //监测是否有存档
            {
                ToLoad();
            }
            else                             //如果没有存档，生成新的游戏。
            {
                _2048messageBox mes1 = new _2048messageBox();
                mes1.a = "提示";
                mes1.b = "    检测到您是第一次打开，可按F1打开帮助。\r\n    游戏为无限模式，直到GameOver才会终止。";
                mes1.StartPosition = FormStartPosition.CenterScreen;
                mes1.ShowDialog();
                c = new Class1();
                c.Reset();
            }
            mes.a = "提示";                   //生成帮助菜单
            mes.b = "F2:窗口总在最前\r\nF3:解锁/锁定窗口\r\nF4:隐藏任务栏图标\r\nF5:重新开始\r\nF6:截图并保存\r\nShife + ↑↓：调整透明度\r\n↑↓←→：控制方块移动\r\nESC:退出";
            drow();
            Num_pictureBox.Refresh();
        }          //窗口加载前的操作
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (e.Modifiers == Keys.Shift)
                        this.Opacity -= 0.1;
                    else
                    {
                        c.Up();
                        if (c.change)
                            c.Add();
                    }
                    break;
                case Keys.Down:
                    if (e.Modifiers == Keys.Shift)
                        this.Opacity += 0.1;
                    else
                    {
                        c.Down();
                        if (c.change)
                            c.Add();
                    }
                    break;
                case Keys.Left:
                    c.Left();
                    if (c.change)
                        c.Add();
                    break;
                case Keys.Right:
                    c.Right();
                    if (c.change)
                        c.Add();
                    break;
                case Keys.F1:
                    mes.ShowDialog();
                    break;
                case Keys.F2:
                    this.TopMost = !this.TopMost;
                    break;
                case Keys.F3:
                    if (this.FormBorderStyle == FormBorderStyle.FixedToolWindow)
                        this.FormBorderStyle = FormBorderStyle.None;
                    else
                        this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                    break;
                case Keys.F4:
                    this.ShowInTaskbar = !this.ShowInTaskbar;
                    break;
                case Keys.F5:
                    c = new Class1();
                    c.Reset();
                    Num_pictureBox.Refresh();
                    break;
                case Keys.F6:
                    _2048Screen();
                    _2048messageBox mes2 = new _2048messageBox();
                    mes2.a = "保存成功";
                    mes2.b = "保存在" + Directory.GetCurrentDirectory() + "\\成绩截图.bmp";
                    mes2.ShowDialog();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
            drow();
            Num_pictureBox.Refresh();
            grade.Text = c.grade.ToString();
            if (c.die)
            {
                gameOver();
            }
        }    //捕捉键盘按下的键，做出相应操作
        private void display(int m, Point dian)
        {
            Graphics gra = Graphics.FromImage(bit);
            switch (m)
            {
                case 0:
                    { gra.FillRectangle(new SolidBrush(Color.BurlyWood), dian.X, dian.Y, 90, 90); } break;
                case 2:
                    { gra.FillRectangle(new SolidBrush(Color.LightSalmon), dian.X, dian.Y, 90, 90); } break;
                case 4:
                    { gra.FillRectangle(new SolidBrush(Color.Peru), dian.X, dian.Y, 90, 90); } break;
                case 8:
                    { gra.FillRectangle(new SolidBrush(Color.Chocolate), dian.X, dian.Y, 90, 90); } break;
                case 16:
                    { gra.FillRectangle(new SolidBrush(Color.Gray), dian.X, dian.Y, 90, 90); } break;
                case 32:
                    { gra.FillRectangle(new SolidBrush(Color.DarkSeaGreen), dian.X, dian.Y, 90, 90); } break;
                case 64:
                    { gra.FillRectangle(new SolidBrush(Color.Gold), dian.X, dian.Y, 90, 90); } break;
                case 128:
                    { gra.FillRectangle(new SolidBrush(Color.HotPink), dian.X, dian.Y, 90, 90); } break;
                case 256:
                    { gra.FillRectangle(new SolidBrush(Color.DarkOrange), dian.X, dian.Y, 90, 90); } break;
                case 512:
                    { gra.FillRectangle(new SolidBrush(Color.LightPink), dian.X, dian.Y, 90, 90); } break;
                case 1024:
                    { gra.FillRectangle(new SolidBrush(Color.DarkRed), dian.X, dian.Y, 90, 90); } break;
                case 2048:
                    { gra.FillRectangle(new SolidBrush(Color.Red), dian.X, dian.Y, 90, 90); } break;
            }
            switch (m)
            {
                case 2:
                case 4:
                case 8:
                    gra.DrawString(m.ToString(), new Font("黑体", 40.5f, FontStyle.Bold), new SolidBrush(Color.White), dian.X + 22, dian.Y + 17);
                    break;
                case 16:
                case 32:
                case 64:
                    gra.DrawString(m.ToString(), new Font("黑体", 40.5f, FontStyle.Bold), new SolidBrush(Color.White), dian.X + 8, dian.Y + 17);
                    break;
                case 128:
                case 256:
                case 512:
                    gra.DrawString(m.ToString(), new Font("黑体", 35.5f, FontStyle.Bold), new SolidBrush(Color.White), dian.X + 0, dian.Y + 20);
                    break;
                case 1024:
                case 2048:
                case 4096:
                case 8192:
                    gra.DrawString(m.ToString(), new Font("黑体", 30.5f, FontStyle.Bold), new SolidBrush(Color.White), dian.X - 4, dian.Y + 23);
                    break;

            }
        }                      //画出一个方块和方块上的数字
        private void drow()
        {
            for (int x = 1; x <= 4; x++)
            {
                for (int y = 1; y <= 4; y++)
                {
                    Point p = new Point(x * 100 - 95, y * 100 - 95);
                    display(c.i[x, y], p);
                }
            }
        }                                          //画出每个方块

        private void gameOver()
        {
            if (c.bestGrade < c.grade)                                    //判断本次成绩是否刷新纪录
            {
                c.bestGrade = c.grade;
                bestgrade.Text = c.bestGrade.ToString();
                _2048Screen();
                _2048messageBox mes3 = new _2048messageBox();
                mes3.a = "恭喜！";
                mes3.b = "新的记录！自动为您保存截图。\r\n保存在" + bitfile;
                mes3.ShowDialog();
                c.Reset();
                drow();
                Num_pictureBox.Refresh();

            }
            else
            {
                Game_Over g = new Game_Over();
                g.bg = c.bestGrade;
                g.g = c.grade;
                DialogResult d = g.ShowDialog();
                switch (d)
                {
                    case DialogResult.Retry:
                        c.Reset();
                        drow();
                        Num_pictureBox.Refresh();
                        grade.Text = c.grade.ToString();
                        bestgrade.Text = c.bestGrade.ToString();
                        break;
                    case DialogResult.Abort:
                        _2048Screen();
                        _2048messageBox mes2 = new _2048messageBox();
                        mes2.a = "保存成功";
                        mes2.b = "保存在" + bitfile;
                        mes2.ShowDialog();
                        c.Reset();
                        classSave();
                        drow();
                        Num_pictureBox.Refresh();
                        break;
                    case DialogResult.No:
                        c.Reset();
                        this.Close();
                        break;
                }
            }
        }                                      //游戏结束时需要的操作
        private string bitfile = Directory.GetCurrentDirectory() + "\\成绩截图";//成绩截图的目录
        private void _2048Screen()
        {
            Bitmap b = new Bitmap(this.Width, this.Height);                  
            Graphics gr = Graphics.FromImage(b);
            gr.CopyFromScreen(this.Location, new Point(0, 0), this.Size); 
            gr.Dispose();
            if (!File.Exists(bitfile))  //判断截图是否已存在，如果存在，在路径后面加上一个空格继续保存，避免覆盖
                bitfile += " ";
            b.Save(bitfile+".bmp");

        }                                   //截图

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            classSave();
        }//窗口关闭后需要的操作
        private void Num_pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Num_pictureBox.BackgroundImage = bit;
            grade.Text = c.grade.ToString();
        } //显示方块的主界面的重绘事件，其中加入了刷新当前成绩的语句，确保当前成绩及时刷新
        private void classSave()
        {
            FileStream fw = new FileStream("D:\\2048记录", FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter_w = new BinaryFormatter();
            formatter_w.Serialize(fw, c);

            //File.SetAttributes("D:\\2048记录", FileAttributes.Hidden);
            fw.Close();
        }//序列化Class1类，并保存，相当于存档
        private void ToLoad()
        {
            FileStream fr = new FileStream("D:\\2048记录", FileMode.Open, FileAccess.Read);
            
            BinaryFormatter formatter_r = new BinaryFormatter();
            c = (Class1)formatter_r.Deserialize(fr);
            grade.Text = c.grade.ToString();
            bestgrade.Text = c.bestGrade.ToString();
            fr.Close();
            
        }//从文件反序列化读取存档




        //退出前加一个确认的选项
        //private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    DialogResult res = MessageBox.Show("是否退出？", "提示",
        //                       MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
        //    if (res == DialogResult.OK)
        //    {
        //        e.Cancel = false;
        //    }
        //    else
        //    {
        //        e.Cancel = true;
        //    }
        //}
    }
}