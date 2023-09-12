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
  public class StandardPrintTypeInput {
    /// <summary>
    /// Option descriptions - EPL - EPL script format ready for printing.     The first 14 characters from the parcel reference 3 and reference 4 are used on the label. - ZPL - ZPL script format ready for printing.     The first 17 characters from the parcel reference 3 and reference 4 are used on the label. - RAW - Raw data, can be used for own printing solution.    This type returns the reference3 and reference4 fields for every physical parcel in full length. 
    /// </summary>
    /// <value>Option descriptions - EPL - EPL script format ready for printing.     The first 14 characters from the parcel reference 3 and reference 4 are used on the label. - ZPL - ZPL script format ready for printing.     The first 17 characters from the parcel reference 3 and reference 4 are used on the label. - RAW - Raw data, can be used for own printing solution.    This type returns the reference3 and reference4 fields for every physical parcel in full length. </value>
    [DataMember(Name="printType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "printType")]
    public string PrintType { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class StandardPrintTypeInput {\n");
      sb.Append("  PrintType: ").Append(PrintType).Append("\n");
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
