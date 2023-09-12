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
  public class LabelData {
    /// <summary>
    /// Gets or Sets Delivery
    /// </summary>
    [DataMember(Name="delivery", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "delivery")]
    public LabelDataDelivery Delivery { get; set; }

    /// <summary>
    /// Gets or Sets Origin
    /// </summary>
    [DataMember(Name="origin", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "origin")]
    public LabelDataOrigin Origin { get; set; }

    /// <summary>
    /// Gets or Sets Parcel
    /// </summary>
    [DataMember(Name="parcel", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "parcel")]
    public LabelDataParcel Parcel { get; set; }

    /// <summary>
    /// The number of parcels inside the shipment
    /// </summary>
    /// <value>The number of parcels inside the shipment</value>
    [DataMember(Name="parcelCount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "parcelCount")]
    public decimal? ParcelCount { get; set; }

    /// <summary>
    /// Gets or Sets Routing
    /// </summary>
    [DataMember(Name="routing", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "routing")]
    public Routing Routing { get; set; }

    /// <summary>
    /// Gets or Sets Service
    /// </summary>
    [DataMember(Name="service", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "service")]
    public LabelDataService Service { get; set; }

    /// <summary>
    /// The barcode to be printed on the label
    /// </summary>
    /// <value>The barcode to be printed on the label</value>
    [DataMember(Name="barCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "barCode")]
    public string BarCode { get; set; }

    /// <summary>
    /// The text to be printed above the label
    /// </summary>
    /// <value>The text to be printed above the label</value>
    [DataMember(Name="barCodeText", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "barCodeText")]
    public string BarCodeText { get; set; }

    /// <summary>
    /// Gets or Sets Cod
    /// </summary>
    [DataMember(Name="cod", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "cod")]
    public LabelDataCod Cod { get; set; }

    /// <summary>
    /// Gets or Sets DepartmentDelivery
    /// </summary>
    [DataMember(Name="departmentDelivery", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "departmentDelivery")]
    public DepartmentDeliveryService DepartmentDelivery { get; set; }

    /// <summary>
    /// Gets or Sets PersonalIdentification
    /// </summary>
    [DataMember(Name="personalIdentification", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "personalIdentification")]
    public PersonalIdentificationService PersonalIdentification { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class LabelData {\n");
      sb.Append("  Delivery: ").Append(Delivery).Append("\n");
      sb.Append("  Origin: ").Append(Origin).Append("\n");
      sb.Append("  Parcel: ").Append(Parcel).Append("\n");
      sb.Append("  ParcelCount: ").Append(ParcelCount).Append("\n");
      sb.Append("  Routing: ").Append(Routing).Append("\n");
      sb.Append("  Service: ").Append(Service).Append("\n");
      sb.Append("  BarCode: ").Append(BarCode).Append("\n");
      sb.Append("  BarCodeText: ").Append(BarCodeText).Append("\n");
      sb.Append("  Cod: ").Append(Cod).Append("\n");
      sb.Append("  DepartmentDelivery: ").Append(DepartmentDelivery).Append("\n");
      sb.Append("  PersonalIdentification: ").Append(PersonalIdentification).Append("\n");
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
