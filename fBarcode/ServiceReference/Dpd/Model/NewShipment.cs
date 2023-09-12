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
  public class NewShipment {
    /// <summary>
    /// Gets or Sets Customer
    /// </summary>
    [DataMember(Name="customer", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "customer")]
    public NewShipmentCustomer Customer { get; set; }

    /// <summary>
    /// Gets or Sets DeliveryOptions
    /// </summary>
    [DataMember(Name="deliveryOptions", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "deliveryOptions")]
    public DeliveryOptions DeliveryOptions { get; set; }

    /// <summary>
    /// Gets or Sets ShipmentType
    /// </summary>
    [DataMember(Name="shipmentType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipmentType")]
    public ShipmentType ShipmentType { get; set; }

    /// <summary>
    /// Gets or Sets Sender
    /// </summary>
    [DataMember(Name="sender", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sender")]
    public SenderSpecs Sender { get; set; }

    /// <summary>
    /// Gets or Sets Receiver
    /// </summary>
    [DataMember(Name="receiver", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "receiver")]
    public ReceiverSpecs Receiver { get; set; }

    /// <summary>
    /// Gets or Sets Payer
    /// </summary>
    [DataMember(Name="payer", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "payer")]
    public PayerSpecs Payer { get; set; }

    /// <summary>
    /// Gets or Sets References
    /// </summary>
    [DataMember(Name="references", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "references")]
    public ShipmentReferences References { get; set; }

    /// <summary>
    /// Gets or Sets DeclaredSender
    /// </summary>
    [DataMember(Name="declaredSender", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "declaredSender")]
    public DeclaredSender DeclaredSender { get; set; }

    /// <summary>
    /// Gets or Sets Parcels
    /// </summary>
    [DataMember(Name="parcels", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "parcels")]
    public List<NewShipmentParcelsInner> Parcels { get; set; }

    /// <summary>
    /// Gets or Sets Source
    /// </summary>
    [DataMember(Name="source", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "source")]
    public Source Source { get; set; }

    /// <summary>
    /// Gets or Sets Services
    /// </summary>
    [DataMember(Name="services", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "services")]
    public NewShipmentServices Services { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class NewShipment {\n");
      sb.Append("  Customer: ").Append(Customer).Append("\n");
      sb.Append("  DeliveryOptions: ").Append(DeliveryOptions).Append("\n");
      sb.Append("  ShipmentType: ").Append(ShipmentType).Append("\n");
      sb.Append("  Sender: ").Append(Sender).Append("\n");
      sb.Append("  Receiver: ").Append(Receiver).Append("\n");
      sb.Append("  Payer: ").Append(Payer).Append("\n");
      sb.Append("  References: ").Append(References).Append("\n");
      sb.Append("  DeclaredSender: ").Append(DeclaredSender).Append("\n");
      sb.Append("  Parcels: ").Append(Parcels).Append("\n");
      sb.Append("  Source: ").Append(Source).Append("\n");
      sb.Append("  Services: ").Append(Services).Append("\n");
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
