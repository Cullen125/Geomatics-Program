using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题6面积计算
{
    internal static class Algo
    {
        static public void Cal()
        {
            InitTrig();
            CalL();
            CalA();
            CalsumA();  
            Datacenter.report = GetReport();
        }

        static public void InitTrig()
        {          
            Points A = Datacenter.points.Find(p => p.Name == "A");
            Points B = Datacenter.points.Find(p => p.Name == "B");
            Points C = Datacenter.points.Find(p => p.Name == "C");
            Points D = Datacenter.points.Find(p => p.Name == "D");
            Points E = Datacenter.points.Find(p => p.Name == "E");
            Points F = Datacenter.points.Find(p => p.Name == "F");
            Points G = Datacenter.points.Find(p => p.Name == "G");
            Points H = Datacenter.points.Find(p => p.Name == "H");

            Datacenter.triangles.Clear();

            Trig t1 = new Trig();
            t1.Id = 1;
            t1.P1 = A;
            t1.P2 = B;
            t1.P3 = H;
            Datacenter.triangles.Add(t1);

            Trig t2 = new Trig();
            t2.Id = 2;
            t2.P1 = B;
            t2.P2 = H;
            t2.P3 = C;
            Datacenter.triangles.Add(t2);

            Trig t3 = new Trig();
            t3.Id = 3;
            t3.P1 = C;
            t3.P2 = H;
            t3.P3 = G;
            Datacenter.triangles.Add(t3);

            Trig t4 = new Trig();
            t4.Id = 4;
            t4.P1 = C;
            t4.P2 = G;
            t4.P3 = D;
            Datacenter.triangles.Add(t4);

            Trig t5 = new Trig();
            t5.Id = 5;
            t5.P1 = D;
            t5.P2 = G;
            t5.P3 = F;
            Datacenter.triangles.Add(t5);

            Trig t6 = new Trig();
            t6.Id = 6;
            t6.P1 = D;
            t6.P2 = F;
            t6.P3 = E;
            Datacenter.triangles.Add(t6);
        }

        static public void CalL()
        {
            foreach(var t in Datacenter.triangles)
            {
                t.L1 = Math.Sqrt((t.P1.x - t.P2.x) * (t.P1.x - t.P2.x) + (t.P1.y - t.P2.y) * (t.P1.y - t.P2.y));
                t.L2 = Math.Sqrt((t.P2.x - t.P3.x) * (t.P2.x - t.P3.x) + (t.P2.y - t.P3.y) * (t.P2.y - t.P3.y));
                t.L3 = Math.Sqrt((t.P3.x - t.P1.x) * (t.P3.x - t.P1.x) + (t.P3.y - t.P1.y) * (t.P3.y - t.P1.y));
            }
        }

        static public void CalA()
        {
            foreach (var t in Datacenter.triangles)
            {
                t.S = (t.L1 + t.L2 + t.L3) / 2.0 ;
                t.A = Math.Sqrt(t.S * (t.S - t.L1) * (t.S - t.L2) * (t.S - t.L3));
            }
        }

        static public void CalsumA()
        {
            Datacenter.sumA = 0;//记得清空
            foreach (var t in Datacenter.triangles)
            {              
                Datacenter.sumA += t.A;
            }
        }

        static public string GetReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("---------------面积计算报告---------------");
            sb.AppendLine();
            sb.AppendLine("三角形序号\t边1的长度（m）\t边2的长度（m）\t边3的长度（m）\t面积（m²）");
            foreach(var t in Datacenter.triangles)
            {
                sb.AppendLine(t.Id + "\t" + t.L1.ToString("F3") + "\t" + t.L2.ToString("F3") + "\t" + t.L3.ToString("F3") + "\t" + t.A.ToString("F3"));
            }
            sb.AppendLine();
            sb.AppendLine("地块总面积："+ Datacenter.sumA.ToString("F3") + " m²");
            sb.AppendLine();

            return sb.ToString();
        }

    }
}
