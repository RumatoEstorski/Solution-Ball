using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_Ball
{
    class Vector
    {
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Abs
        {
            get
            {
                return Math.Round(Math.Sqrt(SqAbs));
            }
        }
        public double SqAbs
        {
            get
            {
                return X * X + Y * Y;
            }
        }
        public override string ToString()
        {
            return String.Format($"X:{X};Y:{Y};Abs:{Abs}");
        }
        public Vector Projection(Vector onVector)
        {
            return this * onVector / onVector.SqAbs * onVector;
        }
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }
        public static Vector operator -(Vector v)
        {
            return new Vector(-v.X, -v.Y);
        }
        public static Vector operator -(Vector v1, Vector v2)
        {
            return v1 +(-v2);
        }
        public static Vector operator *(Vector v, double a)
        {
            return new Vector(v.X * a , v.Y * a);
        }
        public static Vector operator *(double n, Vector v)
        {
            return v * n;
        }
        public static Vector operator /(Vector v, double a)
        {
            return v * (1 / a);
        }
        public static double operator *(Vector v1, Vector v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }
        public Vector Proections(Vector v2)
        {
            return this * v2* v2/ (v2 * v2)  ;
        }
       
        public void Draw(Graphics g, Point p0, Color c)
        {
            Point p1 = new Point((int)(p0.X+ X), (int)(p0.Y + Y));
            Vector v = new Vector(X, Y);
            g.DrawLine(new Pen(c), p0, p1);
            g.DrawEllipse(new Pen(c),p1.X-2,p1.Y-2,4,4);
           
        }
        public Vector GetNorm()
        {
            return new Vector(-Y, X);
        }
        public Vector Mirror(Vector OnVector)
        {
            return this - 2 * (this.Projection(OnVector.GetNorm()));
        }
    }
}
