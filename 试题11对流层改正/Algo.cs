using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题11对流层改正
{
    internal static class Algo
    {
        static public void Cal()
        {
            CalWet();
            CalDry();
            CaldS();
            Datacenter.report = GetReport();
        }
        static public void CalWet()
        {
            //投影系数
            double aw15 = 0.00058021897; 
            double aw30 = 0.00056794847; 
            double aw45 = 0.00058118019; 
            double aw60 = 0.00059727542; 
            double aw75 = 0.00061641693;
            
            double bw15 = 0.0014275268;
            double bw30 = 0.0015138625;
            double bw45 = 0.0014572752;
            double bw60 = 0.0015007428;
            double bw75 = 0.0017599082;

            double cw15 = 0.043472961;
            double cw30 = 0.046729510;
            double cw45 = 0.043908931;
            double cw60 = 0.044626982;
            double cw75 = 0.054736038;

            foreach(var n in Datacenter.nodes)
            {
                double b = Math.Abs(n.b);
                
                //做判断
                if (b >= 75)
                {
                    n.aw = aw75;
                    n.bw = bw75;
                    n.cw = cw75;
                } 
                else if (b <= 15)
                {
                    n.aw = aw15;
                    n.bw = bw15;
                    n.cw = cw15;
                }
                else if (b > 15 && b < 30)
                {
                    n.aw = aw15 + (aw30 - aw15) * (b - 15.0) / (30 - 15.0);
                    n.bw = bw15 + (bw30 - bw15) * (b - 15.0) / (30 - 15.0);
                    n.cw = cw15 + (cw30 - cw15) * (b - 15.0) / (30 - 15.0);
                }
                else if (b >= 30 && b < 45)
                {
                    n.aw = aw30 + (aw45 - aw30) * (b - 30.0) / (45.0 - 30.0);
                    n.bw = bw30 + (bw45 - bw30) * (b - 30.0) / (45.0 - 30.0);
                    n.cw = cw30 + (cw45 - cw30) * (b - 30.0) / (45.0 - 30.0);
                }
                else if (b >= 45 && b < 60)
                {
                    n.aw = aw45 + (aw60 - aw45) * (b - 45.0) / (60.0 - 45.0);
                    n.bw = bw45 + (bw60 - bw45) * (b - 45.0) / (60.0 - 45.0);
                    n.cw = cw45 + (cw60 - cw45) * (b - 45.0) / (60.0 - 45.0);
                }
                else if (b >= 60 && b < 75)
                {
                    n.aw = aw60 + (aw75 - aw60) * (b - 60.0) / (75.0 - 60.0);
                    n.bw = bw60 + (bw75 - bw60) * (b - 60.0) / (75.0 - 60.0);
                    n.cw = cw60 + (cw75 - cw60) * (b - 60.0) / (75.0 - 60.0);
                }

                //投影函数计算
                double up1 = 1 + n.cw;
                double up2 = 1 + n.bw / up1;
                double up3 = 1 + n.aw / up2;

                double down1 = Math.Sin(n.E * Math.PI / 180.0) + n.cw;
                double down2 = Math.Sin(n.E * Math.PI / 180.0) + n.bw / down1;
                double down3 = Math.Sin(n.E * Math.PI / 180.0) + n.aw / down2;

                n.mw = up3 / down3;
            }

        }

        static private int CalDOY(int year, int mon, int day)
        {
            DateTime d = new DateTime(year, mon, day);
            return d.DayOfYear; 
        }

        static public void CalDry()
        {
            //干分量系数
            double aht = 2.53e-5;
            double bht = 5.49e-3;
            double cht = 1.14e-3;
            //年积日
            int t0 = 28;
            int t = CalDOY(Datacenter.year, Datacenter.mon, Datacenter.day);
            double T = Math.Cos(2.0 * Math.PI * (t - t0) / 365.25);
            //映射函数系数
            //avg
            double ah15avg = 0.0012769934;
            double ah30avg = 0.0012683230;
            double ah45avg = 0.0012465397;
            double ah60avg = 0.0012196049;
            double ah75avg = 0.0012049966;

            double bh15avg = 0.0029153695;
            double bh30avg = 0.0029152299;
            double bh45avg = 0.0029288445;
            double bh60avg = 0.0029022565;
            double bh75avg = 0.0029024912;

            double ch15avg = 0.062610505;
            double ch30avg = 0.062837393;
            double ch45avg = 0.063721774;
            double ch60avg = 0.063824265;
            double ch75avg = 0.064258455;
            //amp
            double ah15amp = 0.0;
            double ah30amp = 0.000012709626;
            double ah45amp = 0.000026523662;
            double ah60amp = 0.000034000452;
            double ah75amp = 0.000041202191;

            double bh15amp = 0.0;
            double bh30amp = 0.000021414979;
            double bh45amp = 0.000030160779;
            double bh60amp = 0.000072562722;
            double bh75amp = 0.00011723375;

            double ch15amp = 0.0;
            double ch30amp = 0.000090128400;
            double ch45amp = 0.000043497037;
            double ch60amp = 0.00084795348;
            double ch75amp = 0.0017037206;

            foreach (var n in Datacenter.nodes)
            {
                double b = Math.Abs(n.b);
                //做判断
                if (b >= 75)
                {
                    n.ad = ah75avg + ah75avg * T;
                    n.bd = bh75avg + bh75avg * T;
                    n.cd = ch75avg + ch75avg * T;
                }
                else if (b <= 15)
                {
                    n.ad = ah15avg + ah15avg * T;
                    n.bd = bh15avg + bh15avg * T;
                    n.cd = ch15avg + ch15avg * T;
                }
                else if (b > 15 && b < 30)
                {
                    n.ad = ah15avg + (ah30avg - ah15avg) * (b - 15.0) / (30.0 - 15.0) + (ah15amp + (ah30amp - ah15amp) * (b - 15.0) / (30.0 - 15.0)) * T;
                    n.bd = bh15avg + (bh30avg - bh15avg) * (b - 15.0) / (30.0 - 15.0) + (bh15amp + (bh30amp - bh15amp) * (b - 15.0) / (30.0 - 15.0)) * T;
                    n.cd = ch15avg + (ch30avg - ch15avg) * (b - 15.0) / (30.0 - 15.0) + (ch15amp + (ch30amp - ch15amp) * (b - 15.0) / (30.0 - 15.0)) * T;
                }
                else if (b >= 30 && b < 45)
                {
                    n.ad = ah30avg + (ah45avg - ah30avg) * (b - 30.0) / (45.0 - 30.0) + (ah30amp + (ah45amp - ah30amp) * (b - 30.0) / (45.0 - 30.0)) * T;
                    n.bd = bh30avg + (bh45avg - bh30avg) * (b - 30.0) / (45.0 - 30.0) + (bh30amp + (bh45amp - bh30amp) * (b - 30.0) / (45.0 - 30.0)) * T;
                    n.cd = ch30avg + (ch45avg - ch30avg) * (b - 30.0) / (45.0 - 30.0) + (ch30amp + (ch45amp - ch30amp) * (b - 30.0) / (45.0 - 30.0)) * T;
                }
                else if (b >= 45 && b < 60)
                {
                    n.ad = ah45avg + (ah60avg - ah45avg) * (b - 45.0) / (60.0 - 45.0) + (ah45amp + (ah60amp - ah45amp) * (b - 45.0) / (60.0 - 45.0)) * T;
                    n.bd = bh45avg + (bh60avg - bh45avg) * (b - 45.0) / (60.0 - 45.0) + (bh45amp + (bh60amp - bh45amp) * (b - 45.0) / (60.0 - 45.0)) * T;
                    n.cd = ch45avg + (ch60avg - ch45avg) * (b - 45.0) / (60.0 - 45.0) + (ch45amp + (ch60amp - ch45amp) * (b - 45.0) / (60.0 - 45.0)) * T;
                }
                else if (b >= 60 && b < 75)
                {
                    n.ad = ah60avg + (ah75avg - ah60avg) * (b - 60.0) / (75.0 - 60.0) + (ah60amp + (ah75amp - ah60amp) * (b - 60.0) / (75.0 - 60.0)) * T;
                    n.bd = bh60avg + (bh75avg - bh60avg) * (b - 60.0) / (75.0 - 60.0) + (bh60amp + (bh75amp - bh60amp) * (b - 60.0) / (75.0 - 60.0)) * T;
                    n.cd = ch60avg + (ch75avg - ch60avg) * (b - 60.0) / (75.0 - 60.0) + (ch60amp + (ch75amp - ch60amp) * (b - 60.0) / (75.0 - 60.0)) * T;
                }

                //投影函数计算
                double preup1 = 1 + n.cd;
                double preup2 = 1 + n.bd / preup1;
                double preup3 = 1 + n.ad / preup2;

                double predown1 = Math.Sin(n.E * Math.PI / 180.0) + n.cd;
                double predown2 = Math.Sin(n.E * Math.PI / 180.0) + n.bd / predown1;
                double predown3 = Math.Sin(n.E * Math.PI / 180.0) + n.ad / predown2;

                double postup1 = 1 + cht;
                double postup2 = 1 + bht / postup1;
                double postup3 = 1 + aht / postup2;

                double postdown1 = Math.Sin(n.E * Math.PI / 180.0) + cht;
                double postdown2 = Math.Sin(n.E * Math.PI / 180.0) + bht / postdown1;
                double postdown3 = Math.Sin(n.E * Math.PI / 180.0) + aht / postdown2;

                n.md = preup3 / predown3 + (1 / Math.Sin(n.E * Math.PI / 180.0) - postup3 / postdown3 ) * n.h / 1000.0;
            }
        }
        
        static public void CaldS()
        {
            foreach(var n in Datacenter.nodes)
            {
                n.ZHD = 2.29951 * Math.Pow(Math.E, -0.000116 * n.h);
                n.ZWD = 0.1;
                n.dS = n.ZHD * n.md + n.ZWD * n.mw;
            }
        }
        static public string GetReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("---------------对流层改正计算报告---------------");
            sb.AppendLine();
            
            sb.AppendLine("测站名\t高度角\tZHD\tmd（E）\tZWD\tmw（E）\tds");
            foreach(var n in Datacenter.nodes)
            {
                sb.AppendLine(n.Name + "\t" + n.E.ToString("F2") + "\t" + n.ZHD.ToString("F3") + "\t" + n.md.ToString("F3") + "\t" + n.ZWD.ToString("F3") + "\t" + n.mw.ToString("F3") + "\t" + n.dS.ToString("F3"));
            }

            return sb.ToString();
        }
    }
}
