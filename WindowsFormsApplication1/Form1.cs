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
            //MessageBox.Show(GetPixel(960, 53).ToString());
        }
        /// Help funcs
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
        }
        public void yellow()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.F11);
        }
        public void green()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.F10);
        }
        /// mana funcs
        public void m()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.F9);
        }
        public void mw()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.F3);
        }
        /// status checker funcs
        // sample
        public bool isCondition()
        {
            int conditionAux = -1;
            int y = 76;
            int[] coords = { 952, 933, 952, 971, 943, 962, 924, 981, 905, 1000 };
            foreach (int x in coords)
            {
                if (GetPixel(x, y) == conditionAux) return true;
            }
            return false;
        }
        // end of sample
        public bool isPZ()
        {
            int pzAux = -15718862;
            int y = 76;
            int[] coords = { 952, 933, 952, 971, 943, 962, 924, 981, 905, 1000 };
            foreach (int x in coords)
            {
                if (GetPixel(x, y) == pzAux) return true;
            }
            return false;
        }
        public bool isHasted()
        {
            int hastedAux = -6385037;
            int y = 76;
            int[] coords = { 952, 933, 952, 971, 943, 962, 924, 981, 905, 1000 };
            foreach (int x in coords)
            {
                if (GetPixel(x, y) == hastedAux) return true;
            }
            return false;
        }
        public bool isHungry()
        {
            int hungryAux = -9550811;
            int y = 76;
            int[] coords = { 952, 933, 952, 971, 943, 962, 924, 981, 905, 1000 };
            foreach (int x in coords)
            {
                if (GetPixel(x, y) == hungryAux) return true;
            }
            return false;
        }
        public bool isParalized()
        {
            int paralizeAux = -1;
            int y = 76;
            int[] coords = { 952, 933, 952, 971, 943, 962, 924, 981, 905, 1000 };
            foreach (int x in coords)
            {
                if (GetPixel(x, y) == paralizeAux) return true;
            }
            return false;
        }
        public bool isEmpowered()
        {
            int empoweredAux = -1;
            int y = 76;
            int[] coords = { 952, 933, 952, 971, 943, 962, 924, 981, 905, 1000 };
            foreach (int x in coords)
            {
                if (GetPixel(x, y) == empoweredAux) return true;
            }
            return false;
        }
        /// misc funcs
        public void eat()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.F8);
        }
        public void haste()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.F5);
        }
        public void empower()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.F6);
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
            int redX = 950-74-74-74-74-74; // 50%
            int yellowX = 950-74-74-74;    // 30%
            int greenX = 950-74;           // 10%
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
        // auto functions status
        int autoHaste = 0;
        int autoEmpower = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            // no go zone
            int cX = 1882;
            int cY = 107;
            int c2X = 960;
            int c2Y = 53;
            int controlAux = -15327199;
            int control2Aux = -13220541;
            // end of
            if (GetPixel(cX, cY) == controlAux && GetPixel(c2X, c2Y) == control2Aux && isPZ() == false)
            {
                // always ON funcs
                if (isParalized()) haste();
                else if (isHungry()) eat();
                // on demand funcs
                else if (isHasted() == false && autoHaste == 1) haste();
                else if (isEmpowered() == false && autoEmpower == 1) empower();
            }
        }
        // nao apagar further down
    }
}
