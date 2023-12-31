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
    /// LetterData
    /// </summary>
    [DataContract]
        public partial class LetterData :  IEquatable<LetterData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LetterData" /> class.
        /// </summary>
        /// <param name="letterParams">letterParams.</param>
        /// <param name="letterAddress">letterAddress.</param>
        /// <param name="letterCustomsDeclaration">letterCustomsDeclaration.</param>
        public LetterData(LetterParams letterParams = default(LetterParams), LetterAddress letterAddress = default(LetterAddress), LetterCustomsDeclaration letterCustomsDeclaration = default(LetterCustomsDeclaration))
        {
            this.LetterParams = letterParams;
            this.LetterAddress = letterAddress;
            this.LetterCustomsDeclaration = letterCustomsDeclaration;
        }
        
        /// <summary>
        /// Gets or Sets LetterParams
        /// </summary>
        [DataMember(Name="letterParams", EmitDefaultValue=false)]
        public LetterParams LetterParams { get; set; }

        /// <summary>
        /// Gets or Sets LetterAddress
        /// </summary>
        [DataMember(Name="letterAddress", EmitDefaultValue=false)]
        public LetterAddress LetterAddress { get; set; }

        /// <summary>
        /// Gets or Sets LetterCustomsDeclaration
        /// </summary>
        [DataMember(Name="letterCustomsDeclaration", EmitDefaultValue=false)]
        public LetterCustomsDeclaration LetterCustomsDeclaration { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LetterData {\n");
            sb.Append("  LetterParams: ").Append(LetterParams).Append("\n");
            sb.Append("  LetterAddress: ").Append(LetterAddress).Append("\n");
            sb.Append("  LetterCustomsDeclaration: ").Append(LetterCustomsDeclaration).Append("\n");
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
            return this.Equals(input as LetterData);
        }

        /// <summary>
        /// Returns true if LetterData instances are equal
        /// </summary>
        /// <param name="input">Instance of LetterData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LetterData input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.LetterParams == input.LetterParams ||
                    (this.LetterParams != null &&
                    this.LetterParams.Equals(input.LetterParams))
                ) && 
                (
                    this.LetterAddress == input.LetterAddress ||
                    (this.LetterAddress != null &&
                    this.LetterAddress.Equals(input.LetterAddress))
                ) && 
                (
                    this.LetterCustomsDeclaration == input.LetterCustomsDeclaration ||
                    (this.LetterCustomsDeclaration != null &&
                    this.LetterCustomsDeclaration.Equals(input.LetterCustomsDeclaration))
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
                if (this.LetterParams != null)
                    hashCode = hashCode * 59 + this.LetterParams.GetHashCode();
                if (this.LetterAddress != null)
                    hashCode = hashCode * 59 + this.LetterAddress.GetHashCode();
                if (this.LetterCustomsDeclaration != null)
                    hashCode = hashCode * 59 + this.LetterCustomsDeclaration.GetHashCode();
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
