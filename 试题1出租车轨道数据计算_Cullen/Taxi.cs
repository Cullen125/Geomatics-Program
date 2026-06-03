using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace 试题1出租车轨道数据计算_Cullen
{
    internal class Taxi
    {
        public string name;
        public string status;
        public string bjtime;
        public double Mjd;
        public double x;
        public double y;


        public Taxi(string name, string status, string bjtime, double x, double y)
        {
            this.name = name;
            this.status = status;
            this.bjtime = bjtime;
            this.x = x;
            this.y = y;
        }
    }
}

