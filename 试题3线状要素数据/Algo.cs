using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace 试题3线状要素数据
{
    internal static class Algo
    {
        static public void Cal()
        {
            Datacenter.result.Clear();

            foreach(var p in Datacenter.points)
            {
                p.keep = false;
            }

            Datacenter.points[0].keep = true;
            Datacenter.points[Datacenter.points.Count - 1].keep = true;

            Douglas(0, Datacenter.points.Count - 1, Datacenter.threshold);

            foreach(var p in Datacenter.points)
            {
                if (p.keep)
                {
                    Datacenter.result.Add(p);
                }
            }
            Datacenter.report = GetReport();
        }

        static public double CalL(Node p1,  Node p2)
        {
            double dx = p1.x - p2.x;
            double dy = p1.y - p2.y;

            double L = Math.Sqrt(dx * dx + dy * dy);

            return L;
        }

        static public double CalDist(Node B, Node E, Node M)//单个段算距离
        {
            double L1 = CalL(B, E);
            double L2 = CalL(E, M);
            double L3 = CalL(M, B);

            double P = (L1 + L2 + L3) / 2.0;
            double S = Math.Sqrt( P * (P - L1) * (P - L2) * (P - L3) );
            double D = 2.0 * S / L1;

            return D;
        }

        static public void Douglas(int Beg, int End, double Thr)//整个段算距离再判断
        {
            double maxDist = 0;
            int maxid = -1;

            Node B = Datacenter.points[Beg];
            Node E = Datacenter.points[End];

            for(int i = Beg + 1; i < End; i++)
            {
                Node M = Datacenter.points[i];
                double D =CalDist(B, E, M);

                if (D > maxDist)
                {
                    maxDist = D;
                    maxid = i;
                }
            }

            if (maxDist > Thr)
            {
                Datacenter.points[maxid].keep = true;

                Douglas(Beg, maxid, Thr);
                Douglas(maxid, End, Thr);
            }
        }

        static public string GetReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("---------------线状要素数据压缩算法--------------");
            sb.AppendLine();

            sb.AppendLine("压缩阈值：" + Datacenter.threshold + "m");
            sb.AppendLine("本次计算共读取线状要素节点" + Datacenter.points.Count + "个；");
            sb.AppendLine("压缩后，线状要素节点为" + Datacenter.result.Count + "个。");
            sb.AppendLine();

            sb.AppendLine("保留的节点如下：");
            sb.AppendLine("点号（ID）\tX坐标\tY坐标");
            foreach(var p in Datacenter.result)
            {
                sb.AppendLine(p.ID + "\t" + p.x+ "\t" + p.y);
            }
            return sb.ToString();
        }
    }
}
