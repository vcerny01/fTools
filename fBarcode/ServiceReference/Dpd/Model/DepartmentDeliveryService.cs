using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Dpd.Model {

  /// <summary>
  /// The shipment is delivered to a department without any personal identification.  Internal info: Setting identification to \&quot;false\&quot; (the only option currently) equals the \&quot;1\&quot; type in the old GeoAPI 
  /// </summary>
  [DataContract]
  public class DepartmentDeliveryService {
    /// <summary>
    /// The building where the shipment is delivered to
    /// </summary>
    /// <value>The building where the shipment is delivered to</value>
    [DataMember(Name="building", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "building")]
    public string Building { get; set; }

    /// <summary>
    /// The floor where the shipment is delivered to
    /// </summary>
    /// <value>The floor where the shipment is delivered to</value>
    [DataMember(Name="floor", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "floor")]
    public string Floor { get; set; }

    /// <summary>
    /// The department where the shipment is delivered to
    /// </summary>
    /// <value>The department where the shipment is delivered to</value>
    [DataMember(Name="department", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "department")]
    public string Department { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class DepartmentDeliveryService {\n");
      sb.Append("  Building: ").Append(Building).Append("\n");
      sb.Append("  Floor: ").Append(Floor).Append("\n");
      sb.Append("  Department: ").Append(Department).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
