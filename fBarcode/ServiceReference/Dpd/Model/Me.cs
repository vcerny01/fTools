using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Dpd.Model {

  /// <summary>
  /// The first active customer of the user account and their list of addresses
  /// </summary>
  [DataContract]
  public class Me {
    /// <summary>
    /// Gets or Sets UserAccount
    /// </summary>
    [DataMember(Name="userAccount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "userAccount")]
    public UserAccount UserAccount { get; set; }

    /// <summary>
    /// Gets or Sets Customers
    /// </summary>
    [DataMember(Name="customers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "customers")]
    public List<MeCustomersInner> Customers { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Me {\n");
      sb.Append("  UserAccount: ").Append(UserAccount).Append("\n");
      sb.Append("  Customers: ").Append(Customers).Append("\n");
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
