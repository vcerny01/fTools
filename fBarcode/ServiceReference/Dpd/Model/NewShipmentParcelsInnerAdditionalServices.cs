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
  public class NewShipmentParcelsInnerAdditionalServices {
    /// <summary>
    /// Gets or Sets Insurance
    /// </summary>
    [DataMember(Name="insurance", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "insurance")]
    public NewShipmentParcelsInnerAdditionalServicesInsurance Insurance { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class NewShipmentParcelsInnerAdditionalServices {\n");
      sb.Append("  Insurance: ").Append(Insurance).Append("\n");
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
