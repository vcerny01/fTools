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
  public class ShippingService {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public decimal? Id { get; set; }

    /// <summary>
    /// Gets or Sets Example
    /// </summary>
    [DataMember(Name="example", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "example")]
    public ShipmentExample Example { get; set; }

    /// <summary>
    /// Gets or Sets Limitations
    /// </summary>
    [DataMember(Name="limitations", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "limitations")]
    public ShippingServiceLimitations Limitations { get; set; }

    /// <summary>
    /// Gets or Sets Code
    /// </summary>
    [DataMember(Name="code", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "code")]
    public string Code { get; set; }

    /// <summary>
    /// Gets or Sets AdditionalCode
    /// </summary>
    [DataMember(Name="additionalCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "additionalCode")]
    public string AdditionalCode { get; set; }

    /// <summary>
    /// Gets or Sets Text
    /// </summary>
    [DataMember(Name="text", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "text")]
    public string Text { get; set; }

    /// <summary>
    /// Gets or Sets Combination
    /// </summary>
    [DataMember(Name="combination", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "combination")]
    public string Combination { get; set; }

    /// <summary>
    /// Gets or Sets Prefix
    /// </summary>
    [DataMember(Name="prefix", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "prefix")]
    public string Prefix { get; set; }

    /// <summary>
    /// Gets or Sets Mark
    /// </summary>
    [DataMember(Name="mark", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mark")]
    public string Mark { get; set; }

    /// <summary>
    /// Gets or Sets BackVariant
    /// </summary>
    [DataMember(Name="backVariant", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "backVariant")]
    public ShippingServiceBackVariant BackVariant { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ShippingService {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Example: ").Append(Example).Append("\n");
      sb.Append("  Limitations: ").Append(Limitations).Append("\n");
      sb.Append("  Code: ").Append(Code).Append("\n");
      sb.Append("  AdditionalCode: ").Append(AdditionalCode).Append("\n");
      sb.Append("  Text: ").Append(Text).Append("\n");
      sb.Append("  Combination: ").Append(Combination).Append("\n");
      sb.Append("  Prefix: ").Append(Prefix).Append("\n");
      sb.Append("  Mark: ").Append(Mark).Append("\n");
      sb.Append("  BackVariant: ").Append(BackVariant).Append("\n");
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
