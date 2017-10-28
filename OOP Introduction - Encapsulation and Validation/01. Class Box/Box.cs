using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box
{
    class Box
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public Box(double length, double width, double height)
        {
           this.Length =length;
           this.Width=width;
           this.Height=height;
        }

        //Surface Area = 2lw + 2lh + 2wh

        public double SurfaceArea()
        {
            var length = this.Length;
            var width = this.Width;
            var height = this.Height;
            return (2*length*width) + (2*length*height) + (2*width*height);
        
        }

        public double LateralSurfaceArea()
        {
            return this.Length * this.Height * 2 + this.Width * this.Height * 2;
        }

        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }

    }
}
