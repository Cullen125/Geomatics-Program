using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace 试题7滑坡变形应变
{
    internal class Stat
    {
        public string Name;
        public int Period;       // 当前观测期次

        public double x;
        public double y;
    }

    internal class Change
    {
        public string Name;

        public int BPeriod;      // 起始期次
        public int EPeriod;      // 结束期次

        public double dx;
        public double dy;

        public double s;
        public double v;
    }

    internal class Strain
    {
        public string Name1;
        public string Name2;

        public int BPeriod;
        public int EPeriod;

        public double S1;
        public double S2;

        public double ds;
        public double e;
    }
    internal static class Datacenter
    {
        static public List<Stat> stats = new List<Stat>();
        static public List <Change> changes = new List<Change>();
        static public List<Strain> strains = new List<Strain>();

        public static Change maxChange;

        static public string report = "";
    }
}
