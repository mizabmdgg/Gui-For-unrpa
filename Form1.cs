using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace RpaDecompiler
{
    public partial class main : Form
    {



        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        public string folderout;
        public string filerpa;


        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void out_btn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string selectedPath = dialog.SelectedPath;
                    // Here you can use selectedPath variable to get the selected folder path
                    label2.Text = selectedPath;
                    folderout = selectedPath;
                }
            }

        }
        private void in_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "RenPy Archive (*.rpa)|*.rpa"; // Filter to select all files

                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string selectedFile = dialog.FileName;
                    // Here you can use selectedFile variable to get the selected file path
                    label3.Text = selectedFile;
                    filerpa = selectedFile;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("So First Check If Installed 'unrpa' and python 3, Click 'Ok' To Open GitHub 'unrpa' ", "FaQ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start("https://github.com/Lattyware/unrpa");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (filerpa != null & folderout != null)
            {
                if (Directory.Exists(folderout)) 
                {
                    if (File.Exists(filerpa)) 
                    {
                        Process.Start("cmd.exe", $"/C py -3 -m unrpa -mp {folderout} {filerpa} ");
                        MessageBox.Show("Done! ( If You Dont See Anyting In The Folder There Must Be Error )", "YAY!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
                else
                {
                if (filerpa == null & folderout == null) { MessageBox.Show("Please Choose The Out Folder And In File!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    else
                    {
                        if (folderout == null) { MessageBox.Show("Please Choose The Out Folder!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                        if (filerpa == null) { MessageBox.Show("Please Choose The In File!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
        }
    }
}

// made by miza 4 people
// github: https://github.com/mizabmdgg