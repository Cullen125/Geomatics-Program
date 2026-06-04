using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 点云数据统计_Cullen
{
    static class Datacenter
    {
        static public List<Point> points = new List<Point>();//3
        static public Point K80 = new Point();//8:至此第一小题完成
        static public Point K13 = new Point();
        static public Point K53 = new Point();//19
        static public double x_avg;
        static public double y_avg;//9

        static public double x_sigema;
        static public double y_sigema;//13
    }
}
