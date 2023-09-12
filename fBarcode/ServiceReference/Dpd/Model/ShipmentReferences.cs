using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Dpd.Model {

  /// <summary>
  /// A reference is an internal information for your use cases.  Shipment references are only used in the data, not printed to any labels. 
  /// </summary>
  [DataContract]
  public class ShipmentReferences {
    /// <summary>
    /// Gets or Sets Ref1
    /// </summary>
    [DataMember(Name="ref1", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ref1")]
    public string Ref1 { get; set; }

    /// <summary>
    /// Gets or Sets Ref2
    /// </summary>
    [DataMember(Name="ref2", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ref2")]
    public string Ref2 { get; set; }

    /// <summary>
    /// Gets or Sets Ref3
    /// </summary>
    [DataMember(Name="ref3", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ref3")]
    public string Ref3 { get; set; }

    /// <summary>
    /// Gets or Sets Ref4
    /// </summary>
    [DataMember(Name="ref4", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ref4")]
    public string Ref4 { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ShipmentReferences {\n");
      sb.Append("  Ref1: ").Append(Ref1).Append("\n");
      sb.Append("  Ref2: ").Append(Ref2).Append("\n");
      sb.Append("  Ref3: ").Append(Ref3).Append("\n");
      sb.Append("  Ref4: ").Append(Ref4).Append("\n");
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
