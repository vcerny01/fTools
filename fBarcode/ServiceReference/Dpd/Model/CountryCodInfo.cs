using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Dpd.Model {

  /// <summary>
  /// Info about COD (Cash On Delivery) services for a country
  /// </summary>
  [DataContract]
  public class CountryCodInfo {
    /// <summary>
    /// Gets or Sets Currency
    /// </summary>
    [DataMember(Name="currency", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Maximum allowed COD amount for this country  Represented in cents of the given currency 
    /// </summary>
    /// <value>Maximum allowed COD amount for this country  Represented in cents of the given currency </value>
    [DataMember(Name="maxAmountCents", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "maxAmountCents")]
    public decimal? MaxAmountCents { get; set; }

    /// <summary>
    /// Maximum allowed COD amount for card payments for this country  Represented in cents of the given currency 
    /// </summary>
    /// <value>Maximum allowed COD amount for card payments for this country  Represented in cents of the given currency </value>
    [DataMember(Name="cardMaxAmountCents", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "cardMaxAmountCents")]
    public decimal? CardMaxAmountCents { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CountryCodInfo {\n");
      sb.Append("  Currency: ").Append(Currency).Append("\n");
      sb.Append("  MaxAmountCents: ").Append(MaxAmountCents).Append("\n");
      sb.Append("  CardMaxAmountCents: ").Append(CardMaxAmountCents).Append("\n");
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
