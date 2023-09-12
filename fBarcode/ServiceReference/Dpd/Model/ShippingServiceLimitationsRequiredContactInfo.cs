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
  public class ShippingServiceLimitationsRequiredContactInfo {
    /// <summary>
    /// Gets or Sets OneOf
    /// </summary>
    [DataMember(Name="oneOf", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "oneOf")]
    public List<string> OneOf { get; set; }

    /// <summary>
    /// Gets or Sets AllOf
    /// </summary>
    [DataMember(Name="allOf", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "allOf")]
    public List<string> AllOf { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ShippingServiceLimitationsRequiredContactInfo {\n");
      sb.Append("  OneOf: ").Append(OneOf).Append("\n");
      sb.Append("  AllOf: ").Append(AllOf).Append("\n");
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
