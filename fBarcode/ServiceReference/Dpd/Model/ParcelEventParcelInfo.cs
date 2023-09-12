using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Dpd.Model {

  /// <summary>
  /// Info about the parcel
  /// </summary>
  [DataContract]
  public class ParcelEventParcelInfo {
    /// <summary>
    /// Gets or Sets Sender
    /// </summary>
    [DataMember(Name="sender", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sender")]
    public Sender Sender { get; set; }

    /// <summary>
    /// Gets or Sets Receiver
    /// </summary>
    [DataMember(Name="receiver", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "receiver")]
    public Receiver Receiver { get; set; }

    /// <summary>
    /// Gets or Sets DeclaredSender
    /// </summary>
    [DataMember(Name="declaredSender", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "declaredSender")]
    public DeclaredSender DeclaredSender { get; set; }

    /// <summary>
    /// Gets or Sets PickupPointId
    /// </summary>
    [DataMember(Name="pickupPointId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pickupPointId")]
    public string PickupPointId { get; set; }

    /// <summary>
    /// Gets or Sets Cod
    /// </summary>
    [DataMember(Name="cod", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "cod")]
    public CashOnDeliveryService Cod { get; set; }

    /// <summary>
    /// Gets or Sets ServiceDesignation
    /// </summary>
    [DataMember(Name="serviceDesignation", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "serviceDesignation")]
    public ParcelEventParcelInfoServiceDesignation ServiceDesignation { get; set; }

    /// <summary>
    /// Gets or Sets ParcelNumber
    /// </summary>
    [DataMember(Name="parcelNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "parcelNumber")]
    public string ParcelNumber { get; set; }

    /// <summary>
    /// Gets or Sets Routing
    /// </summary>
    [DataMember(Name="routing", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "routing")]
    public ParcelEventParcelInfoRouting Routing { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ParcelEventParcelInfo {\n");
      sb.Append("  Sender: ").Append(Sender).Append("\n");
      sb.Append("  Receiver: ").Append(Receiver).Append("\n");
      sb.Append("  DeclaredSender: ").Append(DeclaredSender).Append("\n");
      sb.Append("  PickupPointId: ").Append(PickupPointId).Append("\n");
      sb.Append("  Cod: ").Append(Cod).Append("\n");
      sb.Append("  ServiceDesignation: ").Append(ServiceDesignation).Append("\n");
      sb.Append("  ParcelNumber: ").Append(ParcelNumber).Append("\n");
      sb.Append("  Routing: ").Append(Routing).Append("\n");
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
