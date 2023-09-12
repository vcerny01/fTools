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
  public class CustomerAddressIdentOneOf1 {
    /// <summary>
    /// Gets or Sets It4emId
    /// </summary>
    [DataMember(Name="it4emId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "it4emId")]
    public decimal? It4emId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CustomerAddressIdentOneOf1 {\n");
      sb.Append("  It4emId: ").Append(It4emId).Append("\n");
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
