using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.ComponentModel.Design;

namespace LPQG_OpenaPPs12
{

    public partial class Form1 : Form
    {
        private string selectedExePath = string.Empty;
        private string selectedapp = string.Empty;
        private string Argumentation = string.Empty;
        private List<bool> checklist = new List<bool>() { false, false, false };


        public Form1()
        {
            InitializeComponent();
            button3.Hide();
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checklist[1] = checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Argumentation = textBox1.Text;
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog op = new OpenFileDialog() { Filter = "Windows EXE|*.exe" })
            {
                
                

                if (op.ShowDialog() == DialogResult.OK)
                {
                    selectedExePath = op.FileName;
                    selectedapp = Path.GetFileName(op.FileName);  // store the file path
                    string exe;
                    exe = op.FileName;
                    
                    
                    { textBox2.Text = selectedapp; textBox2.Refresh(); button3.Show(); ; }
                    MessageBox.Show(" App Selected!",
                                    "Open", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    

                }
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = selectedExePath;
                startInfo.Arguments = Argumentation;
                startInfo.WorkingDirectory = Path.GetDirectoryName(selectedExePath);

                // run as admin
                startInfo.UseShellExecute = true;
                startInfo.Verb = "runas";

                try
                {
                    Process.Start(startInfo);
                    MessageBox.Show("App started as Administrator with arguments: " + Argumentation,
                                    "LQPG App Opener", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Win32Exception)
                {
                    MessageBox.Show("Administrator privileges were denied.",
                                    "LQPG App Opener", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                

            }

            else 
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = selectedExePath;
                startInfo.Arguments = Argumentation;
                startInfo.WorkingDirectory = Path.GetDirectoryName(selectedExePath);

                // run as admin
                startInfo.UseShellExecute = false;
                startInfo.Verb = "runas";

                try
                {
                    Process.Start(startInfo);
                    MessageBox.Show("App started as Administrator with arguments: " + Argumentation,
                                    "LQPG App Opener", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    if (ex.NativeErrorCode == 740) // ERROR_ELEVATION_REQUIRED
                    {
                        MessageBox.Show("This app requires administrator privileges by default please checked the 'Administrator' checkbox to run the app.",
                                        "Admin Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        throw;
                    }

                }
            }

            







        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
