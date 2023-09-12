/* 
 * B2B-ZSKService
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.7.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.CzechPost.Client.SwaggerDateConverter;
namespace IO.Swagger.CzechPost.Model
{
    /// <summary>
    /// QualityResponse
    /// </summary>
    [DataContract]
        public partial class QualityResponse :  IEquatable<QualityResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QualityResponse" /> class.
        /// </summary>
        /// <param name="qualityList">qualityList.</param>
        public QualityResponse(QualityList qualityList = default(QualityList))
        {
            this.QualityList = qualityList;
        }
        
        /// <summary>
        /// Gets or Sets QualityList
        /// </summary>
        [DataMember(Name="qualityList", EmitDefaultValue=false)]
        public QualityList QualityList { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class QualityResponse {\n");
            sb.Append("  QualityList: ").Append(QualityList).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as QualityResponse);
        }

        /// <summary>
        /// Returns true if QualityResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of QualityResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QualityResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.QualityList == input.QualityList ||
                    (this.QualityList != null &&
                    this.QualityList.Equals(input.QualityList))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.QualityList != null)
                    hashCode = hashCode * 59 + this.QualityList.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
