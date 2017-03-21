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

        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(HandleRef hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr WindowHandle);
        public const int SW_SHOW = 5;

        public Form1()
        {
            InitializeComponent();
        }

        int GetPixel(int X, int Y)
        {
            Bitmap bmp = new Bitmap(1, 1, PixelFormat.Format32bppPArgb);
            Graphics grp = Graphics.FromImage(bmp);
            grp.CopyFromScreen(new Point(X, Y), Point.Empty, new Size(1, 1));
            grp.Save();

            return bmp.GetPixel(0, 0).ToArgb();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(GetPixel(1845, 151).ToString());
        }

        public static void focus()
        {
            System.Diagnostics.Process[] objProcesses = System.Diagnostics.Process.GetProcessesByName("client");
            if (objProcesses.Length > 0)
            {
                IntPtr hWnd = IntPtr.Zero;
                hWnd = objProcesses[0].MainWindowHandle;
                SetForegroundWindow(objProcesses[0].MainWindowHandle);
            }
        }

        public void red()
        {
            focus();
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.F12);
            Thread.Sleep(950);
        }

        public void yellow()
        {
            focus();
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.F11);
            Thread.Sleep(950);
        }

        public void green()
        {
            focus();
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.F10);
            Thread.Sleep(950);
        }

        public void ma()
        {
            focus();
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.F9);
            Thread.Sleep(1250);
        }

        public void ea()
        {
            focus();
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.F8);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // no go zone
            int tAux = -14991265;
            int hAux = -2404529;
            int mAux = -10132752;
            // end of

            int redX = 1815;
            int redY = 220; 

            int yellowX = 1830;
            int yellowY = 220;

            int greenX = 1850;
            int greenY = 220;

            int mX = 1829;
            int mY = 234;

            int tX = 1845;
            int tY = 151;

            if (GetPixel(redX, redY) != hAux)
            {
               if (GetPixel(tX, tY) == tAux) red();
            }
            else if (GetPixel(yellowX, yellowY) != hAux)
            {
                if (GetPixel(tX, tY) == tAux) yellow();
            }
            else if (GetPixel(greenX, greenY) != hAux)
            {
                if (GetPixel(tX, tY) == tAux) green();
            }
            else if (GetPixel(mX, mY) != mAux && GetPixel(greenX, greenY) == hAux)
            {
                if (GetPixel(tX, tY) == tAux) ma();
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            ea();
        }

    }
}
