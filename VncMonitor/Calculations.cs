using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VncMonitor
{
    class Calculations
    {

       

        public Screen PrimaryScreen()
        {
            return Screen.PrimaryScreen;
        }

        public int PrimaryScreenHeight(Screen S)
        {
            return S.Bounds.Height;
        }

        public int PrimaryScreenWidth(Screen S)
        {
            return S.Bounds.Width;
        }

        public int WindowSize(int H, int W, int NS)
        {
            return H * W / NS;
        }

        public int SoftwindowHeight(int Size)
        {
            return Size * 9 / 17;
        }

        public int Softwindowwidth(int Size)
        {
            return Size * 16 / 10;
        }

        public int WindowsX(int H, int SFH)
        {
            return H / SFH;
        }

        public int WindowsY(int W, int SFW)
        {
            return W / SFW;
        }
    }
}
