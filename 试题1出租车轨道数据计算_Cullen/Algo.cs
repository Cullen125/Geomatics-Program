using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace 试题1出租车轨道数据计算_Cullen
{
    internal class Algo
    {
        static public List<Taxi> txs = Datacenter.taxis;
        static public void Get_Mjd()
        {
            txs = Datacenter.taxis;//重新获取出租车数据列表，其实txs就是List<Taxi>
            for (int i = 0; i < txs.Count; i++)
            {
                string bjtime = txs[i].bjtime.Trim();//Trim()建议加上，这个是去前后空格的，以防万一

                int year = Convert.ToInt32(bjtime.Substring(0, 4));//第1个字符开始取，取4个字符，
                int month = Convert.ToInt32(bjtime.Substring(4, 2));
                int day = Convert.ToInt32(bjtime.Substring(6, 2));
                int hour = Convert.ToInt32(bjtime.Substring(8, 2));
                int min = Convert.ToInt32(bjtime.Substring(10, 2));
                int sec = Convert.ToInt32(bjtime.Substring(12, 2));

                DateTime bjTime = new DateTime(year, month, day, hour, min, sec);
                DateTime utcTime = bjTime.AddHours(-8);
                /*这里解释一下为什么不能用hour = hour - 8;
                如果是2017年7月6日02:00:00，使用这个公式就会变成-6点，这是不合法的；
                但是用DataTime可以自动处理跨日期的问题。*/

                int Y = utcTime.Year;
                int M = utcTime.Month;
                int D = utcTime.Day;
                int h = utcTime.Hour;
                int N = utcTime.Minute;
                int S = utcTime.Second;

                double mjd = - 678987 + 367 * Y - (int)(7.0 / 4.0 * (Y + (int)((M + 9) / 12.0))) + (int)(275.0 * M / 9.0) + D + h / 24.0 + N / 1440.0 + S / 86400.0;//注意是用小数，不要用整数计算！
                txs[i].Mjd = mjd;//把计算结果存回当前出租车对象
            }
        }

        static public List<Result> results = Datacenter.results;
        static public void Get_Result()
        {
            txs = Datacenter.taxis;
            results = Datacenter.results;

            results.Clear();

            Result.sumDistance = 0;
            Result.straightDistance = 0;

            int id = 0;
            for (int i = 0; i < txs.Count - 1; i++)
            {
                Taxi p1 = txs[i];
                Taxi p2 = txs[i + 1];

                double dx = p2.x - p1.x;
                double dy = p2.y - p1.y;
                double distance = Sqrt(dx * dx + dy * dy);
                Result.sumDistance += distance;
                double dt = (p2.Mjd - p1.Mjd) * 86400.0;
                if (dt <= 0)
                {
                    continue;
                }

                double speed = distance / dt * 3.6;
                double angle = Atan(dy / dx) * 180.0 / PI;
                if (angle < 0)
                {
                    angle += 360.0;
                }

                Result res = new Result(id, p1.Mjd, p2.Mjd, speed, angle, distance);
                results.Add(res);
                id++;
            }

            if (txs.Count >= 2)
            {
                Taxi first = txs[0];
                Taxi last = txs[txs.Count - 1];

                double dx = last.x - first.x;
                double dy = last.y - first.y;

                Result.straightDistance = Sqrt(dx * dx + dy * dy);
            }

            Result.sumDistance = Result.sumDistance / 1000.0;
            Result.straightDistance = Result.straightDistance / 1000.0;

        }

    }
}
