using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Dpd.Model {

  /// <summary>
  /// The pickup is ordered to a selected customer address (your address).  The courier can/will pick up all parcels for which you have printed labels. 
  /// </summary>
  [DataContract]
  public class AddressPickupOrderSpecs {
    /// <summary>
    /// Gets or Sets CustomerAddress
    /// </summary>
    [DataMember(Name="customerAddress", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "customerAddress")]
    public CustomerAddressIdent CustomerAddress { get; set; }

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
      sb.Append("class AddressPickupOrderSpecs {\n");
      sb.Append("  CustomerAddress: ").Append(CustomerAddress).Append("\n");
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
