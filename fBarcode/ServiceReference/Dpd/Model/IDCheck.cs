using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Dpd.Model {

  /// <summary>
  /// This data is used when a check against a personal ID card is required
  /// </summary>
  [DataContract]
  public class IDCheck {
    /// <summary>
    /// The name of the person to be checked
    /// </summary>
    /// <value>The name of the person to be checked</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// The personal identification card number of the receiving person
    /// </summary>
    /// <value>The personal identification card number of the receiving person</value>
    [DataMember(Name="personalId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "personalId")]
    public string PersonalId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class IDCheck {\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  PersonalId: ").Append(PersonalId).Append("\n");
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
