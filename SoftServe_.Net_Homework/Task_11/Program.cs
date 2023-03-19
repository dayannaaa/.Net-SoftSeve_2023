using System.Drawing;
using System.Reflection;

namespace Task_11
{
    public struct Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class Shape
    {
        public string Type { get; set; }
        public virtual void Print()
        {
            Console.WriteLine($"Type figure is {Type}");
        }
    }

    class Line : Shape
    {
        public Coordinate StartPoint { get; set; }
        public Coordinate EndPoint { get; set; }

        public Line()
        {
            this.Type = "Line";
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Line from ({StartPoint.X}, {StartPoint.Y}) to ({EndPoint.X}, {EndPoint.Y})");
            Console.WriteLine("\n\n");
        }

    }

    public class Rectangle : Shape
    {
        public Coordinate UpperLeftCorner { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle()
        {
            this.Type = "Rectangle";
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Rectangle at ({UpperLeftCorner.X}, {UpperLeftCorner.Y}), width {Width}, height {Height}");
            Console.WriteLine("\n\n");
        }
    }

    public class Polyline : Shape
    {
        public Coordinate[] Points { get; set; }

        public Polyline()
        {
            this.Type = "Polyline";
        }
        public override void Print()
        {
            base.Print();
            Console.Write("Polyline with points: ");
            foreach (Coordinate point in Points)
            {
                Console.Write($"({point.X}, {point.Y}) ");
            }
            Console.WriteLine("\n\n");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Line line = new Line
            {
                StartPoint = new Coordinate { X = 0, Y = 0 },
                EndPoint = new Coordinate { X = 5, Y = 5 }
            };
            line.Print();

            Rectangle rectangle = new Rectangle { UpperLeftCorner = new Coordinate { X = 2, Y = 2 }, Width = 4, Height = 3 };
            rectangle.Print();

            Polyline polyline = new Polyline { Points = new Coordinate[] { new Coordinate { X = 1, Y = 1 }, new Coordinate { X = 3, Y = 2 }, new Coordinate { X = 5, Y = 4 } } };
            polyline.Print();

          

        }
    }
}