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
            if (NS % 2 != 0) return H * W / (NS + 1);
                return H * W / NS;
        }

        public int SoftwindowHeight(int Size)
        {
            return Convert.ToInt16(Math.Sqrt(Size * 9 / 16));
        }

        public int Softwindowwidth(int Size)
        {
            return Convert.ToInt16(Math.Sqrt(Size*16/9 ));
        }

        public int WindowsX(int H, int SFH)
        {
           // if (H % SFH != 0) { return (H / SFH) + 1; }
            return (H / SFH);
        }

        public int WindowsY(int W, int SFW)
        {
           // if (W % SFW != 0) { return (W / SFW) + 1; }
            return (W / SFW);
        }
    }
}
