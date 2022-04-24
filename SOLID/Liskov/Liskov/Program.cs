using System;

namespace Liskov
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle(3, 4);
            Console.WriteLine(Area(r));
            Rectangle s = new Square();
            s.width = 4;
            Console.WriteLine(Area(s));
        }
        public static int Area(Rectangle r)
        {
            return r.width * r.height;
        }

        public class Rectangle
        {
            public virtual int width { get; set; }
            public virtual int height { get; set; }
            public Rectangle(int w, int h)
            {
                width = w;
                height = h;
            }
            public Rectangle()
            {
            }
        }

        public class Square : Rectangle
        {
            public override int width
            {
                set
                {
                    base.width = base.height = value;
                }
            }
            public override int height
            {
                set
                {
                    base.height = base.width = value;
                }
            }
        }
    }
}
