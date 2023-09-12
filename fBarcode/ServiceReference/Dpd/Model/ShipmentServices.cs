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
  public class ShipmentServices {
    /// <summary>
    /// Gets or Sets ServiceCode
    /// </summary>
    [DataMember(Name="serviceCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "serviceCode")]
    public string ServiceCode { get; set; }

    /// <summary>
    /// Gets or Sets ServiceCombination
    /// </summary>
    [DataMember(Name="serviceCombination", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "serviceCombination")]
    public string ServiceCombination { get; set; }

    /// <summary>
    /// Gets or Sets SelectedServices
    /// </summary>
    [DataMember(Name="selectedServices", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "selectedServices")]
    public ShipmentServicesSelectedServices SelectedServices { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ShipmentServices {\n");
      sb.Append("  ServiceCode: ").Append(ServiceCode).Append("\n");
      sb.Append("  ServiceCombination: ").Append(ServiceCombination).Append("\n");
      sb.Append("  SelectedServices: ").Append(SelectedServices).Append("\n");
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
