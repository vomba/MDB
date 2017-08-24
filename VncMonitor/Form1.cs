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

        String S, PS;
        Screen SS;
        int PSH,PSW,WS,NS=1,SWH,SWW,NX,NY;

        Calculations Calc = new Calculations();

        private void ScreenWork()
        {
            SS = Calc.PrimaryScreen();
            PSH = Calc.PrimaryScreenHeight(SS);
            PSW = Calc.PrimaryScreenWidth(SS);
            WS = Calc.WindowSize(PSH, PSW, NS);
            SWH = Calc.SoftwindowHeight(WS);
            SWW = Calc.Softwindowwidth(WS);
            NX = Calc.WindowsX(PSH, SWH);
            NY = Calc.WindowsX(PSW, SWW);
        }

        
        

       


        

       
        
        private void button1_Click(object sender, EventArgs e)
        {

            
            int x=-SWW, y=0;


            for(int i=0;i<NY; i++)
            { 
                for(int j=0; j<NX; j++ )
                {


                    Process P = Process.Start(S);
                    // Process P = Process.Start(S,"-File "+PS);

                    while (P.MainWindowHandle == IntPtr.Zero)
                    Application.DoEvents();

                    MoveWindow(P.MainWindowHandle, x+ SWW, y, SWW, SWH, true);
                    SetWindowText(P.MainWindowHandle, ""+i+" "+j);
                    x += SWW;
               
                }
                x = -SWW;
                y += SWH;
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

            Form1_Load(sender, e);


        }

       


        private void Form1_Load(object sender, EventArgs e)
        {
            try { 
            // TODO: cette ligne de code charge les données dans la table 'azureStorageEmulatorDb51DataSet.MachineSet'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.machineSetTableAdapter.Fill(this.azureStorageEmulatorDb51DataSet.MachineSet);
            }catch(Exception Ex)
            {
               
            }
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

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            PS = openFileDialog1.FileName;
           // NS = openFileDialog1.FileNames.Length;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           // S = openFileDialog1.FileName;
        }
    }
}
