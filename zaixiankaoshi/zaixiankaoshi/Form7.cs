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
    public partial class Form7 : Form
    {
        String type = "1";
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1 ip = new Class1();
            type = "1";
            string getWeatherUrl = "http://" + ip.getip() + "/kaoshixitong/delete.jsp?num="+textBox1.Text+"&type="+type;
            WebRequest webReq = WebRequest.Create(getWeatherUrl);
            webReq.Timeout = 2000;
            WebResponse webResp = webReq.GetResponse();
            Stream stream = webResp.GetResponseStream();
            StreamReader sr = new StreamReader(stream, Encoding.GetEncoding("GBK"));
            string html = sr.ReadToEnd();
            sr.Close();
            stream.Close();
            if (html.Trim().Equals("false"))
            {
                MessageBox.Show("题号不存在");
            }
            else 
            {
                label3.Text = html.Trim();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 ip = new Class1();
            type = "2";
            string getWeatherUrl = "http://" + ip.getip() + "/kaoshixitong/delete.jsp?num=" + textBox1.Text + "&type=" + type;
            WebRequest webReq = WebRequest.Create(getWeatherUrl);
            webReq.Timeout = 2000;
            WebResponse webResp = webReq.GetResponse();
            Stream stream = webResp.GetResponseStream();
            StreamReader sr = new StreamReader(stream, Encoding.GetEncoding("GBK"));
            string html = sr.ReadToEnd();
            sr.Close();
            stream.Close();
            if (html.Trim().Equals("false"))
            {
                MessageBox.Show("题号不存在");
            }
            else if (html.Trim().Equals("true"))
            {
                MessageBox.Show("删除成功");
            }
        }
    }
}
