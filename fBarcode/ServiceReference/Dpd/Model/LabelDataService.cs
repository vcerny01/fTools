using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Dpd.Model {

  /// <summary>
  /// The shipping service/product specification
  /// </summary>
  [DataContract]
  public class LabelDataService {
    /// <summary>
    /// Gets or Sets Combination
    /// </summary>
    [DataMember(Name="combination", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "combination")]
    public string Combination { get; set; }

    /// <summary>
    /// Gets or Sets Code
    /// </summary>
    [DataMember(Name="code", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "code")]
    public string Code { get; set; }

    /// <summary>
    /// Gets or Sets AdditionalCode
    /// </summary>
    [DataMember(Name="additionalCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "additionalCode")]
    public string AdditionalCode { get; set; }

    /// <summary>
    /// A shipping service mark (It is rarely used)
    /// </summary>
    /// <value>A shipping service mark (It is rarely used)</value>
    [DataMember(Name="mark", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mark")]
    public string Mark { get; set; }

    /// <summary>
    /// Service Text used in the routing part of the Label
    /// </summary>
    /// <value>Service Text used in the routing part of the Label</value>
    [DataMember(Name="text", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "text")]
    public string Text { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class LabelDataService {\n");
      sb.Append("  Combination: ").Append(Combination).Append("\n");
      sb.Append("  Code: ").Append(Code).Append("\n");
      sb.Append("  AdditionalCode: ").Append(AdditionalCode).Append("\n");
      sb.Append("  Mark: ").Append(Mark).Append("\n");
      sb.Append("  Text: ").Append(Text).Append("\n");
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
