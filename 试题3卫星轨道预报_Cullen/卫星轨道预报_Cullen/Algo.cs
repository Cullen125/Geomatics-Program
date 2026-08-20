using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 卫星轨道预报_Cullen
{
    internal static class Algo
    {
        static public void cal()
        {
            CalModel();
            PredictOrbit();
            Datacenter.report = GetReport();

        }

        static public void CalModel()
        {
            int n = Datacenter.orbits.Count;

            double sumT = 0;
            double sumX = 0;
            double sumY = 0;
            double sumZ = 0;

            foreach(var o  in Datacenter.orbits)
            {
                sumT += o.t;
                sumX += o.x;
                sumY += o.y;
                sumZ += o.z;
            }

            double avgT = sumT / n;
            double avgX = sumX / n;
            double avgY = sumY / n;
            double avgZ = sumZ / n;

            double upX = 0;
            double upY = 0;
            double upZ = 0;
            double down = 0;

            foreach(var o in Datacenter.orbits)
            {
                upX += (o.t - avgT) * (o.x - avgX);
                upY += (o.t - avgT) * (o.y - avgY);
                upZ += (o.t - avgT) * (o.z - avgZ);

                down += (o.t - avgT) * (o.t - avgT);
            }

            Datacenter.b1x = upX / down;
            Datacenter.b1y = upY / down;
            Datacenter.b1z = upZ / down;

            Datacenter.b0x = avgX - Datacenter.b1x * avgT;
            Datacenter.b0y = avgY - Datacenter.b1y * avgT;
            Datacenter.b0z = avgZ - Datacenter.b1z * avgT;
        }

        static public void PredictOrbit()
        {
            Datacenter.predicts.Clear();

            double[] times = new double[] { 4200, 4500, 4800 };

            foreach(double t in times)
            {
                Predict p = new Predict();
                p.t = t;
                p.x = Datacenter.b0x + Datacenter.b1x * t;
                p.y = Datacenter.b0y + Datacenter.b1y * t;
                p.z = Datacenter.b0z + Datacenter.b1z * t;

                Datacenter.predicts.Add(p);
            }
        }

        static private string GetReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("卫星轨道预报计算报告");
            sb.AppendLine();

            sb.AppendLine("一、回归参数");
            sb.AppendLine("b0x = " + Datacenter.b0x.ToString("F5"));
            sb.AppendLine("b1x = " + Datacenter.b1x.ToString("F5"));
            sb.AppendLine("b0y = " + Datacenter.b0y.ToString("F5"));
            sb.AppendLine("b1y = " + Datacenter.b1y.ToString("F5"));
            sb.AppendLine("b0z = " + Datacenter.b0z.ToString("F5"));
            sb.AppendLine("b1z = " + Datacenter.b1z.ToString("F5"));
            sb.AppendLine();

            sb.AppendLine("二、预报结果");
            sb.AppendLine("时间t\tX\tY\tZ");
            foreach(var p  in Datacenter.predicts)
            {
                sb.AppendLine(
                    p.t.ToString("F0") + "\t" + p.x.ToString("F3") + "\t" + p.y.ToString("F3") + "\t" + p.z.ToString("F3")
                    );
            }
            return sb.ToString();
        }
    }
}
