using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Dpd.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class RoutingDataDestinationDepotDepotNumbers {
    /// <summary>
    /// Gets or Sets LongNumber
    /// </summary>
    [DataMember(Name="longNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "longNumber")]
    public string LongNumber { get; set; }

    /// <summary>
    /// Gets or Sets ShortNumber
    /// </summary>
    [DataMember(Name="shortNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shortNumber")]
    public string ShortNumber { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RoutingDataDestinationDepotDepotNumbers {\n");
      sb.Append("  LongNumber: ").Append(LongNumber).Append("\n");
      sb.Append("  ShortNumber: ").Append(ShortNumber).Append("\n");
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
