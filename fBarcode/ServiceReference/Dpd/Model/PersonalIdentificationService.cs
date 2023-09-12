using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Dpd.Model {

  /// <summary>
  /// Delivery with personal identification using the ID-Check method or simply checking against the shipment receiver.    The receiver will have to provide an identification card matching the information provided here.  If you have selected a pickup point delivery service, then the identification will be conducted at the pickup point.  **Limitations**  The personal identification service is only available when the delivery to department is not requested:  See the service table for more info. 
  /// </summary>
  [DataContract]
  public class PersonalIdentificationService {

    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PersonalIdentificationService {\n");
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
