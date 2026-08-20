using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题2矩阵卷积计算_Cullen
{
    internal static class Algo
    {
        static public void Cal()
        {
            Datacenter.V1 = Cal1();
            Datacenter.V2 = Cal2();

            Datacenter.report = GetReport();
        }
        public static double[,] Cal1()
        {
            double[,] V = new double[10, 10];

            for (int I = 0; I < 10; I++)
            {
                for(int J = 0; J < 10; J++)
                {
                    double up = 0;
                    double down = 0;

                    for(int i = 0; i < 3; i++)
                    {
                        for(int j = 0; j < 3; j++)
                        {
                            int row = I - i - 1;
                            int col = J - j - 1;
                            if (row < 0 || row > 9 || col < 0 || col > 9)
                            {
                                continue;
                            }

                            up += Datacenter.M[i, j] * Datacenter.N[row, col];
                            down += Datacenter.M[i, j];
                        }
                    }
                    if (down == 0)
                    {
                        V[I, J] = double.NaN;
                    }
                    else
                    {
                        V[I, J] = up / down;                      
                    }
                }
            }
            return V;
        }

        public static double[,] Cal2()
        {
            double[,] V = new double[10, 10];

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
                            int row = I - i - 1;
                            int col = J - j - 1;

                            if (row < 0 || row > 9 || col < 0 || col > 9)
                            {
                                continue;
                            }

                            int row2 = 9 - row;
                            int col2 = 9 - col;

                            up += Datacenter.M[i, j] * Datacenter.N[row2, col2];
                            down += Datacenter.M[i, j];
                        }
                    }
                    if (down == 0)
                    {
                        V[I, J] = double.NaN;
                    }
                    else
                    {
                        V[I, J] = up / down;
                    }
                }
            }
            return V;
        }

        static public string GetReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("矩阵卷积计算报告");
            sb.AppendLine();

            sb.AppendLine("一、算法1计算结果：");
            sb.AppendLine(MatrixToString(Datacenter.V1));
            sb.AppendLine();

            sb.AppendLine("二、算法2计算结果：");
            sb.AppendLine(MatrixToString(Datacenter.V2));
            sb.AppendLine();

            return sb.ToString();
        }

        static public string MatrixToString(double[,] matrix)
        {
            StringBuilder sb = new StringBuilder();

            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    if (double.IsNaN(matrix[i, j]))
                    {
                        sb.Append("NaN".PadRight(10));
                    }
                    else
                    {
                        sb.Append(matrix[i, j].ToString("0.00").PadRight(10));
                    }
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
