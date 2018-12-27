// ReSharper disable once RedundantUsingDirective
using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Shapes
{

    [DataContract]
    public class Shape : IShape
    {

        [DataMember] public double Area { get; set; }
        [DataMember] public string ShapeName { get; set; }
        [DataMember] public string ShapeValidation { get; set; }

        public string SerializeShape()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

    }
}
