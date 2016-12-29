using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Network_Pinger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string q = "";
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            MessageBox.Show("Sending data to " + textBox1.Text+". Please wait!");
            System.Diagnostics.Process process = new System.Diagnostics.Process();

            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C ping " + textBox1.Text;
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.Start();
          
            while (!process.HasExited)
            {
               // progressBar1.Value = 20;
                q += process.StandardOutput.ReadToEnd();
            }
         //   label1.Text = q;
            MessageBox.Show("Completed. Click the Result, to view");
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = q; 
            progressBar1.Visible = false;
            groupBox1.Text = "Result for "+textBox1.Text;  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter a correct IP address or domain. ex - 192.168.1.1");
            }
            else
            {
                progressBar1.Visible = true;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Clear();

           

        }
    }
}
