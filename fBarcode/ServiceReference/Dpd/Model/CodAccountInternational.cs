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
  public class CodAccountInternational {
    /// <summary>
    /// The IBAN of the COD account
    /// </summary>
    /// <value>The IBAN of the COD account</value>
    [DataMember(Name="IBAN", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "IBAN")]
    public string IBAN { get; set; }

    /// <summary>
    /// BIC - The SWIFT Address assigned to a bank
    /// </summary>
    /// <value>BIC - The SWIFT Address assigned to a bank</value>
    [DataMember(Name="BIC", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "BIC")]
    public string BIC { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CodAccountInternational {\n");
      sb.Append("  IBAN: ").Append(IBAN).Append("\n");
      sb.Append("  BIC: ").Append(BIC).Append("\n");
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
