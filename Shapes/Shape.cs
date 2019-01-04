// ReSharper disable once RedundantUsingDirective
using System;
namespace Shapes
{
    abstract class Shape
    {
        protected Shape()
        {
            this.CalculateShapeDimensions();
        }
        public abstract void CalculateShapeDimensions();
        
         public double Area { get; set; }
         public string ShapeName { get; set; }
         public string ShapeValidation { get; set; }


    }
}
