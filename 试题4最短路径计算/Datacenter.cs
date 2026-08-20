using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题4最短路径计算
{
    internal class V
    {
        public string name;  //顶点名称
        public double dist;  //武大到达该顶点的距离
        public bool isS;     //是否确定为最短距离

        public V(string name)
        {
            this.name = name;   
            dist = double.MaxValue;//初始距离为无穷大
            isS = false;//初始时都没有确定最短距离
        }
    }

    internal class E
    {
        public string begin;
        public string end;
        public double wei;

        public E(string begin, string end, double wei)
        {
            this.begin = begin;
            this.end = end;
            this.wei = wei;
        }
    }

    internal static class Datacenter
    {
        static public List<V> vertices = new List<V>();//所有顶点
        static public List <E> edges = new List<E>();  //所有边

        static public string report;
    }
}
