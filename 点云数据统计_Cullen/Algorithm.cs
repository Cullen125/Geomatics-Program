using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace 点云数据统计_Cullen
{
    static class Algorithm
    {
        static public List<Point> pts = Datacenter.points;//全局变量
        static public void let_avg()
        {
            Datacenter.x_avg = pts.Average(p => p.x);
            Datacenter.y_avg = pts.Average(p => p.y);//12
        }

        static public void let_std()
        {
            double up_x = 0;//David老大提醒大家这里需要进行一个检查，不要写成int型，不然精度会损失。
            int n = pts.Count;
            foreach (var p in pts)
            {
                up_x += Pow( p.x - Datacenter.x_avg,2);
            }
            Datacenter.x_sigema = Sqrt(up_x / n);

            double sigema2_y = pts.Sum(p =>Pow( p.y - Datacenter.y_avg,2))/n;
            double sigema_y = Sqrt(sigema2_y);
            Datacenter.y_sigema = sigema_y;
        }//14:第三小题至此完成

        static public void let_XY()//老大说他不知道坐标的英文，坐标是Coordinate，要写规范的可以写成cdn
        {
            foreach(var p in pts)
            {
                p.X = (p.x - Datacenter.x_avg) / Datacenter.x_sigema;
                p.Y = (p.y - Datacenter.y_avg) / Datacenter.y_sigema;
            }
            Datacenter.K13 = Datacenter.points[12];
            Datacenter.K53 = Datacenter.points[52];//20

        }//16

    }
}
