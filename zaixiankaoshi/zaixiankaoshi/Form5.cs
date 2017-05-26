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
using System.Web;
namespace zaixiankaoshi
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 ip = new Class1();
            String que =System.Web.HttpUtility.UrlEncode(textBox1.Text, System.Text.Encoding.UTF8);
            String a = System.Web.HttpUtility.UrlEncode(textBox2.Text, System.Text.Encoding.UTF8);
            String b = System.Web.HttpUtility.UrlEncode(textBox3.Text, System.Text.Encoding.UTF8);
            String c = System.Web.HttpUtility.UrlEncode(textBox4.Text, System.Text.Encoding.UTF8);
            String d = System.Web.HttpUtility.UrlEncode(textBox5.Text, System.Text.Encoding.UTF8); 
            string getWeatherUrl = "http://" + ip.getip() + "/kaoshixitong/addquestion.jsp?num="
                + textBox7.Text + "&question=" + que + "&a=" + a + "&b="
                + b + "&c=" + c + "&d=" + d + "&answer=" + textBox6.Text;
            //getWeatherUrl=System.Web.HttpUtility.UrlEncode(getWeatherUrl, System.Text.Encoding.UTF8); 
            WebRequest webReq = WebRequest.Create(getWeatherUrl);
            webReq.Timeout = 2000;
            //webReq.ContentType = "text/html; charset=utf-8";
            WebResponse webResp = webReq.GetResponse();
            Stream stream = webResp.GetResponseStream();
            StreamReader sr = new StreamReader(stream, Encoding.GetEncoding("UTF-8"));
            string html = sr.ReadToEnd().Trim();
            sr.Close();
            stream.Close();
            if (html == "false") 
            {
                MessageBox.Show("题号已存在");
            }
            else
            {
                MessageBox.Show("添加成功");
            }
        }
    }
}
