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
  public class LabelDataOriginSender {
    /// <summary>
    /// Gets or Sets Name1
    /// </summary>
    [DataMember(Name="name1", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name1")]
    public string Name1 { get; set; }

    /// <summary>
    /// Gets or Sets Name2
    /// </summary>
    [DataMember(Name="name2", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name2")]
    public string Name2 { get; set; }

    /// <summary>
    /// Gets or Sets Street
    /// </summary>
    [DataMember(Name="street", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "street")]
    public string Street { get; set; }

    /// <summary>
    /// Gets or Sets City
    /// </summary>
    [DataMember(Name="city", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "city")]
    public string City { get; set; }

    /// <summary>
    /// Gets or Sets CountryAlpha2
    /// </summary>
    [DataMember(Name="countryAlpha2", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "countryAlpha2")]
    public string CountryAlpha2 { get; set; }

    /// <summary>
    /// Gets or Sets PostalCode
    /// </summary>
    [DataMember(Name="postalCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "postalCode")]
    public string PostalCode { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class LabelDataOriginSender {\n");
      sb.Append("  Name1: ").Append(Name1).Append("\n");
      sb.Append("  Name2: ").Append(Name2).Append("\n");
      sb.Append("  Street: ").Append(Street).Append("\n");
      sb.Append("  City: ").Append(City).Append("\n");
      sb.Append("  CountryAlpha2: ").Append(CountryAlpha2).Append("\n");
      sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
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