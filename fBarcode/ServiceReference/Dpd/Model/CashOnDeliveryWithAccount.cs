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
  public class CashOnDeliveryWithAccount {
    /// <summary>
    /// Gets or Sets AmountCents
    /// </summary>
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
    /// Gets or Sets Payment
    /// </summary>
    [DataMember(Name="payment", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "payment")]
    public PaymentType Payment { get; set; }

    /// <summary>
    /// Gets or Sets Account
    /// </summary>
    [DataMember(Name="account", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "account")]
    public CodAccount Account { get; set; }

    /// <summary>
    /// Variable symbol of the COD payment
    /// </summary>
    /// <value>Variable symbol of the COD payment</value>
    [DataMember(Name="variableSymbol", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "variableSymbol")]
    public string VariableSymbol { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CashOnDeliveryWithAccount {\n");
      sb.Append("  AmountCents: ").Append(AmountCents).Append("\n");
      sb.Append("  Currency: ").Append(Currency).Append("\n");
      sb.Append("  Payment: ").Append(Payment).Append("\n");
      sb.Append("  Account: ").Append(Account).Append("\n");
      sb.Append("  VariableSymbol: ").Append(VariableSymbol).Append("\n");
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
