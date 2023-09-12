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
  public class PDFPrintTypeInput {
    /// <summary>
    /// Option descriptions - PDF - PDF in the Base64 encoding containing the parcel label.     The first 17 characters from the parcel reference 3 and reference 4 are used on the label. 
    /// </summary>
    /// <value>Option descriptions - PDF - PDF in the Base64 encoding containing the parcel label.     The first 17 characters from the parcel reference 3 and reference 4 are used on the label. </value>
    [DataMember(Name="printType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "printType")]
    public string PrintType { get; set; }

    /// <summary>
    /// Gets or Sets PrintProperties
    /// </summary>
    [DataMember(Name="printProperties", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "printProperties")]
    public PDFPrintTypeInputPrintProperties PrintProperties { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PDFPrintTypeInput {\n");
      sb.Append("  PrintType: ").Append(PrintType).Append("\n");
      sb.Append("  PrintProperties: ").Append(PrintProperties).Append("\n");
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
