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
  public class ShippingServiceLimitationsCountryLimitationsOriginCountries {
    /// <summary>
    /// Gets or Sets IsoAlpha2
    /// </summary>
    [DataMember(Name="isoAlpha2", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isoAlpha2")]
    public List<string> IsoAlpha2 { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ShippingServiceLimitationsCountryLimitationsOriginCountries {\n");
      sb.Append("  IsoAlpha2: ").Append(IsoAlpha2).Append("\n");
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
