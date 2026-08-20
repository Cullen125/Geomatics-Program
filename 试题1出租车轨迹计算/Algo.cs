using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题1出租车轨迹计算
{
    internal static class Algo
    {
        static public void Cal()
        {
            CalMJD();
            CalResult();
            CalSum();
            Datacenter.report = GetReport();

        }

        static public void CalMJD()
        {
            foreach(Taxi taxi in Datacenter.taxis)
            {
                int year = int.Parse(taxi.T.Substring(0, 4));
                int mon  = int.Parse(taxi.T.Substring(4, 2));
                int day  = int.Parse(taxi.T.Substring(6, 2));
                int hour = int.Parse(taxi.T.Substring(8, 2));
                int min  = int.Parse(taxi.T.Substring(10, 2));
                int sec  = int.Parse(taxi.T.Substring(12, 2));

                DateTime bjTime = new DateTime(year, mon, day, hour, min, sec);
                DateTime utcTime = bjTime.AddHours(-8);

                year = utcTime.Year;
                mon = utcTime.Month;
                day = utcTime.Day;
                hour = utcTime.Hour;
                min = utcTime.Minute;
                sec = utcTime.Second;

                double p1 = Math.Floor((mon + 9.0) / 12.0);
                double p2 = Math.Floor(7.0 / 4.0 * (year + p1));
                double p3 = Math.Floor(275.0 * mon / 9.0);

                double mjd = -678987.0 + 367.0 * year - p2 + p3 + day + hour / 24.0 + min / 1440.0 + sec / 86400.0;

                taxi.MJD = mjd;
            }


        }

        static public void CalResult()
        {
            Datacenter.results.Clear();
            for(int i = 0;  i < Datacenter.taxis.Count-1; i++)
            {
                Taxi begin = Datacenter.taxis[i];
                Taxi end = Datacenter.taxis[i+1];

                double dx = end.x - begin.x;
                double dy = end.y - begin.y;
                double ds = Math.Sqrt(dx * dx + dy * dy) / 1000.0;

                double dt = (end.MJD - begin.MJD) * 24.0;
                double v = ds / dt;//公里/小时

                double a = Math.Atan2(dy, dx);
                a = a * 180.0 / Math.PI;
                if(a < 0)
                {
                    a = a + 360.0;
                }

                Result result = new Result();
                result.Id = i + 1;
                result.BMJD = begin.MJD;
                result.EMJD = end.MJD;
                result.v = v;
                result.a = a;
                result.s = ds;

                Datacenter.results.Add(result);
            }

        }

        static public void CalSum()
        {
            Datacenter.sumS = 0;
            foreach(Result result in Datacenter.results)
            {
                Datacenter.sumS += result.s;
            }

            Taxi first = Datacenter.taxis[0];
            Taxi last = Datacenter.taxis[Datacenter.taxis.Count - 1];

            double dx = last.x - first.x;
            double dy = last.y - first.y;
            Datacenter.sumL = Math.Sqrt(dx * dx + dy * dy) / 1000.0;

        }

        static public string GetReport()//尤其注意，这里不是void了，是report！！！
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("出租车轨迹数据计算报告");
            sb.AppendLine();

            sb.AppendLine("一、速度v和方位角a计算");
            for(int i = 0; i < Datacenter.results.Count; i++)
            {
                sb.AppendLine(
                    (i + 1) + ",\t"
                    + Datacenter.results[i].BMJD.ToString("F8") + "-"
                    + Datacenter.results[i].EMJD.ToString("F8") + ",\t"
                    + Datacenter.results[i].v.ToString("F3") + ",\t"
                    + Datacenter.results[i].a.ToString("F3")
                );
            }
            sb.AppendLine();

            sb.AppendLine("二、距离计算结果");
            sb.AppendLine("累计距离："+Datacenter.sumS.ToString("F3")+"(km)");
            sb.AppendLine("首尾直线距离：" + Datacenter.sumL.ToString("F3") + "(km)");           

            return sb.ToString();
        }
    }
}
