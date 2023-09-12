using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Dpd.Model {

  /// <summary>
  /// The pickup is ordered for a specific collection parcel(s).  The labels are printed by the DPD. 
  /// </summary>
  [DataContract]
  public class ParcelPickupOrderSpecs {
    /// <summary>
    /// Gets or Sets Parcel
    /// </summary>
    [DataMember(Name="parcel", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "parcel")]
    public ParcelIdent Parcel { get; set; }

    /// <summary>
    /// Gets or Sets Date
    /// </summary>
    [DataMember(Name="date", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "date")]
    public string Date { get; set; }

    /// <summary>
    /// Gets or Sets Note
    /// </summary>
    [DataMember(Name="note", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "note")]
    public string Note { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ParcelPickupOrderSpecs {\n");
      sb.Append("  Parcel: ").Append(Parcel).Append("\n");
      sb.Append("  Date: ").Append(Date).Append("\n");
      sb.Append("  Note: ").Append(Note).Append("\n");
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
