using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Dpd.Model {

  /// <summary>
  /// The account to which the COD payment should be sent
  /// </summary>
  [DataContract]
  public class CodAccount {
    /// <summary>
    /// Code of your bank    Deprecated: Use the \"domestic\" object instead. 
    /// </summary>
    /// <value>Code of your bank    Deprecated: Use the \"domestic\" object instead. </value>
    [DataMember(Name="bankCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "bankCode")]
    public string BankCode { get; set; }

    /// <summary>
    /// Your custom bank designation (might be displayed to the customer).    We suggest you use capital letters and numbers.    Deprecated: Use the \"domestic\" object instead. 
    /// </summary>
    /// <value>Your custom bank designation (might be displayed to the customer).    We suggest you use capital letters and numbers.    Deprecated: Use the \"domestic\" object instead. </value>
    [DataMember(Name="bankName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "bankName")]
    public string BankName { get; set; }

    /// <summary>
    /// The account number without bankCode    Deprecated: Use the \"domestic\" object instead. 
    /// </summary>
    /// <value>The account number without bankCode    Deprecated: Use the \"domestic\" object instead. </value>
    [DataMember(Name="accountNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "accountNumber")]
    public string AccountNumber { get; set; }

    /// <summary>
    /// Your custom account number name for organizational purposes.    We suggest using only capital letters and numbers.    Deprecated: Use the \"domestic\" object instead. 
    /// </summary>
    /// <value>Your custom account number name for organizational purposes.    We suggest using only capital letters and numbers.    Deprecated: Use the \"domestic\" object instead. </value>
    [DataMember(Name="accountName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "accountName")]
    public string AccountName { get; set; }

    /// <summary>
    /// Gets or Sets Domestic
    /// </summary>
    [DataMember(Name="domestic", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "domestic")]
    public CodAccountDomestic Domestic { get; set; }

    /// <summary>
    /// Gets or Sets International
    /// </summary>
    [DataMember(Name="international", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "international")]
    public CodAccountInternational International { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CodAccount {\n");
      sb.Append("  BankCode: ").Append(BankCode).Append("\n");
      sb.Append("  BankName: ").Append(BankName).Append("\n");
      sb.Append("  AccountNumber: ").Append(AccountNumber).Append("\n");
      sb.Append("  AccountName: ").Append(AccountName).Append("\n");
      sb.Append("  Domestic: ").Append(Domestic).Append("\n");
      sb.Append("  International: ").Append(International).Append("\n");
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
