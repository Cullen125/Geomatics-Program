using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题5时间系统转换
{
    internal class Time
    {
        public int year;
        public int mon;
        public int day;
        public int hour;
        public int min;
        public double sec;

        public double JD;
        public int DOY;
        public string Fish;

        public int nyear;
        public int nmon;
        public int nday;
        public int nhour;
        public int nmin;
        public double nsec;

    }

    internal static class Datacenter
    {
        static public List<Time> times = new List<Time>();

        static public string report = "";
    }
}
