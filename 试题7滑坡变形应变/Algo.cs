using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题7滑坡变形应变
{
    internal static class Algo
    {
        static public void Cal()
        {
            CalChange();
            CalStrain();
            GetMaxChange();
            Datacenter.report = GetReport();
        }

        static public void CalChange()
        {
            Datacenter.changes.Clear();//1.清除旧数据
         
            for(int i = 0; i < Datacenter.stats.Count - 1; i++)
            {
                Stat begin = Datacenter.stats[i];
                Stat end = Datacenter.stats[i + 1];//相邻两条组成一组

                if (begin.Name != end.Name)
                {
                    continue;
                }

                Change c = new Change();//创建Change对象

                c.Name = begin.Name;
                c.BPeriod = begin.Period;
                c.EPeriod = end.Period;

                c.dx = end.x - begin.x;
                c.dy = end.y - begin.y;
                c.s = Math.Sqrt(c.dx * c.dx + c.dy * c.dy) * 1000;
                c.v = c.s / 5.0;

                Datacenter.changes.Add(c);
            }                    
        }

        static public void CalStrain()
        {
            Datacenter.strains.Clear();//清除旧数据

            List<Stat> M01 = new List<Stat>();//创建一个新的空列表
            List<Stat> M02 = new List<Stat>();
            List<Stat> M03 = new List<Stat>();
            List<Stat> M04 = new List<Stat>();

            foreach(var s in Datacenter.stats)//分类
            {
                if(s.Name == "M01")
                {
                    M01.Add(s);
                }
                else if(s.Name == "M02")
                {
                    M02.Add(s);
                }
                else if (s.Name == "M03")
                {
                    M03.Add(s);
                }
                else if( s.Name == "M04")
                {
                    M04.Add(s);
                }
            }

            for(int i = 0; i < M01.Count-1; i++)
            {
                Strain str1 = new Strain();

                str1.Name1 = "M01";
                str1.Name2 = "M02";

                str1.BPeriod = M01[i].Period;
                str1.EPeriod = M01[i + 1].Period;

                str1.S1 = Math.Sqrt((M01[i].x - M02[i].x) * (M01[i].x - M02[i].x) +
                                    (M01[i].y - M02[i].y) * (M01[i].y - M02[i].y));
                str1.S2 = Math.Sqrt((M01[i+1].x - M02[i+1].x) * (M01[i+1].x - M02[i+1].x) +
                                    (M01[i+1].y - M02[i+1].y) * (M01[i+1].y - M02[i+1].y));

                str1.ds = str1.S2 - str1.S1;
                str1.e = str1.ds / str1.S1;

                Datacenter.strains.Add(str1);
            }

            for (int i = 0; i < M03.Count - 1; i++)
            {
                Strain str2 = new Strain();

                str2.Name1 = "M03";
                str2.Name2 = "M04";

                str2.BPeriod = M03[i].Period;
                str2.EPeriod = M03[i + 1].Period;

                str2.S1 = Math.Sqrt((M03[i].x - M04[i].x) * (M03[i].x - M04[i].x) +
                                    (M03[i].y - M04[i].y) * (M03[i].y - M04[i].y));
                str2.S2 = Math.Sqrt((M03[i + 1].x - M04[i + 1].x) * (M03[i + 1].x - M04[i + 1].x) +
                                    (M03[i + 1].y - M04[i + 1].y) * (M03[i + 1].y - M04[i + 1].y));

                str2.ds = str2.S2 - str2.S1;
                str2.e = str2.ds / str2.S1;

                Datacenter.strains.Add(str2);
            }

        }

        static public void GetMaxChange()
        {
            Change max = Datacenter.changes[0];

            foreach(var c  in Datacenter.changes)
            {
                if (c.s > max.s)
                {
                    max = c;
                }
            }
            Datacenter.maxChange = max;
        }

        static public string GetReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("---------------滑坡体的变形速度与应变计算报告---------------");
            sb.AppendLine();

            sb.AppendLine("---------------------监测点位的变形速度---------------------");
            for(int i = 0; i< Datacenter.changes.Count; i+=3)
            {
                sb.AppendLine(
                    Datacenter.changes[i].Name + ",\t" +
                    Datacenter.changes[i].v.ToString("F2") + ",\t" +
                    Datacenter.changes[i + 1].v.ToString("F2") + ",\t" +
                    Datacenter.changes[i + 2].v.ToString("F2")
                    );
            }
            sb.AppendLine();
            sb.AppendLine("-----------------最大形变发生点位及发生时段-----------------");
            sb.AppendLine(Datacenter.maxChange.Name + ",\t" + Datacenter.maxChange.BPeriod + "-" + Datacenter.maxChange.EPeriod);
            sb.AppendLine();
            sb.AppendLine("-----------------------相邻点组的应变-----------------------");
            for(int i = 0;i< Datacenter.strains.Count; i += 3)
            {
                sb.AppendLine(
                    Datacenter.strains[i].Name1 + "-" +
                    Datacenter.strains[i].Name2 + ",\t" +
                    Datacenter.strains[i].e.ToString("F8") + ",\t" +
                    Datacenter.strains[i + 1].e.ToString("F8") + ",\t" +
                    Datacenter.strains[i + 2].e.ToString("F8")
                );                    
            }
            return sb.ToString();
        }

    }
}
