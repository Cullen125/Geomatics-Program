using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题4最短路径计算
{
    internal static class Algo
    {
        static public void Cal()
        {
            Init();
            Dijkstra();
            GetReport();
        }

        static public void Init()
        {
            foreach(var v in Datacenter.vertices)
            {
                v.isS = false;
                v.dist = double.MaxValue;

                if(v.name == "武大")
                {
                    v.dist = 0;
                }
            }
        }

        static public void Dijkstra()
        {
            while (true)
            {
                V cur = FindMinV();

                if (cur == null)
                {
                    break;
                }
                cur.isS = true;
                Update(cur);
            }
        }

        static private V FindMinV()
        {
            V minV = null;
            double minDist = double.MaxValue;

            foreach(var v in Datacenter.vertices)
            {
                if (v.isS == false && v.dist < minDist)
                {
                    minDist = v.dist;
                    minV = v;
                }
            }           
            return minV;
        }

        static private void Update(V cur)
        {
            foreach(var e  in Datacenter.edges)
            {
                if (e.begin == cur.name)
                {
                    foreach(var v in Datacenter.vertices)
                    {
                        if( v.name == e.end && v.isS == false)
                        {
                            double newDist = cur.dist + e.wei;

                            if (newDist < v.dist)
                            {
                                v.dist = newDist;
                            }
                        }
                    }
                }
            }
        }

        static public void GetReport()
        {
            string report = "起点\t终点\t最短距离\r\n";
            foreach (var v in Datacenter.vertices)//假如某个地点和武大之间不存在任何可通行的路线，它的距离就一直是初始值double.MaxValue，报告中便显示“无法到达”。
            {
                if (v.dist == double.MaxValue)
                {
                    report += "武大\t" + v.name + "\t无法到达\r\n";
                }
                else
                {
                    report += "武大\t" + v.name + "\t" + v.dist + "\r\n";/*\r表示光标回到当前行的开头，叫“回车”。\n表示光标移动到下一行，叫“换行”。*/
                }
            }
            Datacenter.report = report;
        }
    }
}
