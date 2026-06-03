using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题1出租车轨道数据计算_Cullen
{
    internal class Result
    {
        public int id;
        public double b_Mjd;
        public double e_Mjd;
        public double speed;
        public double angle;
        public double distance;

        static public double sumDistance = 0;
        static public double straightDistance = 0;

        public Result(int id, double b_Mjd, double e_Mjd, double speed, double angle, double distance)
        {
            this.id = id;
            this.b_Mjd = b_Mjd;
            this.e_Mjd = e_Mjd;
            this.speed = speed;
            this.angle = angle;
            this.distance = distance;
        }
    }
}
