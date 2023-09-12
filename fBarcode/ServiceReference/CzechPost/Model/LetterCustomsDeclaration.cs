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
    /// LetterCustomsDeclaration
    /// </summary>
    [DataContract]
        public partial class LetterCustomsDeclaration :  IEquatable<LetterCustomsDeclaration>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LetterCustomsDeclaration" /> class.
        /// </summary>
        /// <param name="category">category.</param>
        /// <param name="note">note.</param>
        /// <param name="customValCur">customValCur.</param>
        /// <param name="importerRefNum">Importer number. / Číslo dovozce..</param>
        /// <param name="customGoods">customGoods.</param>
        public LetterCustomsDeclaration(string category = default(string), string note = default(string), string customValCur = default(string), string importerRefNum = default(string), List<ParcelCustomGoods> customGoods = default(List<ParcelCustomGoods>))
        {
            this.Category = category;
            this.Note = note;
            this.CustomValCur = customValCur;
            this.ImporterRefNum = importerRefNum;
            this.CustomGoods = customGoods;
        }
        
        /// <summary>
        /// Gets or Sets Category
        /// </summary>
        [DataMember(Name="category", EmitDefaultValue=false)]
        public string Category { get; set; }

        /// <summary>
        /// Gets or Sets Note
        /// </summary>
        [DataMember(Name="note", EmitDefaultValue=false)]
        public string Note { get; set; }

        /// <summary>
        /// Gets or Sets CustomValCur
        /// </summary>
        [DataMember(Name="customValCur", EmitDefaultValue=false)]
        public string CustomValCur { get; set; }

        /// <summary>
        /// Importer number. / Číslo dovozce.
        /// </summary>
        /// <value>Importer number. / Číslo dovozce.</value>
        [DataMember(Name="importerRefNum", EmitDefaultValue=false)]
        public string ImporterRefNum { get; set; }

        /// <summary>
        /// Gets or Sets CustomGoods
        /// </summary>
        [DataMember(Name="customGoods", EmitDefaultValue=false)]
        public List<ParcelCustomGoods> CustomGoods { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LetterCustomsDeclaration {\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  Note: ").Append(Note).Append("\n");
            sb.Append("  CustomValCur: ").Append(CustomValCur).Append("\n");
            sb.Append("  ImporterRefNum: ").Append(ImporterRefNum).Append("\n");
            sb.Append("  CustomGoods: ").Append(CustomGoods).Append("\n");
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
            return this.Equals(input as LetterCustomsDeclaration);
        }

        /// <summary>
        /// Returns true if LetterCustomsDeclaration instances are equal
        /// </summary>
        /// <param name="input">Instance of LetterCustomsDeclaration to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LetterCustomsDeclaration input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Category == input.Category ||
                    (this.Category != null &&
                    this.Category.Equals(input.Category))
                ) && 
                (
                    this.Note == input.Note ||
                    (this.Note != null &&
                    this.Note.Equals(input.Note))
                ) && 
                (
                    this.CustomValCur == input.CustomValCur ||
                    (this.CustomValCur != null &&
                    this.CustomValCur.Equals(input.CustomValCur))
                ) && 
                (
                    this.ImporterRefNum == input.ImporterRefNum ||
                    (this.ImporterRefNum != null &&
                    this.ImporterRefNum.Equals(input.ImporterRefNum))
                ) && 
                (
                    this.CustomGoods == input.CustomGoods ||
                    this.CustomGoods != null &&
                    input.CustomGoods != null &&
                    this.CustomGoods.SequenceEqual(input.CustomGoods)
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
                if (this.Category != null)
                    hashCode = hashCode * 59 + this.Category.GetHashCode();
                if (this.Note != null)
                    hashCode = hashCode * 59 + this.Note.GetHashCode();
                if (this.CustomValCur != null)
                    hashCode = hashCode * 59 + this.CustomValCur.GetHashCode();
                if (this.ImporterRefNum != null)
                    hashCode = hashCode * 59 + this.ImporterRefNum.GetHashCode();
                if (this.CustomGoods != null)
                    hashCode = hashCode * 59 + this.CustomGoods.GetHashCode();
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
