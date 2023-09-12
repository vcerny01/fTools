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
  public class ShippingServiceLimitationsMpsDisabledOneOf {
    /// <summary>
    /// Gets or Sets TimeFrames
    /// </summary>
    [DataMember(Name="timeFrames", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "timeFrames")]
    public List<ShippingServiceLimitationsMpsDisabledOneOfTimeFramesInner> TimeFrames { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ShippingServiceLimitationsMpsDisabledOneOf {\n");
      sb.Append("  TimeFrames: ").Append(TimeFrames).Append("\n");
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
