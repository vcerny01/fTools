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
  public class SubjectInfo {
    /// <summary>
    /// Gets or Sets Name1
    /// </summary>
    [DataMember(Name="name1", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name1")]
    public string Name1 { get; set; }

    /// <summary>
    /// Gets or Sets Name2
    /// </summary>
    [DataMember(Name="name2", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name2")]
    public string Name2 { get; set; }

    /// <summary>
    /// Gets or Sets Contact
    /// </summary>
    [DataMember(Name="contact", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "contact")]
    public SubjectInfoContact Contact { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class SubjectInfo {\n");
      sb.Append("  Name1: ").Append(Name1).Append("\n");
      sb.Append("  Name2: ").Append(Name2).Append("\n");
      sb.Append("  Contact: ").Append(Contact).Append("\n");
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
