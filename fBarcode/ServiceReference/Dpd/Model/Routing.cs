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
  public class Routing {
    /// <summary>
    /// Gets or Sets RoutingText
    /// </summary>
    [DataMember(Name="routingText", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "routingText")]
    public string RoutingText { get; set; }

    /// <summary>
    /// Gets or Sets DSORT
    /// </summary>
    [DataMember(Name="DSORT", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "DSORT")]
    public string DSORT { get; set; }

    /// <summary>
    /// Gets or Sets OSORT
    /// </summary>
    [DataMember(Name="OSORT", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "OSORT")]
    public string OSORT { get; set; }

    /// <summary>
    /// Gets or Sets SSORT
    /// </summary>
    [DataMember(Name="SSORT", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "SSORT")]
    public string SSORT { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Routing {\n");
      sb.Append("  RoutingText: ").Append(RoutingText).Append("\n");
      sb.Append("  DSORT: ").Append(DSORT).Append("\n");
      sb.Append("  OSORT: ").Append(OSORT).Append("\n");
      sb.Append("  SSORT: ").Append(SSORT).Append("\n");
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
