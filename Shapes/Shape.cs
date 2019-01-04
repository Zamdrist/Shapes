// ReSharper disable once RedundantUsingDirective
using System;
namespace Shapes
{
    public abstract class Shape
    {
        protected Shape()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            this.CalculateShapeDimensions();
        }
        public abstract void CalculateShapeDimensions();
        
         public double Area { get; set; }
         public string ShapeName { get; set; }
         public string ShapeValidation { get; set; }


    }
}
