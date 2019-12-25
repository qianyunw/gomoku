using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
namespace WindowsFormsApplication1
{
    public partial class Form6 : Form
    {
        public static int beijing=1;
        public int i,j;
		public bool blnBegin;
		public static int time=1;
        public static int inthuiqi = 0;
		//建立全棋盘数组
        public int[,] WuZi = new int[17, 17];
        //建立picturebox数组
        public PictureBox[] list = new PictureBox[300];
        public static int realtime = 1;



        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            Form3 f3 = (Form3)(this.Owner);
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        



        public static int n = 1;
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (n % 2 == 1)
            {
                pictureBox2.Visible = true;
                button2.Text = "继续游戏";
                Image img2 = Image.FromFile(@"F:\五子棋\终极小白鼠\WindowsFormsApplication1\WindowsFormsApplication1\\6.jpg");
                pictureBox2.Image = img2;
                
                n++;
            }
            else
            {
                pictureBox2.Visible = false;
                button2.Text = "暂停游戏";
                n++;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        
        }
        //落子并判断输赢
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox[] pb = new PictureBox[2];
			pb[0]=new PictureBox();
			pb[1]=new PictureBox();
            list[time]=new PictureBox();
            Image img0 = Image.FromFile(Application.StartupPath + "\\红.png");
            Image img1 = Image.FromFile(Application.StartupPath + "\\绿.png");
			pb[0].Image=img0;
			pb[1].Image=img1;
            if(time%2==0)
                list[time].Image=img0;
            else
                list[time].Image=img1;

			int gen_m,gen_n,yu_m,yu_n,x,y;

            gen_m = (e.X - 15) / 30;
            gen_n = (e.Y - 15) / 30;
            yu_m = (e.X - 15) % 30;
            yu_n = (e.Y - 15) % 30;
            if (yu_m > 15)
                gen_m++;
            if (yu_n > 15)
                gen_n++;
            x = 15 + gen_m * 30;
            y = 15 + gen_n * 30;
            if (time == 1)
                {
                    for (i = 0; i < 17; i++)
                    {
                        for (j = 0; j < 17; j++)
                        {
                            WuZi[i, j] = -1;
                        }
                    }
                }
                  
            //落子后若正确则判断输赢

            if (gen_m <= 0 || gen_m >= 16 || gen_n <= 0 || gen_n >= 15)
            {
                MessageBox.Show("对不起，您已越界！请重下...");

            }
            
            else
            {
                
                

                list[time].Location = new Point(x - 8, y - 8);

                list[time].Size = new Size(19, 19);
                this.panel1.Controls.Add(list[time]);
                WuZi[gen_m, gen_n] = time % 2;

                bool win = false;
                Graphics gg = panel1.CreateGraphics();
                int start_m = Math.Max(gen_m - 4, 1), start_n = gen_n;
                int end_m = Math.Min(16, gen_m + 4), end_n = gen_n;
                Point winstart=new Point(0,0);

                Point winend = new Point(0, 0); 
                if (end_m - start_m >= 4)
                {
                    for (i = 0; i <= Math.Min(end_m - start_m - 4, 4); i++)
                    {
                        if (WuZi[start_m + i, start_n] == time % 2 && WuZi[start_m + 1 + i, start_n] == time % 2 && WuZi[start_m + 2 + i, start_n] == time % 2 && WuZi[start_m + 3 + i, start_n] == time % 2 && WuZi[start_m + 4 + i, start_n] == time % 2)
                        {
                            win = true;
                            winstart = new Point(15 + (start_m + i) * 30, 15 + start_n * 30);
                            winend = new Point(15 + (start_m + 4 + i) * 30, 15 + start_n * 30);
                            
                            break;
                        }
                    }
                }

                start_n = Math.Max(gen_n - 4, 1); start_m = gen_m;
                end_n = Math.Min(16, gen_n + 4); end_m = gen_m;
                if (end_n - start_n >= 4)
                {
                    for (i = 0; i <= Math.Min(end_n - start_n - 4, 4); i++)
                    {
                        if (WuZi[start_m, start_n + i] == time % 2 && WuZi[start_m, start_n + 1 + i] == time % 2 && WuZi[start_m, start_n + 2 + i] == time % 2 && WuZi[start_m, start_n + 3 + i] == time % 2 && WuZi[start_m, start_n + 4 + i] == time % 2)
                        {
                            win = true;
                            winstart = new Point(15 + start_m * 30, 15 + (start_n + i) * 30);
                            winend = new Point( 15 + start_m * 30,15 + (start_n + 4 + i) * 30);

                            break;
                        }
                    }
                }

                start_m = gen_m - Math.Min(Math.Min(4, gen_m - 1), Math.Min(4, gen_n - 1)); start_n = gen_n - Math.Min(Math.Min(4, gen_m - 1), Math.Min(4, gen_n - 1));
                end_m = gen_m + Math.Min(Math.Min(4, 16 - gen_m), Math.Min(4, 16 - gen_n)); end_n = gen_n + Math.Min(Math.Min(4, 16 - gen_m), Math.Min(4, 16 - gen_n));
                if (end_m - start_m >= 4)
                {
                    for (i = 0; i <= Math.Min(end_n - start_n - 4, 4); i++)
                    {
                        if (WuZi[start_m + i, start_n + i] == time % 2 && WuZi[start_m + 1 + i, start_n + 1 + i] == time % 2 && WuZi[start_m + 2 + i, start_n + 2 + i] == time % 2 && WuZi[start_m + 3 + i, start_n + 3 + i] == time % 2 && WuZi[start_m + 4 + i, start_n + 4 + i] == time % 2)
                        {
                            win = true;

                            winstart = new Point(15+(start_m + i)*30, 15+(start_n + i)*30);
                            winend = new Point(15 + (start_m + i+4) * 30, 15 + (start_n + i+4) * 30);
                            break;
                        }
                    }
                }


                start_m = gen_m + Math.Min(Math.Min(4, 16 - gen_m), Math.Min(4, gen_n - 1)); start_n = gen_n - Math.Min(Math.Min(4, 16 - gen_m), Math.Min(4, gen_n - 1));
                end_m = gen_m - Math.Min(Math.Min(4, gen_m - 1), Math.Min(4, 16 - gen_n)); end_n = gen_n + Math.Min(Math.Min(4, gen_m - 1), Math.Min(4, 16 - gen_n));
                for (i = 0; i <= Math.Min(end_n - gen_n, 4); i++)
                {
                    if (WuZi[start_m - i, start_n + i] == time % 2 && WuZi[start_m - 1 - i, start_n + 1 + i] == time % 2 && WuZi[start_m - 2 - i, start_n + 2 + i] == time % 2 && WuZi[start_m - 3 - i, start_n + 3 + i] == time % 2 && WuZi[start_m - 4 - i, start_n + 4 + i] == time % 2)
                    {
                        win = true;


                        winstart = new Point(15 + (start_m - i) * 30, 15 + (start_n + i) * 30);
                        winend = new Point(15 + (start_m - i - 4) * 30, 15 + (start_n + i + 4) * 30);
                        break;
                    }
                }

                if (win && time % 2 == 0)
                {
                    
                    Pen pen2 = new Pen(Color.OrangeRed, 7);
                    gg.DrawLine(pen2, winstart, winend);
                    Thread.Sleep(1000);
                    MessageBox.Show("白手赢！");

                }

                else if (win && time % 2 == 1)
                {
                    Pen pen2 = new Pen(Color.GreenYellow, 7);
                    gg.DrawLine(pen2, winstart, winend);
                    Thread.Sleep(1000);
                    MessageBox.Show("黑手赢！");
                }

                time++;
            }
        

        }
        //悔棋

        private void button3_Click(object sender, EventArgs e)
        {
            if(time<2)
                MessageBox.Show("对不起，您没有棋可以悔呦~");
            else 
                {
                 panel1.Controls.Remove(list[time-1]);
                time--;
                }
        }




        //音效
        public static int m=1;
        private void button4_Click(object sender, EventArgs e)
        {
            
            if (m % 2 == 1)
            {
                button4.Text = "音乐||";
                System.Media.SoundPlayer sound;
                if (beijing == 2 )
                {
                    sound = new System.Media.SoundPlayer(Application.StartupPath + "\\五子棋 背景2.wav");
                    realtime = 0;
                }
                else if (beijing == 3 )
                {
                    sound = new System.Media.SoundPlayer(Application.StartupPath + "\\五子棋 背景3.wav");
                    realtime = 0;
                }
                else
                    sound = new System.Media.SoundPlayer(Application.StartupPath + "\\五子棋 背景1.wav");

                sound.Play();
                m++;
            }
            else
            {
                System.Media.SoundPlayer sound;
                button4.Text = "音乐...";
                if (beijing == 2)
                {
                    sound = new System.Media.SoundPlayer(Application.StartupPath + "\\五子棋 背景2.wav");
                    realtime = 0;
                }
                else if (beijing == 3 )
                {
                    sound = new System.Media.SoundPlayer(Application.StartupPath + "\\五子棋 背景3.wav");
                    realtime = 0;
                }
                else
                    sound = new System.Media.SoundPlayer(Application.StartupPath + "\\五子棋 背景1.wav");

                sound.Stop();
                m++;
            }
        }


        //重玩
        private void button5_Click(object sender, EventArgs e)
        {
            while (time != 1)
            {
                list[time - 1].Visible = false;
                time--;
           
            }
            for (i = 0; i < 17; i++)
            {
                for (j = 0; j < 17; j++)
                {
                    WuZi[i, j] = -1;
                }
            }
            this.panel1.Controls.Clear();
        }


        //退出游戏
        private void button6_Click(object sender, EventArgs e)
        {
           //  MessageBox.Show("退出游戏？","Exit",MessageBoxButtons.YesNoCancel);
            
            DialogResult dr = MessageBox.Show("退出游戏？", "Exit", MessageBoxButtons.YesNoCancel);
            if (dr == DialogResult.Yes)
            {
                this.Close();
                while (time != 1)
                {
                    list[time - 1].Visible = false;
                    time--;

                }
                for (i = 0; i < 17; i++)
                {
                    for (j = 0; j < 17; j++)
                    {
                        WuZi[i, j] = -1;
                    }
                }
                this.panel1.Controls.Clear();

               // Form1.
            }
        
        }
        //画棋盘
        
        private void Form6_Paint(object sender, PaintEventArgs e)
        {
            if (beijing==2&&realtime==1)
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\背景2.jpg");
                realtime = 0;
            }
            else if (beijing == 3 && realtime == 1)
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\背景3.jpg");
                realtime = 0;
            }
            int i;
            Pen pen = new Pen(Color.DarkGoldenrod, 2);
            Graphics g = panel1.CreateGraphics();
            for (i = 0; i < 17; i++)
            {
                Point start = new Point(15, i * 30 + 15);
                Point end = new Point(start.X + 16 * 30, start.Y);
                g.DrawLine(pen, start, end);
            }

            for (i = 1; i < 16; i++)
            {
                Point start = new Point(i * 30 + 15, 15);
                Point end = new Point(start.X, start.Y + 15 * 30);
                g.DrawLine(pen, start, end);
            }
            Pen pen1 = new Pen(Color.DarkOliveGreen, 2);
            Point zuoshang = new Point(15, 15);
            Point zuoxia = new Point(15, 15 + 15 * 30);
            Point youshang = new Point(15 + 16 * 30, 15);
            Point youxia = new Point(15 + 16 * 30, 15 + 15 * 30);
            g.DrawLine(pen1, zuoshang, zuoxia);
            g.DrawLine(pen1, youshang, youxia);
            g.DrawLine(pen1, zuoshang, youshang);
            g.DrawLine(pen1, zuoxia, youxia);
        }
        [DllImport("user32.dll")]
        static extern bool LockWindowUpdate(IntPtr hWndLock);
        private void Form6_ResizeBegin(object sender, EventArgs e)
        {
            LockWindowUpdate(this.Handle);
        }

        private void Form6_ResizeEnd(object sender, EventArgs e)
        {
            LockWindowUpdate(IntPtr.Zero);
        }

    }
}
