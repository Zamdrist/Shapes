using System.Runtime.Serialization;

namespace Shapes
{
	[DataContract]
	public class Shape
    {
	    [DataMember] public double Perimeter { get; set; }
        [DataMember] public double Area { get; set; }
	    [DataMember] public string ShapeName { get; set; }
	    [DataMember] public string ShapeException { get; set; }

    }
}
