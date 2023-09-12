using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Dpd.Model {

  /// <summary>
  /// Provide this information if you want to specify the completeness of the delivery. - CompleteOnly &#x3D; All parcels of the shipment must be delivered - PossiblyIncomplete &#x3D; The shipment can be delivered incomplete  default behavior:   - shipment with CoD &#x3D; CompleteOnly   - shipment without CoD &#x3D; PossiblyIncomplete 
  /// </summary>
  [DataContract]
  public class Completeness {

    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Completeness {\n");
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
