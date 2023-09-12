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
  public class ParcelsTrackingPostRequest {
    /// <summary>
    /// Parcel identifiers
    /// </summary>
    /// <value>Parcel identifiers</value>
    [DataMember(Name="parcels", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "parcels")]
    public List<string> Parcels { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ParcelsTrackingPostRequest {\n");
      sb.Append("  Parcels: ").Append(Parcels).Append("\n");
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
