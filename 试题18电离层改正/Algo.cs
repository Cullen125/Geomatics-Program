using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题18电离层改正
{
    internal static class Algo
    {
        static public void Cal()
        {
            Calangle();
            CalWeidu();
            CalIono();
            Datacenter.report = GetReport();
        }

        static public void Calangle()
        {
            foreach(var n in Datacenter.nodes)
            {
                double dx = n.xs - Datacenter.xp;
                double dy = n.ys - Datacenter.yp;
                double dz = n.zs - Datacenter.zp;

                double Bp = Datacenter.Bp;
                double Lp = Datacenter.Lp;

                Datacenter.H[0, 0] = -Math.Sin(Bp) * Math.Cos(Lp);
                Datacenter.H[0, 1] = -Math.Sin(Bp) * Math.Sin(Lp);
                Datacenter.H[0, 2] = Math.Cos(Bp);
                Datacenter.H[1, 0] = -Math.Sin(Lp);
                Datacenter.H[1, 1] = Math.Cos(Lp);
                Datacenter.H[1, 2] = 0;
                Datacenter.H[2, 0] = Math.Cos(Lp) * Math.Cos(Bp);
                Datacenter.H[2, 1] = Math.Cos(Bp) * Math.Sin(Lp);
                Datacenter.H[2, 2] = Math.Sin(Bp);

                n.x = Datacenter.H[0, 0] * dx + Datacenter.H[0, 1] * dy + Datacenter.H[0, 2] * dz;
                n.y = Datacenter.H[1, 0] * dx + Datacenter.H[1, 1] * dy + Datacenter.H[1, 2] * dz;
                n.z = Datacenter.H[2, 0] * dx + Datacenter.H[2, 1] * dy + Datacenter.H[2, 2] * dz;

                n.A = Math.Atan2(n.y, n.x);
                n.E = Math.Atan2(n.z, Math.Sqrt(n.x * n.x + n.y * n.y));
            }
        }

        static public void CalWeidu()
        {
            foreach(var n in Datacenter.nodes)
            {
                double p = 0.0137 / (n.E + 0.11) - 0.022;
                n.fip = Datacenter.Bp + p * Math.Cos(n.A);
                n.lip = Datacenter.Lp + p * Math.Sin(n.A) / Math.Cos(n.fip);
                n.fm = n.fip + 0.064 * Math.Cos(n.lip - 1.617);
            }
        }

        static private double CalTime(int hour, int min, double sec) 
        {
            double T = hour * 3600.0 + min * 60.0 + sec;
            return T;
        }

        static public void CalIono()
        {
            foreach(var n in Datacenter.nodes)
            {
                double F = 1 + 16 * Math.Pow(0.53 - n.E, 3);
                double A1 = 5e-9;
                double A2;
                double A3 = 50400;
                double A4;

                double a0 = 0.1397e-7, a1 = -0.7451e-8, a2 = -0.5960e-7, a3 = 0.1192e-6;
                double b0 = 0.1270e6, b1 = -0.1966e6, b2 = 0.6554e5, b3 = 0.2621e6;

                A2 = a0 + a1 * n.fm + a2 * Math.Pow(n.fm, 2) + a3 * Math.Pow(n.fm, 3);
                A4 = b0 + b1 * n.fm + b2 * Math.Pow(n.fm, 2) + b3 * Math.Pow(n.fm, 3);

                double T = CalTime(Datacenter.hour, Datacenter.min, Datacenter.sec);
                double t = 43200 * n.lip + T;
                double time = 2 * Math.PI * (t - A3) / A4;

                double Dion;
                double c = 299792458;

                if (n.E < 0)
                {
                    Dion = 0;
                }
                else
                {
                    if (Math.Abs(time) < 1.57)
                    {
                        n.Tion = F * (A1 + A2 * Math.Cos(time));
                    }
                    else
                    {
                        n.Tion = F * A1;
                    }

                    Dion = n.Tion * c;
                }

                n.Dion = Dion;
            }
        }

        static public string GetReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("---------------电离层改正----------------");
            sb.AppendLine();
            
            sb.AppendLine("卫星标识\t卫星高度角E\t方位角A\t电离层延迟Dion");
            foreach (var n in Datacenter.nodes)
            {
                sb.AppendLine(n.Name+"\t"+n.E.ToString("F3") + "\t" +n.A.ToString("F3") + "\t" +n.Dion.ToString("F3"));
            }

            return sb.ToString();
        }
    }
}
