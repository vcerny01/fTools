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
  public class ShippingServiceList {
    /// <summary>
    /// Gets or Sets ApiServiceCombination
    /// </summary>
    [DataMember(Name="apiServiceCombination", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "apiServiceCombination")]
    public List<string> ApiServiceCombination { get; set; }

    /// <summary>
    /// Gets or Sets ServicesForCombination
    /// </summary>
    [DataMember(Name="servicesForCombination", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "servicesForCombination")]
    public List<ShippingService> ServicesForCombination { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ShippingServiceList {\n");
      sb.Append("  ApiServiceCombination: ").Append(ApiServiceCombination).Append("\n");
      sb.Append("  ServicesForCombination: ").Append(ServicesForCombination).Append("\n");
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
