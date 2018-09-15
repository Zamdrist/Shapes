using System.Runtime.Serialization;

namespace Shapes
{
	[DataContract]
    public class Circle : Shape
    {
		[DataMember] public double Radius { get; set; }
		[DataMember] public double Diameter { get; set; }
    }
}
