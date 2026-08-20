using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题9坐标系转换
{
    internal static class Algo
    {
        static public void Cal()
        {
            GetBLH();
            GetNEU();
            Datacenter.report = GetReport();
        }

        static public void GetBLH()
        {
            Node n = Datacenter.nodes[0];

            double a = 6378137.0;
            double f = 1.0 / 298.257223563;
            double b = (1 - f) * a;

            double e1_2 = (a * a - b * b) / (a * a);
            double e2_2 = (a * a - b * b) / (b * b);

            double O = Math.Atan(n.z * a / (Math.Sqrt(n.x * n.x + n.y * n.y) * b));

            n.l = Math.Atan2(n.y, n.x);
            n.b = Math.Atan2(n.z + e2_2 * b * Math.Sin(O) * Math.Sin(O) * Math.Sin(O), Math.Sqrt(n.x * n.x + n.y * n.y) - e1_2 * a * Math.Cos(O) * Math.Cos(O) * Math.Cos(O));
            double N = a / Math.Sqrt(1 - e1_2 * Math.Sin(n.b) * Math.Sin(n.b));
            n.h = Math.Sqrt(n.x * n.x + n.y * n.y) / Math.Cos(n.b) - N;

        }

        static public void GetNEU()
        {
            Node n = Datacenter.nodes[0];

            Datacenter.T[0, 0] = -Math.Sin(n.b) * Math.Cos(n.l);
            Datacenter.T[0, 1] = -Math.Sin(n.b) * Math.Sin(n.l);
            Datacenter.T[0, 2] = Math.Cos(n.b);

            Datacenter.T[1, 0] = -Math.Sin(n.l);
            Datacenter.T[1, 1] = Math.Cos(n.l);
            Datacenter.T[1, 2] = 0;

            Datacenter.T[2, 0] = Math.Cos(n.b) * Math.Cos(n.l);
            Datacenter.T[2, 1] = Math.Cos(n.b) * Math.Sin(n.l);
            Datacenter.T[2, 2] = Math.Sin(n.b);

            foreach(var p in Datacenter.nodes)
            {
                double dx = p.x - n.x;
                double dy = p.y - n.y;
                double dz = p.z - n.z;

                double[] d = new double[] { dx, dy, dz };
                p.n = 0;
                p.e = 0;
                p.u = 0;

                for(int i = 0; i < 3; i++)
                {
                    p.n += Datacenter.T[0, i] * d[i];
                    p.e += Datacenter.T[1, i] * d[i];
                    p.u += Datacenter.T[2, i] * d[i];
                }
            }
        }

        static public string GetReport()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine(Datacenter.nodes.Count.ToString());
            foreach(var p in Datacenter.nodes)
            {
                sb.AppendLine(p.Name + "\t" + p.n.ToString("F4") + "\t" + p.e.ToString("F4") + "\t" + p.u.ToString("F4"));
            }
            return sb.ToString();
        }
    }
}
