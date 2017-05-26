﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections;
namespace zaixiankaoshi
{
    public partial class Form6 : Form
    {
        string[] str1;
        string[] str = new String[70];
        ArrayList data = new ArrayList();
        int i=0;
        int flag = 0;
        public Form6()
        {
            InitializeComponent();
            Class1 ip = new Class1();
            string getWeatherUrl = "http://" + ip.getip() + "/kaoshixitong/question.jsp";
            WebRequest webReq = WebRequest.Create(getWeatherUrl);
            webReq.Timeout = 2000;
            WebResponse webResp = webReq.GetResponse();
            Stream stream = webResp.GetResponseStream();
            StreamReader sr = new StreamReader(stream, Encoding.GetEncoding("UTF-8"));
            string html = sr.ReadToEnd().Trim();
            str1 =html.Split('@');
            sr.Close();
            stream.Close();
            int[] a = new int[10];
            Random ran = new Random();
            for(int i1=0;i1<10;i1++)
            {
                a[i1]=ran.Next(0,str1.Length-1);
                for (int i2 = 0; i2 < i1;i2++ )
                {
                    if(a[i2]/7*7==a[i1]/7*7)
                    {
                        a[i1] = ran.Next(0, str1.Length - 1);
                        i2 = -1;
                    }
                }
            }
            for (int i3=0; i3 < 10;i3++ )
            {
                str[i3*7] = str1[a[i3]/7*7];
                str[i3 * 7+1] = str1[(a[i3] / 7*7)+1];
                str[i3 * 7+2] = str1[(a[i3] / 7*7)+2];
                str[i3 * 7+3] = str1[(a[i3] / 7*7)+3];
                str[i3 * 7+4] = str1[(a[i3] / 7*7)+4];
                str[i3 * 7+5] = str1[(a[i3] / 7*7)+5];
                str[i3 * 7+6] = str1[(a[i3] / 7*7)+6];

            }

            label2.Text = str[i+1];
            radioButton1.Text = str[i + 2];
            radioButton2.Text = str[i + 3];
            radioButton3.Text = str[i + 4];
            radioButton4.Text = str[i + 5];
            for (int j = 0; j < str.Length/7;j++ )
            {
                data.Add("");
            }
            
        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((i+8)>=str.Length)
            {
                MessageBox.Show("已经到底啦");
            }
            else
            {
                i += 7;
                label2.Text = str[i + 1];
                radioButton1.Text = str[i + 2];
                radioButton2.Text = str[i + 3];
                radioButton3.Text = str[i + 4];
                radioButton4.Text = str[i + 5];
                String str1 = "";
                str1 += data[i / 7];
                if (str1 == "A")
                {
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                }else
                if (str1 == "B")
                {
                    radioButton2.Checked = true;
                    radioButton1.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                }else
                if (str1 == "C")
                {
                    radioButton3.Checked = true;
                    radioButton2.Checked = false;
                    radioButton1.Checked = false;
                    radioButton4.Checked = false;
                } else
                    if (str1 == "D")
                    {
                        radioButton4.Checked = true;
                        radioButton2.Checked = false;
                        radioButton3.Checked = false;
                        radioButton1.Checked = false;
                    }
                    else 
                    {
                        radioButton4.Checked = false;
                        radioButton2.Checked = false;
                        radioButton3.Checked = false;
                        radioButton1.Checked = false;
                    }
                if (flag == 1)
                {
                    if (data[i / 7].Equals(str[i + 6]))
                    {
                        label3.Text = "答案：" + str[i + 6] + "   √";
                    }
                    else
                    {
                        label3.Text = "答案：" + str[i + 6] + "   ×";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if ((i-7) < 0)
            {
                MessageBox.Show("已经到头啦");
            }
            else 
            {
                i-=7;
                label2.Text = str[i + 1];
                radioButton1.Text = str[i + 2];
                radioButton2.Text = str[i + 3];
                radioButton3.Text = str[i + 4];
                radioButton4.Text = str[i + 5];
                String str1 ="";
                str1 += data[i / 7];
                if (str1 == "A")
                {
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                }
                if (str1 == "B")
                {
                    radioButton2.Checked = true;
                    radioButton1.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                }
                if (str1 == "C")
                {
                    radioButton3.Checked = true;
                    radioButton2.Checked = false;
                    radioButton1.Checked = false;
                    radioButton4.Checked = false;
                }
                if (str1 == "D")
                {
                    radioButton4.Checked = true;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton1.Checked = false;
                }
                if (flag == 1)
                {
                    if (data[i / 7].Equals(str[i + 6]))
                    {
                        label3.Text = "答案：" + str[i + 6] + "   √";
                    }
                    else
                    {
                        label3.Text = "答案：" + str[i + 6] + "   ×";
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(flag==0){
            flag = 1;
            int score = 0;
            for (int j = 0; (j+7) < str.Length+1;j+=7 )
            {
                if (data[j / 7].Equals(str[j+6])) 
                {
                    score += 1;
                }

            }
            MessageBox.Show("本次测试得分为"+score.ToString()+"分");
            i = 0;
            label2.Text = str[1];
            radioButton1.Text =str[2];
            radioButton2.Text = str[3];
            radioButton3.Text = str[4];
            radioButton4.Text = str[5];
            String str1 = "";
            str1 += data[0];
            if (str1 == "A")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
            }
            else
                if (str1 == "B")
                {
                    radioButton2.Checked = true;
                    radioButton1.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                }
                else
                    if (str1 == "C")
                    {
                        radioButton3.Checked = true;
                        radioButton2.Checked = false;
                        radioButton1.Checked = false;
                        radioButton4.Checked = false;
                    }
                    else
                        if (str1 == "D")
                        {
                            radioButton4.Checked = true;
                            radioButton2.Checked = false;
                            radioButton3.Checked = false;
                            radioButton1.Checked = false;
                        }
                        else
                        {
                            radioButton4.Checked = false;
                            radioButton2.Checked = false;
                            radioButton3.Checked = false;
                            radioButton1.Checked = false;
                        }
            if (data[i / 7].Equals(str[i + 6]))
            {
                label3.Text = "答案：" + str[i + 6] + "   √";
            }
            else 
            {
                label3.Text = "答案：" + str[i + 6] + "   ×";
            }
           }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            data[i/7] = "A";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            data[i / 7] = "B";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            data[i / 7] = "C";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            data[i / 7] = "D";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
        
    }
}
