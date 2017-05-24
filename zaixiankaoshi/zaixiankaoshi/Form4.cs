using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace zaixiankaoshi
{
    public partial class Form4 : Form
    {
        string[] str;
        int i = 0;
        public Form4()
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
            str =html.Split('@');
            sr.Close();
            stream.Close();
            label2.Text = str[i+1];
            radioButton1.Text = str[i + 2];
            radioButton2.Text = str[i + 3];
            radioButton3.Text = str[i + 4];
            radioButton4.Text = str[i + 5];
            label5.Text = str[i];
            label6.Text = str[i+6];
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
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
                label5.Text = str[i];
                label6.Text = str[i + 6];
            }
        }

        private void button5_Click(object sender, EventArgs e)
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
                label5.Text = str[i];
                label6.Text = str[i + 6];
            }
        }
    }
}
