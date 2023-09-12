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
    /// LetterParams
    /// </summary>
    [DataContract]
        public partial class LetterParams :  IEquatable<LetterParams>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LetterParams" /> class.
        /// </summary>
        /// <param name="recordID">recordID.</param>
        /// <param name="parcelCode">parcelCode.</param>
        /// <param name="weight">weight.</param>
        /// <param name="note">note.</param>
        /// <param name="note2">note2.</param>
        /// <param name="letterServices">letterServices.</param>
        public LetterParams(string recordID = default(string), string parcelCode = default(string), string weight = default(string), string note = default(string), string note2 = default(string), Services letterServices = default(Services))
        {
            this.RecordID = recordID;
            this.ParcelCode = parcelCode;
            this.Weight = weight;
            this.Note = note;
            this.Note2 = note2;
            this.LetterServices = letterServices;
        }
        
        /// <summary>
        /// Gets or Sets RecordID
        /// </summary>
        [DataMember(Name="recordID", EmitDefaultValue=false)]
        public string RecordID { get; set; }

        /// <summary>
        /// Gets or Sets ParcelCode
        /// </summary>
        [DataMember(Name="parcelCode", EmitDefaultValue=false)]
        public string ParcelCode { get; set; }

        /// <summary>
        /// Gets or Sets Weight
        /// </summary>
        [DataMember(Name="weight", EmitDefaultValue=false)]
        public string Weight { get; set; }

        /// <summary>
        /// Gets or Sets Note
        /// </summary>
        [DataMember(Name="note", EmitDefaultValue=false)]
        public string Note { get; set; }

        /// <summary>
        /// Gets or Sets Note2
        /// </summary>
        [DataMember(Name="note2", EmitDefaultValue=false)]
        public string Note2 { get; set; }

        /// <summary>
        /// Gets or Sets LetterServices
        /// </summary>
        [DataMember(Name="letterServices", EmitDefaultValue=false)]
        public Services LetterServices { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LetterParams {\n");
            sb.Append("  RecordID: ").Append(RecordID).Append("\n");
            sb.Append("  ParcelCode: ").Append(ParcelCode).Append("\n");
            sb.Append("  Weight: ").Append(Weight).Append("\n");
            sb.Append("  Note: ").Append(Note).Append("\n");
            sb.Append("  Note2: ").Append(Note2).Append("\n");
            sb.Append("  LetterServices: ").Append(LetterServices).Append("\n");
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
            return this.Equals(input as LetterParams);
        }

        /// <summary>
        /// Returns true if LetterParams instances are equal
        /// </summary>
        /// <param name="input">Instance of LetterParams to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LetterParams input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.RecordID == input.RecordID ||
                    (this.RecordID != null &&
                    this.RecordID.Equals(input.RecordID))
                ) && 
                (
                    this.ParcelCode == input.ParcelCode ||
                    (this.ParcelCode != null &&
                    this.ParcelCode.Equals(input.ParcelCode))
                ) && 
                (
                    this.Weight == input.Weight ||
                    (this.Weight != null &&
                    this.Weight.Equals(input.Weight))
                ) && 
                (
                    this.Note == input.Note ||
                    (this.Note != null &&
                    this.Note.Equals(input.Note))
                ) && 
                (
                    this.Note2 == input.Note2 ||
                    (this.Note2 != null &&
                    this.Note2.Equals(input.Note2))
                ) && 
                (
                    this.LetterServices == input.LetterServices ||
                    (this.LetterServices != null &&
                    this.LetterServices.Equals(input.LetterServices))
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
                if (this.RecordID != null)
                    hashCode = hashCode * 59 + this.RecordID.GetHashCode();
                if (this.ParcelCode != null)
                    hashCode = hashCode * 59 + this.ParcelCode.GetHashCode();
                if (this.Weight != null)
                    hashCode = hashCode * 59 + this.Weight.GetHashCode();
                if (this.Note != null)
                    hashCode = hashCode * 59 + this.Note.GetHashCode();
                if (this.Note2 != null)
                    hashCode = hashCode * 59 + this.Note2.GetHashCode();
                if (this.LetterServices != null)
                    hashCode = hashCode * 59 + this.LetterServices.GetHashCode();
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
