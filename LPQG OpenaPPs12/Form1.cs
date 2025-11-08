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
using System.Runtime.CompilerServices;
// I want to leave this app but i feel something is wrong with my app so i forced myself to repair it (sorry for lying to all my non-existent fans)

namespace LPQG_OpenaPPs12
{

    public partial class Form1 : Form
    {
        private string selectedExePath = string.Empty;
        private string selectedapp = string.Empty;
        private string Argumentation = string.Empty;
        private List<bool> checklist = new List<bool>() { false, false, false };
        public int admin;

        public Form1()
        {
            

            admin = 0;
            InitializeComponent();
            button3.Hide();
            enableLightModeToolStripMenuItem.Visible = false;

            // Default Dark Mode
            this.BackColor = Color.FromArgb(25, 25, 25);
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            checkBox1.ForeColor = Color.White;
            button3.BackColor = Color.Black;
            button3.ForeColor = Color.FromArgb(240, 240, 240);
            enableLightModeToolStripMenuItem.Visible = true;
            enableDarkModeToolStripMenuItem.Visible = false;
            textBox1.BackColor = Color.Black;
            textBox1.ForeColor = Color.FromArgb(240, 240, 240);
            textBox2.BackColor = Color.Black;
            textBox2.ForeColor = Color.FromArgb(240, 240, 240);
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
                admin = 1;
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

                    MessageBox.Show("App started with arguments: " + Argumentation,
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

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void enableDarkModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(25, 25, 25);
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            checkBox1.ForeColor = Color.White;
            button3.BackColor = Color.Black;
            button3.ForeColor = Color.FromArgb(240, 240, 240);
            enableLightModeToolStripMenuItem.Visible = true;
            enableDarkModeToolStripMenuItem.Visible = false;
            textBox1.BackColor = Color.Black;
            textBox1.ForeColor = Color.FromArgb(240, 240, 240);
            textBox2.BackColor = Color.Black;
            textBox2.ForeColor = Color.FromArgb(240, 240, 240);
        }

        private void enableLightModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(240, 240, 240);
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            
            checkBox1.ForeColor = Color.Black;
            button3.BackColor = Color.White;
            button3.ForeColor = Color.White;
            enableDarkModeToolStripMenuItem.Visible = true;
            enableLightModeToolStripMenuItem.Visible = false;
            textBox1.BackColor = Color.White;
            textBox1.ForeColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox2.ForeColor = Color.White;
        }

        private void heToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();  // create a new instance of Form2
            form2.Show();               // open it (non-blocking)
            

        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Payo64/FrayoEX-AppOpener-Synced/issues/new");
        }
    }
}
