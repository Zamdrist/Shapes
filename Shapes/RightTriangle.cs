using System.Runtime.Serialization;

namespace Shapes
{
    [DataContract]
    public class RightTriangle : Shape
    {
		[DataMember] public double LegA { get; set; }
		[DataMember] public double LegB { get; set; }
		[DataMember] public double LegC { get; set; }
    }
}
