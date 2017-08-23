using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VncMonitor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String S;

        private void button1_Click(object sender, EventArgs e)
        {
            int x=-200, y=0;
            for(int i=0;i<4;i++)
            { 
                for(int j=0; j<5; j++ )
                {

                
            Process P = Process.Start(S);
            while (P.MainWindowHandle == IntPtr.Zero)
                Application.DoEvents();

            MoveWindow(P.MainWindowHandle, x+200, y, 200, 200, true);
                    SetWindowText(P.MainWindowHandle, ""+i+" "+j);
                x += 200;
               
                }
                x = -200;
                y += 200;
            }
            /*Process P1 = Process.Start("C:\\Program Files\\VideoLAN\\VLC\\vlc.exe");
            while (P1.MainWindowHandle == IntPtr.Zero)
                Application.DoEvents();

            MoveWindow(P1.MainWindowHandle, 201, 0, 200, 200, true);*/

        }

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll", SetLastError = true)]
        static extern void SetWindowText(IntPtr hWnd, string windowName);

       private void Button2_Click(object sender, EventArgs e)
        {
            Machine M = new Machine();
            M.Nom = textBox1.Text;
            M.Id += 1;

            using (var db = new DBContainer())
            {
                db.MachineSet.Add(M);
                db.SaveChanges();
            }

            this.machineSetTableAdapter.Fill(this.azureStorageEmulatorDb51DataSet.MachineSet);


        }

       


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'azureStorageEmulatorDb51DataSet.MachineSet'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.machineSetTableAdapter.Fill(this.azureStorageEmulatorDb51DataSet.MachineSet);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var RM = new Machine { Id = Convert.ToInt32(textBox1.Text) };

            using (var db = new DBContainer())
            {
                db.MachineSet.Attach(RM);
                db.MachineSet.Remove(RM);
                db.SaveChanges();
            }

            Form1_Load(sender,e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            S = openFileDialog1.FileName;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           // S = openFileDialog1.FileName;
        }
    }
}
