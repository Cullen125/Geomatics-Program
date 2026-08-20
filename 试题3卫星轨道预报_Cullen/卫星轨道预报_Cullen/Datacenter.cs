using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 卫星轨道预报_Cullen
{
    internal class Orbit
    {
        public double t;
        public double x;
        public double y;
        public double z;
    }

    internal class Predict
    {
        public double t;
        public double x;
        public double y;
        public double z;
    }

    internal static class Datacenter
    {
        static public List<Orbit> orbits = new List<Orbit>();
        static public List<Predict> predicts = new List<Predict>();

        static public double b0x;
        static public double b1x;

        static public double b0y;
        static public double b1y;

        static public double b0z;
        static public double b1z;

        static public string report = "";

    }
}
