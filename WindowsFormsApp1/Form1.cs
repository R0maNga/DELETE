using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.Series[0].Points.Clear();
            int N = 128;
            for (int i = 0; i < N; i++)
            {
                chart1.Series[0].Points.AddXY(i, Math.Cos((2* Math.PI / N)*3*i));
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Filter = "Текстовые файлы (*.txt) | *.txt*";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    System.IO.StreamReader fileStream = new System.IO.StreamReader(fDialog.OpenFile());
                    String sData = fileStream.ReadToEnd();
                    fileStream.Close();
                    fDialog.Dispose();
                    sData = sData.Replace('.', ',');
                    String[] substrings = sData.Split(new char[] { ' ', '\r', '\n' });
                    this.textBox1.Text = System.String.Empty;
                    uint unIndex = 1;
                    groupBox1.Enabled = false;
                    chart1.Series[0].Points.Clear();
                    foreach (String substring in substrings)
                    {
                        if (!String.IsNullOrEmpty(substring))
                        {
                            double dblData = Math.Round(double.Parse(substring), 4);
                            chart1.Series[0].Points.AddXY(unIndex, dblData);
                            this.textBox1.Text += ("" + (unIndex++) + ".\t" + dblData.ToString() + "\r\n");

                        }
                    }
                    groupBox1.Enabled = true;



                }
                catch (System.Exception ex)
                { 
                }
            }
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
