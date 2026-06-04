using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 点云数据统计_Cullen
{
    class Point
    {
        public string name;
        public double x;
        public double y;//1

        //标准化坐标
        public double X;
        public double Y;//15

        public Point(string name, double x, double y)
        {
            this.name = name;
            this.x = x;
            this.y = y;
        }//1
        public Point()
        {
            
        }//6:不太理解为什么这里需要有一个空的Point，David说不加空的会在Datacenter里面报错
    }
}
