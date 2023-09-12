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
  public class NewShipmentParcelsInner {
    /// <summary>
    /// Gets or Sets ParcelNumber
    /// </summary>
    [DataMember(Name="parcelNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "parcelNumber")]
    public AllOfNewShipmentParcelsInnerParcelNumber ParcelNumber { get; set; }

    /// <summary>
    /// Gets or Sets BackParcelNumber
    /// </summary>
    [DataMember(Name="backParcelNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "backParcelNumber")]
    public AllOfNewShipmentParcelsInnerBackParcelNumber BackParcelNumber { get; set; }

    /// <summary>
    /// Gets or Sets References
    /// </summary>
    [DataMember(Name="references", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "references")]
    public ParcelReferences References { get; set; }

    /// <summary>
    /// Gets or Sets AdditionalServices
    /// </summary>
    [DataMember(Name="additionalServices", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "additionalServices")]
    public NewShipmentParcelsInnerAdditionalServices AdditionalServices { get; set; }

    /// <summary>
    /// Gets or Sets WeightGrams
    /// </summary>
    [DataMember(Name="weightGrams", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "weightGrams")]
    public decimal? WeightGrams { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class NewShipmentParcelsInner {\n");
      sb.Append("  ParcelNumber: ").Append(ParcelNumber).Append("\n");
      sb.Append("  BackParcelNumber: ").Append(BackParcelNumber).Append("\n");
      sb.Append("  References: ").Append(References).Append("\n");
      sb.Append("  AdditionalServices: ").Append(AdditionalServices).Append("\n");
      sb.Append("  WeightGrams: ").Append(WeightGrams).Append("\n");
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
