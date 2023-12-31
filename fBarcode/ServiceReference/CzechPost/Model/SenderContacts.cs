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
    /// SenderContacts
    /// </summary>
    [DataContract]
        public partial class SenderContacts :  IEquatable<SenderContacts>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SenderContacts" /> class.
        /// </summary>
        /// <param name="mobilNumber">mobilNumber.</param>
        /// <param name="phoneNumber">phoneNumber.</param>
        /// <param name="emailAddress">emailAddress.</param>
        public SenderContacts(string mobilNumber = default(string), string phoneNumber = default(string), string emailAddress = default(string))
        {
            this.MobilNumber = mobilNumber;
            this.PhoneNumber = phoneNumber;
            this.EmailAddress = emailAddress;
        }
        
        /// <summary>
        /// Gets or Sets MobilNumber
        /// </summary>
        [DataMember(Name="mobilNumber", EmitDefaultValue=false)]
        public string MobilNumber { get; set; }

        /// <summary>
        /// Gets or Sets PhoneNumber
        /// </summary>
        [DataMember(Name="phoneNumber", EmitDefaultValue=false)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or Sets EmailAddress
        /// </summary>
        [DataMember(Name="emailAddress", EmitDefaultValue=false)]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SenderContacts {\n");
            sb.Append("  MobilNumber: ").Append(MobilNumber).Append("\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
            sb.Append("  EmailAddress: ").Append(EmailAddress).Append("\n");
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
            return this.Equals(input as SenderContacts);
        }

        /// <summary>
        /// Returns true if SenderContacts instances are equal
        /// </summary>
        /// <param name="input">Instance of SenderContacts to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SenderContacts input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.MobilNumber == input.MobilNumber ||
                    (this.MobilNumber != null &&
                    this.MobilNumber.Equals(input.MobilNumber))
                ) && 
                (
                    this.PhoneNumber == input.PhoneNumber ||
                    (this.PhoneNumber != null &&
                    this.PhoneNumber.Equals(input.PhoneNumber))
                ) && 
                (
                    this.EmailAddress == input.EmailAddress ||
                    (this.EmailAddress != null &&
                    this.EmailAddress.Equals(input.EmailAddress))
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
                if (this.MobilNumber != null)
                    hashCode = hashCode * 59 + this.MobilNumber.GetHashCode();
                if (this.PhoneNumber != null)
                    hashCode = hashCode * 59 + this.PhoneNumber.GetHashCode();
                if (this.EmailAddress != null)
                    hashCode = hashCode * 59 + this.EmailAddress.GetHashCode();
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
