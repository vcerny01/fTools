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
  public class LabelDataParcelReferences {
    /// <summary>
    /// Gets or Sets Ref1
    /// </summary>
    [DataMember(Name="ref1", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ref1")]
    public string Ref1 { get; set; }

    /// <summary>
    /// Gets or Sets Ref2
    /// </summary>
    [DataMember(Name="ref2", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ref2")]
    public string Ref2 { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class LabelDataParcelReferences {\n");
      sb.Append("  Ref1: ").Append(Ref1).Append("\n");
      sb.Append("  Ref2: ").Append(Ref2).Append("\n");
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
