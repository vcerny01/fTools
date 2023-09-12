using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Dpd.Model {

  /// <summary>
  /// Country specific bank account information.  This is currently reserved for CZ based bank accounts!    If you provide any non CZ based bank acccount that will pass validation, it might get used for domestic CZ payments! 
  /// </summary>
  [DataContract]
  public class CodAccountDomestic {
    /// <summary>
    /// Code of your bank
    /// </summary>
    /// <value>Code of your bank</value>
    [DataMember(Name="bankCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "bankCode")]
    public string BankCode { get; set; }

    /// <summary>
    /// Your custom bank designation (might be displayed to the customer).  We suggest you use capital letters and numbers. 
    /// </summary>
    /// <value>Your custom bank designation (might be displayed to the customer).  We suggest you use capital letters and numbers. </value>
    [DataMember(Name="bankName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "bankName")]
    public string BankName { get; set; }

    /// <summary>
    /// The account number without bankCode
    /// </summary>
    /// <value>The account number without bankCode</value>
    [DataMember(Name="accountNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "accountNumber")]
    public string AccountNumber { get; set; }

    /// <summary>
    /// Your custom account number name for organizational purposes.  We suggest using only capital letters and numbers. 
    /// </summary>
    /// <value>Your custom account number name for organizational purposes.  We suggest using only capital letters and numbers. </value>
    [DataMember(Name="accountName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "accountName")]
    public string AccountName { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CodAccountDomestic {\n");
      sb.Append("  BankCode: ").Append(BankCode).Append("\n");
      sb.Append("  BankName: ").Append(BankName).Append("\n");
      sb.Append("  AccountNumber: ").Append(AccountNumber).Append("\n");
      sb.Append("  AccountName: ").Append(AccountName).Append("\n");
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
