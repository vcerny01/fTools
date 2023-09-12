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
  public class ShippingServiceLimitations {
    /// <summary>
    /// Gets or Sets WeightLimit
    /// </summary>
    [DataMember(Name="weightLimit", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "weightLimit")]
    public ShippingServiceLimitationsWeightLimit WeightLimit { get; set; }

    /// <summary>
    /// Gets or Sets NoSameCountry
    /// </summary>
    [DataMember(Name="noSameCountry", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "noSameCountry")]
    public bool? NoSameCountry { get; set; }

    /// <summary>
    /// Gets or Sets SupportedShipmentTypes
    /// </summary>
    [DataMember(Name="supportedShipmentTypes", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "supportedShipmentTypes")]
    public List<ShipmentType> SupportedShipmentTypes { get; set; }

    /// <summary>
    /// Gets or Sets MpsDisabled
    /// </summary>
    [DataMember(Name="mpsDisabled", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mpsDisabled")]
    public ShippingServiceLimitationsMpsDisabled MpsDisabled { get; set; }

    /// <summary>
    /// Gets or Sets RequiredContactInfo
    /// </summary>
    [DataMember(Name="requiredContactInfo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "requiredContactInfo")]
    public ShippingServiceLimitationsRequiredContactInfo RequiredContactInfo { get; set; }

    /// <summary>
    /// Gets or Sets Printing
    /// </summary>
    [DataMember(Name="printing", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "printing")]
    public string Printing { get; set; }

    /// <summary>
    /// Gets or Sets CountryLimitations
    /// </summary>
    [DataMember(Name="countryLimitations", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "countryLimitations")]
    public ShippingServiceLimitationsCountryLimitations CountryLimitations { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ShippingServiceLimitations {\n");
      sb.Append("  WeightLimit: ").Append(WeightLimit).Append("\n");
      sb.Append("  NoSameCountry: ").Append(NoSameCountry).Append("\n");
      sb.Append("  SupportedShipmentTypes: ").Append(SupportedShipmentTypes).Append("\n");
      sb.Append("  MpsDisabled: ").Append(MpsDisabled).Append("\n");
      sb.Append("  RequiredContactInfo: ").Append(RequiredContactInfo).Append("\n");
      sb.Append("  Printing: ").Append(Printing).Append("\n");
      sb.Append("  CountryLimitations: ").Append(CountryLimitations).Append("\n");
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
