using System;

namespace _1.Class_Box_Data
{
    public class Box
    {
        private const double BoxPropMinValue = 0;

        private double length;
        private double width;
        private double height;

        public Box(double length,double width,double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                if (value <= BoxPropMinValue)
                {
                    throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                }
                this.length = value;
            }
        }
        public double Width
        {
            get => this.width;
            private set
            {
                if (value <= BoxPropMinValue)
                {
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get => this.height;
            private set
            {
                if (value <= BoxPropMinValue)
                {
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
                }
                this.height = value;
            }
        }

       public double SurfaceArea() // 2lw + 2lh + 2wh
        {
            double surfaceArea = 2 * (this.length * this.width + this.length * this.height + this.width * this.height);
            return surfaceArea;
        }
       public double LateralSurfaceArea() // 2lh + 2wh
        {
            double lateralSurfaceArea = 2 * (this.length * this.height + this.width * this.height);
            return lateralSurfaceArea;
        }
       public double Volume() // lwh
        {
            double volume = this.length * this.width * this.height;
            return volume;
        }
        public override string ToString()
        {
            return $"Surface Area - {this.SurfaceArea():F2}{Environment.NewLine}" +
                   $"Lateral Surface Area - {this.LateralSurfaceArea():F2}{Environment.NewLine}" +
                   $"Volume - {this.Volume():F2}{Environment.NewLine}";
        }
    }
}
