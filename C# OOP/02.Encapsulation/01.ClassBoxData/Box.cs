using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double lenght;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.Height = height;
        }
        private double Lenght
        {
            get { return lenght; }
            set
            {
                    if (value > 0)
                    {
                        lenght = value;
                        return;
                    }
                    throw new Exception("Length cannot be zero or negative.");             
            }
        }
        private double Width
        {
            get { return width; }
            set
            {
                if (value > 0)
                {
                    width = value;
                    return;
                }

                throw new Exception("Width cannot be zero or negative.");
            }
        }
        private double Height
        {
            get { return height; }
            set
            {
                if (value > 0)
                {
                    height = value;
                    return;
                }

                throw new Exception("Height cannot be zero or negative.");
            }
        }

        public string SurfaceArea()
        {
            double result = 2 * (lenght * width + lenght * height + width * height);
            return $"Surface Area - {result:f2}";
        }
        public string LateralSurfaceArea()
        {
            double result = 2 * (lenght * height + width * height);
            return $"Lateral Surface Area - {result:f2}";
        }
        public string Volume()
        {
            double result = lenght * width * height;
            return $"Volume - {result:f2}";
        }
    }
}
