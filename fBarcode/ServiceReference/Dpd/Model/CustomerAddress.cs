using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Dpd.Model {

  /// <summary>
  /// Each user account, can have multiple customers (identified by DSW).   And each customer can have multiple customer addresses.   These addresses can for instance represent the pickup addresses for pickup services. 
  /// </summary>
  [DataContract]
  public class CustomerAddress {
    /// <summary>
    /// Gets or Sets It4emId
    /// </summary>
    [DataMember(Name="it4emId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "it4emId")]
    public decimal? It4emId { get; set; }

    /// <summary>
    /// Gets or Sets Info
    /// </summary>
    [DataMember(Name="info", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "info")]
    public SubjectInfo Info { get; set; }

    /// <summary>
    /// Your registered address.  You can for instance create (parcel) pickup orders on these addresses. 
    /// </summary>
    /// <value>Your registered address.  You can for instance create (parcel) pickup orders on these addresses. </value>
    [DataMember(Name="address", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "address")]
    public AllOfCustomerAddressAddress Address { get; set; }

    /// <summary>
    /// Gets or Sets IsActive
    /// </summary>
    [DataMember(Name="isActive", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isActive")]
    public bool? IsActive { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CustomerAddress {\n");
      sb.Append("  It4emId: ").Append(It4emId).Append("\n");
      sb.Append("  Info: ").Append(Info).Append("\n");
      sb.Append("  Address: ").Append(Address).Append("\n");
      sb.Append("  IsActive: ").Append(IsActive).Append("\n");
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
