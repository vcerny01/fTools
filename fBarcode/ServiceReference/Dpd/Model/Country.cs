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
  public class Country {
    /// <summary>
    /// Localized country name (e.g. in Czech)
    /// </summary>
    /// <value>Localized country name (e.g. in Czech)</value>
    [DataMember(Name="localizedName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "localizedName")]
    public string LocalizedName { get; set; }

    /// <summary>
    /// Gets or Sets NumericCode
    /// </summary>
    [DataMember(Name="numericCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "numericCode")]
    public string NumericCode { get; set; }

    /// <summary>
    /// Gets or Sets Alpha2Code
    /// </summary>
    [DataMember(Name="alpha2Code", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "alpha2Code")]
    public string Alpha2Code { get; set; }

    /// <summary>
    /// Gets or Sets Alpha3Code
    /// </summary>
    [DataMember(Name="alpha3Code", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "alpha3Code")]
    public string Alpha3Code { get; set; }

    /// <summary>
    /// Gets or Sets CodInfo
    /// </summary>
    [DataMember(Name="codInfo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "codInfo")]
    public CountryCodInfo CodInfo { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Country {\n");
      sb.Append("  LocalizedName: ").Append(LocalizedName).Append("\n");
      sb.Append("  NumericCode: ").Append(NumericCode).Append("\n");
      sb.Append("  Alpha2Code: ").Append(Alpha2Code).Append("\n");
      sb.Append("  Alpha3Code: ").Append(Alpha3Code).Append("\n");
      sb.Append("  CodInfo: ").Append(CodInfo).Append("\n");
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
