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
  public class A4PrintProperties {
    /// <summary>
    /// Use the A4 option if you wish to get a version optimized for A4 paper size. 
    /// </summary>
    /// <value>Use the A4 option if you wish to get a version optimized for A4 paper size. </value>
    [DataMember(Name="pageSize", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pageSize")]
    public string PageSize { get; set; }

    /// <summary>
    /// Number of labels per page.
    /// </summary>
    /// <value>Number of labels per page.</value>
    [DataMember(Name="labelsPerPage", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "labelsPerPage")]
    public decimal? LabelsPerPage { get; set; }

    /// <summary>
    /// Number of labels to skip before printing.
    /// </summary>
    /// <value>Number of labels to skip before printing.</value>
    [DataMember(Name="labelsOffset", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "labelsOffset")]
    public decimal? LabelsOffset { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class A4PrintProperties {\n");
      sb.Append("  PageSize: ").Append(PageSize).Append("\n");
      sb.Append("  LabelsPerPage: ").Append(LabelsPerPage).Append("\n");
      sb.Append("  LabelsOffset: ").Append(LabelsOffset).Append("\n");
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
