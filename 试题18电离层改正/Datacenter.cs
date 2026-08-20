using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题18电离层改正
{
    internal class Node
    {
        //原始文件信息
        public string Name = "";

        public double xs;
        public double ys;
        public double zs;

        //坐标
        public double x;
        public double y;
        public double z;

        public double A;
        public double E;

        //地磁纬度
        public double fip;
        public double lip;
        public double fm;
        //电离层延迟
        public double Tion;
        public double Dion;
    }
    internal static class Datacenter
    {
        static public List<Node> nodes = new List<Node>();
        static public double[,] H = new double[3, 3];

        //观测时间
        static public int year;
        static public int mon;
        static public int day;
        static public int hour;
        static public int min;
        static public double sec;

        //P
        static public double xp = -2225669.7744;
        static public double yp = 4998936.1598;
        static public double zp = 3265908.9678;
        
        static public double Bp = 30 * Math.PI / 180;
        static public double Lp = 114 * Math.PI / 180;

        static public double Hi = 350000.0;

        static public string report = "";
    }
}
