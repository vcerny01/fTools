using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Dpd.Model {

  /// <summary>
  /// Contains information related to the \&quot;source\&quot; of the shipment. The source usually refers to the system that created the shipment via the API. 
  /// </summary>
  [DataContract]
  public class Source {
    /// <summary>
    /// Uniquely identifies the source system in which the shipment was created.  This has to be filled if you have received instructions from the DPD to do so.  You can fill this even if you did not receive the instructions. We will then be able to connect the shipments with your particular system for debugging and analytics if you do so. 
    /// </summary>
    /// <value>Uniquely identifies the source system in which the shipment was created.  This has to be filled if you have received instructions from the DPD to do so.  You can fill this even if you did not receive the instructions. We will then be able to connect the shipments with your particular system for debugging and analytics if you do so. </value>
    [DataMember(Name="systemId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "systemId")]
    public string SystemId { get; set; }

    /// <summary>
    /// Gets or Sets AdditionalInfo
    /// </summary>
    [DataMember(Name="additionalInfo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "additionalInfo")]
    public Dictionary<string, Object> AdditionalInfo { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Source {\n");
      sb.Append("  SystemId: ").Append(SystemId).Append("\n");
      sb.Append("  AdditionalInfo: ").Append(AdditionalInfo).Append("\n");
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
