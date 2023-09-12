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
  public class RoutingData {
    /// <summary>
    /// Gets or Sets Routing
    /// </summary>
    [DataMember(Name="routing", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "routing")]
    public Routing Routing { get; set; }

    /// <summary>
    /// Gets or Sets DispatchDepot
    /// </summary>
    [DataMember(Name="dispatchDepot", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dispatchDepot")]
    public DispatchDepot DispatchDepot { get; set; }

    /// <summary>
    /// Gets or Sets DestinationDepot
    /// </summary>
    [DataMember(Name="destinationDepot", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "destinationDepot")]
    public RoutingDataDestinationDepot DestinationDepot { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RoutingData {\n");
      sb.Append("  Routing: ").Append(Routing).Append("\n");
      sb.Append("  DispatchDepot: ").Append(DispatchDepot).Append("\n");
      sb.Append("  DestinationDepot: ").Append(DestinationDepot).Append("\n");
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
