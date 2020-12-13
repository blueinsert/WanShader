using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace bluebean.Diffuse
{
    class DiffuseSolver
    {
        public int W;
        public int H;
        public float[] dens0;
        public float[] dens;

        public DiffuseSolver(int w,int h)
        {
            this.W = w;
            this.H = h;
            dens = new float[(w+2) * (h+2)];
            dens0 = new float[(w + 2) * (h + 2)];
        }

        private int Index(int i,int j)
        {
            return i * (W+2) + j;
        }

        private void Swap(ref float[] d1, ref float[] d2)
        {
            int size = (W + 2) * (H + 2);
            for (int i = 0; i < size; i++)
            {
                float temp = d1[i];
                d1[i] = d2[i];
                d2[i] = temp;
            }
        }

        private void AddSource(ref float[] d,ref float[] d0,float dt)
        {
            int size = (W + 2) * (H + 2);
            for(int i = 0; i < size; i++)
            {
                d[i] += d0[i] * dt;
                //d0[i] = d[i];
            }
        }

        public void Step(float dt)
        {
            Console.WriteLine("DiffuseSolver:Step");
            AddSource(ref dens,ref dens0, dt);
            Swap(ref dens, ref dens0);
            float a = dt * 0.005f * (W) * (H);
            a = 1.0f;
            LinSolve(0,ref dens,ref dens0,a,1+4*a);
        }

        private void SetBound(int b, ref float[] x)
        {
            for(int i = 1; i <= H; i++)
            {
                x[Index(i, 0)] = b == 2 ? -x[Index(i, 1)] : x[Index(i, 1)];
                x[Index(i, W + 1)] = b == 2 ? -x[Index(i, W)] : x[Index(i, W)];
            }
            for(int j = 1; j <= W; j++)
            {
                x[Index(0, j)] = b == 1 ? -x[Index(1, j)] : x[Index(1, j)];
                x[Index(H + 1, j)] = b == 1 ? -x[Index(H, j)] : x[Index(H, j)];
            }
            x[Index(0, 0)] = 0.5f * (x[Index(1, 0)] + x[Index(0, 1)]);
            x[Index(H + 1, 0)] = 0.5f * (x[Index(H, 0)] + x[Index(H + 1, 1)]);
            x[Index(0, W + 1)] = 0.5f * (x[Index(1, W + 1)] + x[Index(1, W)]);
            x[Index(H + 1, W + 1)] = 0.5f * (x[Index(H, W + 1)] + x[Index(H + 1, W)]);
        }

        private void LinSolve(int b, ref float[] d, ref float[] d0, float a, float c)
        {
            for(int iter = 0; iter < 25; iter++)
            {
                for(int j = 1; j <= W; j++)
                {
                    for(int i = 1; i <= H; i++)
                    {
                        d[Index(i, j)] = (d0[Index(i, j)] + (d[Index(i-1, j)] + d[Index(i+1, j)] + d[Index(i, j-1)] + d[Index(i, j+1)]) * a) / c;
                        //d[Index(i, j)] = (d0[Index(i, j)] + (d0[Index(i - 1, j)] + d0[Index(i + 1, j)] + d0[Index(i, j - 1)] + d0[Index(i, j + 1)]) * a) / c;
                    }
                }
            }
            SetBound(b, ref d);
        }
    }
}
