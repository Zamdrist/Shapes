using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Shapes
{

    [DataContract]
    public class Shape : ISerialized
    {
        [DataMember] public double Perimeter { get; set; }
        [DataMember] public double Area { get; set; }
        [DataMember] public string ShapeName { get; set; }
        [DataMember] public string ShapeException { get; set; }

	    public string SerializeShape()
	    {
		    return JsonConvert.SerializeObject(this, Formatting.Indented);
	    }
    }
}
