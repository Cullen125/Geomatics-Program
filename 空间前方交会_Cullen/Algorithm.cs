using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using static 空间前方交会_Cullen.Datacenter;

namespace 空间前方交会_Cullen
{
    static class Algorithm
    {
        static public void let_uvw()
        {
            (double U1, double V1, double W1) = get_uvw(phi1, omiga1, kapa1, x1, y1, f1);
            (double U2, double V2, double W2) = get_uvw(phi2, omiga2, kapa2, x2, y2, f2);
            u1 = U1;
            v1 = V1;
            w1 = W1;
            u2 = U2;
            v2 = V2;
            w2 = W2;
        }

        static public (double u, double v, double w) get_uvw(double phi, double omiga, double kapa, double x, double y, double f)
        {
            double cos4 = Cos(phi);
            double sin4 = Sin(phi);
            double cosw = Cos(omiga);
            double sinw = Sin(omiga);
            double cosk = Cos(kapa);
            double sink = Sin(kapa);

            double a1 = cos4 * cosk - cos4 * sinw * sink;
            double a2 = -cos4 * sink - sin4 * sinw * sink;
            double a3 = -sin4 * cosw;
            double b1 = cosw * sink;
            double b2 = cosw * cosk;
            double b3 = -sinw;
            double c1 = sin4 * cosk + cos4 * sinw * sink;
            double c2 = -sinw * cosk + cos4 * sinw * sink;
            double c3 = cos4 * cosw;

            double u = a1 * x + a2 * y - a3 * f;
            double v = b1 * x + b2 * y - b3 * f;
            double w = c1 * x + c2 * y - c3 * f;

            return (u, v, w);

        }

        static public void let_N_XYZ()
        {
            double BU = Xs2 - Xs1;
            double BV = Ys2 - Ys1;
            double BW = Zs2 - Zs1;

            N1 = (BU * w2 - BW * u2) / (u1 * w2 - u2 * w1);
            N2 = (BU * w1 - BW * u1) / (u1 * w2 - u2 * w1);

            X = Xs1 + N1 * u1;
            Y = ((Ys1 + N1 * v1) + (Ys2 + N2 * v2)) / 2;
            Z = Zs1 + N1 * w1;
        }

    }
}
