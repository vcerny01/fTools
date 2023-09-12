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
  public class ParcelEventParcelInfoRouting {
    /// <summary>
    /// Gets or Sets Main
    /// </summary>
    [DataMember(Name="main", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "main")]
    public RoutingData Main { get; set; }

    /// <summary>
    /// Gets or Sets Back
    /// </summary>
    [DataMember(Name="back", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "back")]
    public RoutingData Back { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ParcelEventParcelInfoRouting {\n");
      sb.Append("  Main: ").Append(Main).Append("\n");
      sb.Append("  Back: ").Append(Back).Append("\n");
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
