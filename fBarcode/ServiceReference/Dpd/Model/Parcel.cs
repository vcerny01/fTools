using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Dpd.Model {

  /// <summary>
  /// For more info about parcels see the [Parcel Number](#/ParcelNo)
  /// </summary>
  [DataContract]
  public class Parcel {
    /// <summary>
    /// Gets or Sets ParcelNumbers
    /// </summary>
    [DataMember(Name="parcelNumbers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "parcelNumbers")]
    public ParcelNumbers ParcelNumbers { get; set; }

    /// <summary>
    /// Gets or Sets References
    /// </summary>
    [DataMember(Name="references", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "references")]
    public ParcelReferences References { get; set; }

    /// <summary>
    /// Gets or Sets Insurance
    /// </summary>
    [DataMember(Name="insurance", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "insurance")]
    public Insurance Insurance { get; set; }

    /// <summary>
    /// Are the labels for this parcel already printed?
    /// </summary>
    /// <value>Are the labels for this parcel already printed?</value>
    [DataMember(Name="isPrinted", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isPrinted")]
    public bool? IsPrinted { get; set; }

    /// <summary>
    /// Gets or Sets WeightGrams
    /// </summary>
    [DataMember(Name="weightGrams", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "weightGrams")]
    public decimal? WeightGrams { get; set; }

    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public decimal? Id { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Parcel {\n");
      sb.Append("  ParcelNumbers: ").Append(ParcelNumbers).Append("\n");
      sb.Append("  References: ").Append(References).Append("\n");
      sb.Append("  Insurance: ").Append(Insurance).Append("\n");
      sb.Append("  IsPrinted: ").Append(IsPrinted).Append("\n");
      sb.Append("  WeightGrams: ").Append(WeightGrams).Append("\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
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
