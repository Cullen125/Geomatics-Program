using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题2反距离加权
{
    internal static class Algo
    {
        static public void Cal()
        {
            InitTPoints();

            foreach(var t in Datacenter.Tpoints)
            {
                List<Near> nears = CalDist(t);
                CalWei(t, nears);
            }

            Datacenter.report = GetReport();

        }

        static public void InitTPoints()
        {
            Datacenter.Tpoints.Clear();

            TPoint Q1 = new TPoint();
            Q1.Name = "Q1";
            Q1.x = 4310;
            Q1.y = 3600;
            Datacenter.Tpoints.Add(Q1);

            TPoint Q2 = new TPoint();
            Q2.Name = "Q2";
            Q2.x = 4330;
            Q2.y = 3600;
            Datacenter.Tpoints.Add(Q2);

            TPoint Q3 = new TPoint();
            Q3.Name = "Q3";
            Q3.x = 4310;
            Q3.y = 3620;
            Datacenter.Tpoints.Add(Q3);

            TPoint Q4 = new TPoint();
            Q4.Name = "Q4";
            Q4.x = 4330;
            Q4.y = 3620;
            Datacenter.Tpoints.Add(Q4);
        }

        static public List<Near> CalDist(TPoint t)
        {
            List<Near> nears = new List<Near>();

            foreach(var k in Datacenter.Kpoints)
            {
                double dx = k.x - t.x;
                double dy = k.y - t.y;
                double dist = Math.Sqrt(dx * dx + dy * dy);

                Near near = new Near();
                near.point = k;
                near.dist = dist;

                nears.Add(near);
            }

            nears.Sort((a, b) => a.dist.CompareTo(b.dist));

            return nears;
        }

        static public void CalWei(TPoint t, List<Near> nears)
        {
            double up = 0;
            double down = 0;

            StringBuilder used = new StringBuilder();

            for(int i = 0; i < 5; i++)
            {
                KPoint k = nears[i].point;
                double dist = nears[i].dist;

                double w = 1.0 / dist;

                up += k.H * w;
                down += w;

                used.Append(k.Name + " ");
            }

            t.H = up / down;
            t.Used = used.ToString();
        }

        static public string GetReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("---------------反距离加权---------------");
            sb.AppendLine();

            sb.AppendLine("点名\tX(m)\t\tY(m)\t\tH(m)\t参与插值的点列表");
            foreach(var t in Datacenter.Tpoints)
            {
                sb.AppendLine(
                t.Name + "\t"
                + t.x.ToString("F3") + "\t"
                + t.y.ToString("F3") + "\t"
                + t.H.ToString("F3") + "\t"
                + t.Used                
                );
            }
            return sb.ToString();
        }
    }
}
