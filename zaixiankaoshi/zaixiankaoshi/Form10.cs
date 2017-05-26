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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 ip = new Class1();
            string getWeatherUrl = "http://" + ip.getip() + "/kaoshixitong/deleteyonghu.jsp?id=" + textBox1.Text;
            WebRequest webReq = WebRequest.Create(getWeatherUrl);
            webReq.Timeout = 2000;
            WebResponse webResp = webReq.GetResponse();
            Stream stream = webResp.GetResponseStream();
            StreamReader sr = new StreamReader(stream, Encoding.GetEncoding("GBK"));
            string html = sr.ReadToEnd().Trim();
            sr.Close();
            stream.Close();
            if (html == "false")
            {
                MessageBox.Show("题号不存在");
            }
            else
            {
                MessageBox.Show("删除成功");
            }
        }
    }
}
