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
  public class ParcelEvent {
    /// <summary>
    /// Gets or Sets ParcelInfo
    /// </summary>
    [DataMember(Name="parcelInfo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "parcelInfo")]
    public ParcelEventParcelInfo ParcelInfo { get; set; }

    /// <summary>
    /// Individual parcel events
    /// </summary>
    /// <value>Individual parcel events</value>
    [DataMember(Name="parcelEvents", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "parcelEvents")]
    public List<ParcelEventParcelEventsInner> ParcelEvents { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ParcelEvent {\n");
      sb.Append("  ParcelInfo: ").Append(ParcelInfo).Append("\n");
      sb.Append("  ParcelEvents: ").Append(ParcelEvents).Append("\n");
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
