using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题8矩阵卷积计算
{
    internal static class Algo
    {
        static public void Cal()
        {
            GetV1();
            GetV2();
            Datacenter.report = GetReport();
        }

        static public void GetV1()
        {
            for(int I = 0; I < 10; I++)
            {
                for (int J = 0; J < 10; J++)
                {
                    double up = 0;
                    double down = 0;

                    for(int i  = 0; i < 3; i++)
                    {
                        for(int  j = 0; j < 3; j++)
                        {
                            int pre = I - i - 1;
                            int post = J - j - 1;

                            if(pre < 0  || post < 0 || pre > 9 || post > 9)
                            {
                                continue;//注意可不是 Datacenter.M[i,j] = 0;
                            }

                            up += Datacenter.M[i, j] * Datacenter.N[pre, post];
                            down += Datacenter.M[i, j];

                        }
                    }
                    // 没有有效数据时，结果为NaN
                    if (down == 0)
                    {
                        Datacenter.V1[I, J] = double.NaN;//NaN：Not a Number
                    }
                    else
                    {
                        Datacenter.V1[I, J] = up / down;
                    }
                }
            }
        }

        static public void GetV2()
        {
            for (int I = 0; I < 10; I++)
            {
                for (int J = 0; J < 10; J++)
                {
                    double up = 0;
                    double down = 0;

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            int pre = 9 - (I - i - 1);
                            int post = 9 - (J - j - 1);

                            if (pre < 0 || post < 0 || pre > 9 || post > 9)
                            {
                                continue;//注意可不是 Datacenter.M[i,j] = 0;
                            }

                            up += Datacenter.M[i, j] * Datacenter.N[pre, post];
                            down += Datacenter.M[i, j];

                        }
                    }
                    // 没有有效数据时，结果为NaN
                    if (down == 0)
                    {
                        Datacenter.V2[I, J] = double.NaN;//NaN：Not a Number
                    }
                    else
                    {
                        Datacenter.V2[I, J] = up / down;
                    }
                }
            }
        }

        static public string GetReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("---------------矩阵卷积计算---------------");
            sb.AppendLine();

            sb.AppendLine("----------------算法1结果-----------------");
            for(int I = 0; I < 10; I++)
            {
                for(int J = 0; J < 10; J++)
                {
                    sb.Append(Datacenter.V1[I,J].ToString("F2")+"\t");
                }
                // 当前一行的10个元素输出完毕后换行
                sb.AppendLine();
            }
            sb.AppendLine();

            sb.AppendLine("----------------算法2结果-----------------");
            for (int I = 0; I < 10; I++)
            {
                for (int J = 0; J < 10; J++)
                {
                    sb.Append(Datacenter.V2[I, J].ToString("F2") + "\t");
                }
                // 当前一行的10个元素输出完毕后换行
                sb.AppendLine();
            }
            sb.AppendLine();

            return sb.ToString();//这里总是忘记，想一下这个string肯定需要一个返回值。
        }
    }
}
