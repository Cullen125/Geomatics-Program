using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题5时间系统转换
{
    internal static class Algo
    {
        static public void Cal()
        {
            CalJD();
            CalDate();
            CalDOY();
            CalFish();
            Datacenter.report = GetReport();
        }

        static public void CalJD()
        {
           foreach(var t  in Datacenter.times)
            {
                int P1 = (t.year + (t.mon + 9) / 12);
                int P2 = (7 * P1 / 4);
                int P3 = 275 * t.mon / 9;
                double JD = 1721013.5 + 367 * t.year - P2 + P3 + t.day + t.hour / 24.0 + t.min / 1440.0 + t.sec / 86400.0;

                t.JD = JD;
            }
        }

        static public void CalDate()
        {
            foreach (var t in Datacenter.times)
            {
                int a = (int)( t.JD + 0.5);
                int b = a + 1537;
                int c = (int)((b - 122.1) / 365.25);
                int d = (int)(365.25 * c);
                int e = (int)((b - d) / 30.600);

                double nday = b - d - (int)(30.6001 * e) + t.JD + 0.5 - (int)(t.JD + 0.5);
                t.nday = (int)nday;
                double nmon = e - 1 - 12 * (int)(e / 14);
                t.nmon = (int)nmon;
                double nyear = c - 4715 - (int)((7 + nmon) / 10);
                t.nyear = (int)nyear;
                double nhour = (t.JD + 0.5 - (int)(t.JD + 0.5)) * 24;
                t.nhour = (int)nhour;
                double nmin = (nhour - t.nhour) * 60;
                t.nmin = (int)nmin;
                double nsec = (nmin - t.nmin) * 60;
                t.nsec = nsec;
            }
        }

        static public void CalDOY()
        {
            foreach(var t in Datacenter.times)
            {
                DateTime date = new DateTime(t.year, t.mon, t.day);
                t.DOY = date.DayOfYear;
            }
        }

        static public void CalFish()
        {
            DateTime start = new DateTime(2016, 1, 1);
            foreach(var t in Datacenter.times)
            {
                DateTime current = new DateTime(t.nyear, t.nmon, t.nday);
                int days = (current - start).Days;
                int n = days % 5;

                if (n < 3)
                {
                    t.Fish = "打鱼日";
                }
                else
                {
                    t.Fish = "晒网日";
                }
            }
        }

        static public string GetReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("---------------时间系统转换---------------");
            sb.AppendLine();

            sb.AppendLine("--------------------JD--------------------");
            foreach(var t in Datacenter.times)
            {
                sb.AppendLine(t.JD.ToString("F5") );
            }
            sb.AppendLine();

            sb.AppendLine("-------公历（年 月 日 时：分：秒）--------");
            foreach (var t in Datacenter.times)
            {
                sb.AppendLine(t.nyear + "\t" + t.nmon + "\t" + t.nday + "\t" + t.nhour + ":" + t.nmin + ":" + t.nsec.ToString("F6") );
            }
            sb.AppendLine();

            sb.AppendLine("------------------年积日------------------");
            foreach (var t in Datacenter.times)
            {
                sb.AppendLine(t.DOY.ToString() );
            }
            sb.AppendLine();

            sb.AppendLine("-------------三天打鱼两天晒网-------------");
            foreach (var t in Datacenter.times)
            {
                sb.AppendLine(t.nyear + "\t" + t.nmon + "\t" + t.nday + "\t" + t.Fish );
            }
            sb.AppendLine();

            return sb.ToString();//这个又忘了
        }
    }
}
