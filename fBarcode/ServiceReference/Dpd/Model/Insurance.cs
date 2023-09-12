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
  public class Insurance {
    /// <summary>
    /// Units of the specified currency in cents. For example 125 units of EUR is 1.25 EUR. 
    /// </summary>
    /// <value>Units of the specified currency in cents. For example 125 units of EUR is 1.25 EUR. </value>
    [DataMember(Name="amountCents", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "amountCents")]
    public decimal? AmountCents { get; set; }

    /// <summary>
    /// Gets or Sets Currency
    /// </summary>
    [DataMember(Name="currency", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "currency")]
    public string Currency { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Insurance {\n");
      sb.Append("  AmountCents: ").Append(AmountCents).Append("\n");
      sb.Append("  Currency: ").Append(Currency).Append("\n");
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
