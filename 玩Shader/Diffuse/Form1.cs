using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace bluebean.Diffuse
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        DiffuseSolver solver;
        Timer m_timer;
        int m_mouseX;
        int m_mouseY;
        bool m_isMouseDown;
        DateTime m_lastTickTime;
        DateTime m_lastFpsRecordTime;

        float Clamp(float v,float min,float max)
        {
            if (v < min)
                return min;
            if (v > max)
                return max;
            return v;
        }

        public Form1()
        {
            InitializeComponent();
            int W = pictureBox1.Width;
            int H = pictureBox1.Height;
            bitmap = new Bitmap(W, H, PixelFormat.Format24bppRgb);
            pictureBox1.Image = bitmap;
            pictureBox1.Refresh();
            solver = new DiffuseSolver(W, H);
           
            m_timer = new Timer();
            m_timer.Interval = (int)(1.0 / 60.0 * 1000);
            m_timer.Tick += (object sender, EventArgs e) => {
                DateTime now = DateTime.Now;
                double duration = (now - m_lastFpsRecordTime).TotalSeconds;
                double deltaTime = (now - m_lastTickTime).TotalSeconds;
                if (duration > 1.0)
                {
                    fpsLabel.Text = string.Format("fps:{0:F}", 1.0 / deltaTime);
                    m_lastFpsRecordTime = now;
                }
                m_lastTickTime = now;
                for (int i= 0;i < solver.dens0.Length; i++){
                    //solver.dens0[i] = 0;
                }
                if (m_isMouseDown)
                {
                    solver.dens0[(m_mouseY + 1) * (W + 2) + m_mouseX + 1] += 100.0f;
                }
                solver.Step(0.01667f);
                for (int i = 0; i < H; i++)
                {
                    for (int j = 0; j < W; j++)
                    {
                        float d = solver.dens[(i + 1) * (W + 2) + j + 1];
                        d = Clamp(d,0,1);
                        int v = (int)(d * 255);
                        Color c = Color.FromArgb(v,v,v);
                        //Color c = Color.FromArgb(255, 0, 0);
                        bitmap.SetPixel(j, i, c);
                    }
                }
                pictureBox1.Refresh();
                
            };
            m_timer.Start();
        }

        private void PicBox_OnMouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.X + "," + e.Y);
            m_isMouseDown = true;
            m_mouseX = e.X;
            m_mouseY = e.Y;
        }

        private void PicBox_OnMouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.X + "," + e.Y);
            m_isMouseDown = false;
        }

        private void PicBox_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (m_isMouseDown)
            {
                m_mouseX = e.X;
                m_mouseY = e.Y;
            }
        }
    }
}
