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
            //MessageBox.Show(GetPixel(943, 76).ToString());
        }
        /// help funcs
        int GetPixel(int X, int Y)
        {
            Bitmap bmp = new Bitmap(1, 1, PixelFormat.Format32bppPArgb);
            Graphics grp = Graphics.FromImage(bmp);
            grp.CopyFromScreen(new Point(X, Y), Point.Empty, new Size(1, 1));
            grp.Save();
            grp.Dispose();
            return bmp.GetPixel(0, 0).ToArgb();
        }
        public bool isMaximized()
        {
            int controlAux = -15327199;
            int controlX = 1882;
            int controlY = 107;
            if (GetPixel(controlX, controlY) == controlAux) return true;
            return false;
        }
        public bool isClear()
        {
            int control2Aux = -13220541;
            int control2X = 960;
            int control2Y = 53;
            if (GetPixel(control2X, control2Y) == control2Aux) return true;
            return false;
        }
        /// heal funcs
        public void redHeal()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.VK_0);
        }
        public void yellowHeal()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.VK_9);
        }
        public void greenHeal()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.VK_8);
        }
        /// mana funcs
        public void manaDrinker()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.VK_7);
        }
        public void manaWaster()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.NUMPAD5);
        }
        /// status checker funcs
        public bool isPZ()
        {
            int pzAux = -15718862;
            int y = 76;            
            int[] coords = { 952, 933, 971, 943, 962, 924, 981, 905, 1000 };
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
            int[] coords = { 952, 933, 971, 943, 962, 924, 981, 905, 1000 };
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
            int[] coords = { 952, 933, 971, 943, 962, 924, 981, 905, 1000 };
            foreach (int x in coords)
            {
                if (GetPixel(x, y) == hungryAux) return true;
            }
            return false;
        }
        public bool isParalyzed()
        {
            int paralizeAux = -14545657;
            int y = 76;
            int[] coords = { 952, 933, 971, 943, 962, 924, 981, 905, 1000 };
            foreach (int x in coords)
            {
                if (GetPixel(x, y) == paralizeAux) return true;
            }
            return false;
        }
        public bool isEmpowered()
        {
            int empoweredAux = -14743548;
            int y = 76;
            int[] coords = { 952, 933, 971, 943, 962, 924, 981, 905, 1000 };
            foreach (int x in coords)
            {
                if (GetPixel(x, y) == empoweredAux) return true;
            }
            return false;
        }
        public bool isMounted()
        {
            int x = 1775;
            int y = 230;
            int mountedAux = -13718993;
            if (GetPixel(x, y) == mountedAux) return true;
            return false;
        }
        public bool isLifeRing()
        {
            int x = 1780;
            int y = 419;
            int lifeRingAux = -9046944;
            if (GetPixel(x, y) == lifeRingAux) return true;
            return false;
        }
        public bool isEnergyRing()
        {
            int x = 1780;
            int y = 419;
            int energyRingAux = -8847393;
            if (GetPixel(x, y) == energyRingAux) return true;
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
            s.Keyboard.KeyPress(VirtualKeyCode.NUMPAD2);
        }
        public void empower()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.VK_9);
        }
        public void mount()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.VK_T);
        }
        /// ring funcs
        public void equipLifeRing()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.VK_6);
        }
        public void unequipLifeRing()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.VK_4);
        }
        public void equipEnergyRing()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.VK_2);
        }
        public void unequipEnergyRing()
        {
            InputSimulator s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.VK_5);
        }
        /// core starts here
        // healer + anti paralyze
        private void timer1_Tick(object sender, EventArgs e)
        {
            // no go zone
            int emptyBarAux = -13816270;
            // size hp 745px (10% == 74px)
            // hp starts 950-
            int redHealthX = 950-74-74-74-74-74; // 50%
            int yellowHealthX = 950-74-74-74;    // 30%
            int greenHealthX = 950-74;           // 10%
            int healthY = 32;
            // logics - higher priority UP
            if (isMaximized())
            {
                if (GetPixel(redHealthX, healthY) == emptyBarAux) redHeal();
                else if (GetPixel(yellowHealthX, healthY) == emptyBarAux) yellowHeal();
                else if (GetPixel(greenHealthX, healthY) == emptyBarAux) greenHeal();
                else if (isParalyzed() && isClear()) haste();
            }
        }
        // smart mana manager + eater
        private bool smartMana = false;
        private void timer2_Tick(object sender, EventArgs e)
        {
            // no go zone
            int emptyBarAux = -13816270;
            // size mana 745px (10% == 74px)
            // mp starts 970+
            int manaStartDrinkX = 970 + 74 + 74 + 74 + 74 + 74; // 50%
            int manaStopDrinkX = 970 + 74 + 74 + 37; // 25%
            int maxManaX = 971;
            int manaY = 32;
            // logics - higher priority UP
            if (isMaximized())
            {
                if (smartMana)
                {
                    manaDrinker();
                    if (GetPixel(manaStopDrinkX, manaY) != emptyBarAux) smartMana = false;
                }
                else if (GetPixel(manaStartDrinkX, manaY) == emptyBarAux) smartMana = true;
                else if (GetPixel(maxManaX, manaY) != emptyBarAux) manaWaster();
                else if (isHungry() && isClear() && isPZ() == false) eat();
            }
        }
        // garbage collection
        private void timer3_Tick(object sender, EventArgs e)
        {
            GC.Collect();
        }
        // nao apagar further down
    }
}
