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
  public class LabelDataOrigin {
    /// <summary>
    /// Gets or Sets Sender
    /// </summary>
    [DataMember(Name="sender", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sender")]
    public LabelDataOriginSender Sender { get; set; }

    /// <summary>
    /// Gets or Sets DispatchDepot
    /// </summary>
    [DataMember(Name="dispatchDepot", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dispatchDepot")]
    public Depot DispatchDepot { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class LabelDataOrigin {\n");
      sb.Append("  Sender: ").Append(Sender).Append("\n");
      sb.Append("  DispatchDepot: ").Append(DispatchDepot).Append("\n");
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
