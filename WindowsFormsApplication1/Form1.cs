using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using WindowsInput;
using WindowsInput.Native;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Thread.Sleep(7000);
            //MessageBox.Show(GetPixel(945, 64).ToString());
        }
        /// Help funcs
        // Get pixel from screen
        int GetPixel(int X, int Y)
        {
            Bitmap bmp = new Bitmap(1, 1, PixelFormat.Format32bppPArgb);
            Graphics grp = Graphics.FromImage(bmp);
            grp.CopyFromScreen(new Point(X, Y), Point.Empty, new Size(1, 1));
            grp.Save();
            return bmp.GetPixel(0, 0).ToArgb();
        }        
        /// heal funcs
        public void red()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.F12);
            Thread.Sleep(955);
        }
        public void yellow()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.F11);
            Thread.Sleep(955);
        }
        public void green()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.F10);
            Thread.Sleep(955);
        }
        /// mana funcs
        public void m()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.F9);
            Thread.Sleep(1250);
        }
        public void mw()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.F3);
        }
        /// status checker funcs
        public bool isPZ()
        {
            // coords status
            int statusAux = -13534304;
            int X1 = 954;
            int X2 = 964;
            int X3 = 945;
            int X4 = 973;
            int X5 = 936;
            int X6 = 982;
            int X7 = 927;
            int Y = 64;

            if (GetPixel(X1, Y) == statusAux || GetPixel(X2, Y) == statusAux || GetPixel(X3, Y) == statusAux ||
                GetPixel(X4, Y) == statusAux || GetPixel(X5, Y) == statusAux || GetPixel(X6, Y) == statusAux ||
                GetPixel(X7, Y) == statusAux)
            {
                return true;
            }
            return false;
        }
        /// misc funcs
        public void eat()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.F8);
        }
        public void test()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.F4);
        }
        /// core
        private void timer1_Tick(object sender, EventArgs e)
        {
            // no go zone
            int barAux = -13816270;
            int controlAux = -15327199;
            int cX = 1882;
            int cY = 107;
            // size hp/mana 745px (10% == 74px)
            // hp starts 950-
            int redX = 950-74-74-74-74; // 40%
            int yellowX = 950-74-74-37; // 25%
            int greenX = 950-74;        // 10%
            int hY = 32;
            // mp starts 970+
            int mX = 970+74+74+74; // 30%
            int mmX = 971;
            int mY = 32;
            // logics - higher priority UP
            if (GetPixel(redX, hY) == barAux && GetPixel(cX, cY) == controlAux)
            {
                red();
            }
            else if (GetPixel(yellowX, hY) == barAux && GetPixel(cX, cY) == controlAux)
            {
                yellow();
            }
            else if (GetPixel(greenX, hY) == barAux && GetPixel(cX, cY) == controlAux)
            {
               green();
            }
            else if (GetPixel(mX, mY) == barAux && GetPixel(cX, cY) == controlAux)
            {
                m();
            }
            else if (GetPixel(mmX, mY) != barAux && GetPixel(cX, cY) == controlAux)
            {
                mw();
            }
            // end of 
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            int cX = 1882;
            int cY = 107;
            int controlAux = -15327199;

            if (GetPixel(cX, cY) == controlAux && isPZ() == false)
            {
                eat();
            }
        }
        // nao apagar further down
    }
}
