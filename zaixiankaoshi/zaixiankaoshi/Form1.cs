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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string type = "2";
            if (radioButton1.Checked)
            {
                type = "2";
            }
            else 
            {
                type = "1";
            }
            Class1 ip = new Class1();
            string getWeatherUrl = "http://"+ip.getip()+"/kaoshixitong/denglu.jsp?id=" + textBox1.Text + "&pwd="
                + textBox2.Text + "&type="
                + type;
                WebRequest webReq = WebRequest.Create(getWeatherUrl);
                webReq.Timeout = 2000;
                WebResponse webResp = webReq.GetResponse();
                Stream stream = webResp.GetResponseStream();
                StreamReader sr = new StreamReader(stream, Encoding.GetEncoding("GBK"));
                string html = sr.ReadToEnd();
                sr.Close();
                stream.Close();
                if (html.Trim().Equals("true"))
                {
                    if (type.Equals("2"))
                    {
                        Form2 f = new Form2();
                        this.Hide();
                        f.Show();
                    }
                    else 
                    {
                        Form3 f = new Form3();
                        this.Hide();
                        f.Show();
                    }
                }
               
            
           

        }
    }
}
