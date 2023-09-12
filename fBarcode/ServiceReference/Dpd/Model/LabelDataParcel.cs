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
  public class LabelDataParcel {
    /// <summary>
    /// Gets or Sets ParcelNo
    /// </summary>
    [DataMember(Name="parcelNo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "parcelNo")]
    public string ParcelNo { get; set; }

    /// <summary>
    /// Parcel number check character
    /// </summary>
    /// <value>Parcel number check character</value>
    [DataMember(Name="parcelNoCheck", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "parcelNoCheck")]
    public string ParcelNoCheck { get; set; }

    /// <summary>
    /// The parcel index in the shipment (MPS)
    /// </summary>
    /// <value>The parcel index in the shipment (MPS)</value>
    [DataMember(Name="index", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "index")]
    public decimal? Index { get; set; }

    /// <summary>
    /// Gets or Sets References
    /// </summary>
    [DataMember(Name="references", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "references")]
    public LabelDataParcelReferences References { get; set; }

    /// <summary>
    /// Gets or Sets WeightKilograms
    /// </summary>
    [DataMember(Name="weightKilograms", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "weightKilograms")]
    public string WeightKilograms { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class LabelDataParcel {\n");
      sb.Append("  ParcelNo: ").Append(ParcelNo).Append("\n");
      sb.Append("  ParcelNoCheck: ").Append(ParcelNoCheck).Append("\n");
      sb.Append("  Index: ").Append(Index).Append("\n");
      sb.Append("  References: ").Append(References).Append("\n");
      sb.Append("  WeightKilograms: ").Append(WeightKilograms).Append("\n");
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
