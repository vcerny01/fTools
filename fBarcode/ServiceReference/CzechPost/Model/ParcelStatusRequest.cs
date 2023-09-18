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
    /// ParcelStatusRequest
    /// </summary>
    [DataContract]
        public partial class ParcelStatusRequest :  IEquatable<ParcelStatusRequest>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParcelStatusRequest" /> class.
        /// </summary>
        /// <param name="parcelIds">parcelIds (required).</param>
        /// <param name="language">Prefered language answer. / Jazyk zobrazovaných událostí. (default to &quot;CZ&quot;).</param>
        public ParcelStatusRequest(List<string> parcelIds = default(List<string>), string language = "CZ")
        {
            // to ensure "parcelIds" is required (not null)
            if (parcelIds == null)
            {
                throw new InvalidDataException("parcelIds is a required property for ParcelStatusRequest and cannot be null");
            }
            else
            {
                this.ParcelIds = parcelIds;
            }
            // use default value if no "language" provided
            if (language == null)
            {
                this.Language = "CZ";
            }
            else
            {
                this.Language = language;
            }
        }
        
        /// <summary>
        /// Gets or Sets ParcelIds
        /// </summary>
        [DataMember(Name="parcelIds", EmitDefaultValue=false)]
        public List<string> ParcelIds { get; set; }

        /// <summary>
        /// Prefered language answer. / Jazyk zobrazovaných událostí.
        /// </summary>
        /// <value>Prefered language answer. / Jazyk zobrazovaných událostí.</value>
        [DataMember(Name="language", EmitDefaultValue=false)]
        public string Language { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ParcelStatusRequest {\n");
            sb.Append("  ParcelIds: ").Append(ParcelIds).Append("\n");
            sb.Append("  Language: ").Append(Language).Append("\n");
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
            return this.Equals(input as ParcelStatusRequest);
        }

        /// <summary>
        /// Returns true if ParcelStatusRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of ParcelStatusRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ParcelStatusRequest input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ParcelIds == input.ParcelIds ||
                    this.ParcelIds != null &&
                    input.ParcelIds != null &&
                    this.ParcelIds.SequenceEqual(input.ParcelIds)
                ) && 
                (
                    this.Language == input.Language ||
                    (this.Language != null &&
                    this.Language.Equals(input.Language))
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
                if (this.ParcelIds != null)
                    hashCode = hashCode * 59 + this.ParcelIds.GetHashCode();
                if (this.Language != null)
                    hashCode = hashCode * 59 + this.Language.GetHashCode();
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