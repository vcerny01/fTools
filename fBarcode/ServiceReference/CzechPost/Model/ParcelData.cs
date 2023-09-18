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
    /// ParcelData
    /// </summary>
    [DataContract]
        public partial class ParcelData :  IEquatable<ParcelData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParcelData" /> class.
        /// </summary>
        /// <param name="parcelParams">parcelParams (required).</param>
        /// <param name="parcelServices">parcelServices.</param>
        /// <param name="parcelAddress">parcelAddress (required).</param>
        /// <param name="parcelAddressDocument">parcelAddressDocument.</param>
        /// <param name="parcelCustomsDeclaration">parcelCustomsDeclaration.</param>
        public ParcelData(ParcelParams parcelParams = default(ParcelParams), Services parcelServices = default(Services), ParcelAddress parcelAddress = default(ParcelAddress), ParcelAddress parcelAddressDocument = default(ParcelAddress), ParcelCustomsDeclaration parcelCustomsDeclaration = default(ParcelCustomsDeclaration))
        {
            // to ensure "parcelParams" is required (not null)
            //if (parcelParams == null)
            //{
            //    throw new InvalidDataException("parcelParams is a required property for ParcelData and cannot be null");
            //}
            //else
            //{
            this.ParcelParams = parcelParams;
            //}
            // to ensure "parcelAddress" is required (not null)
            //if (parcelAddress == null)
            //{
            //    throw new InvalidDataException("parcelAddress is a required property for ParcelData and cannot be null");
            //}
            //else
            //{
                this.ParcelAddress = parcelAddress;
            //}
            this.ParcelServices = parcelServices;
            this.ParcelAddressDocument = parcelAddressDocument;
            this.ParcelCustomsDeclaration = parcelCustomsDeclaration;
        }
        
        /// <summary>
        /// Gets or Sets ParcelParams
        /// </summary>
        [DataMember(Name="parcelParams", EmitDefaultValue=false)]
        public ParcelParams ParcelParams { get; set; }

        /// <summary>
        /// Gets or Sets ParcelServices
        /// </summary>
        [DataMember(Name="parcelServices", EmitDefaultValue=false)]
        public Services ParcelServices { get; set; }

        /// <summary>
        /// Gets or Sets ParcelAddress
        /// </summary>
        [DataMember(Name="parcelAddress", EmitDefaultValue=false)]
        public ParcelAddress ParcelAddress { get; set; }

        /// <summary>
        /// Gets or Sets ParcelAddressDocument
        /// </summary>
        [DataMember(Name="parcelAddressDocument", EmitDefaultValue=false)]
        public ParcelAddress ParcelAddressDocument { get; set; }

        /// <summary>
        /// Gets or Sets ParcelCustomsDeclaration
        /// </summary>
        [DataMember(Name="parcelCustomsDeclaration", EmitDefaultValue=false)]
        public ParcelCustomsDeclaration ParcelCustomsDeclaration { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ParcelData {\n");
            sb.Append("  ParcelParams: ").Append(ParcelParams).Append("\n");
            sb.Append("  ParcelServices: ").Append(ParcelServices).Append("\n");
            sb.Append("  ParcelAddress: ").Append(ParcelAddress).Append("\n");
            sb.Append("  ParcelAddressDocument: ").Append(ParcelAddressDocument).Append("\n");
            sb.Append("  ParcelCustomsDeclaration: ").Append(ParcelCustomsDeclaration).Append("\n");
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
            return this.Equals(input as ParcelData);
        }

        /// <summary>
        /// Returns true if ParcelData instances are equal
        /// </summary>
        /// <param name="input">Instance of ParcelData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ParcelData input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ParcelParams == input.ParcelParams ||
                    (this.ParcelParams != null &&
                    this.ParcelParams.Equals(input.ParcelParams))
                ) && 
                (
                    this.ParcelServices == input.ParcelServices ||
                    (this.ParcelServices != null &&
                    this.ParcelServices.Equals(input.ParcelServices))
                ) && 
                (
                    this.ParcelAddress == input.ParcelAddress ||
                    (this.ParcelAddress != null &&
                    this.ParcelAddress.Equals(input.ParcelAddress))
                ) && 
                (
                    this.ParcelAddressDocument == input.ParcelAddressDocument ||
                    (this.ParcelAddressDocument != null &&
                    this.ParcelAddressDocument.Equals(input.ParcelAddressDocument))
                ) && 
                (
                    this.ParcelCustomsDeclaration == input.ParcelCustomsDeclaration ||
                    (this.ParcelCustomsDeclaration != null &&
                    this.ParcelCustomsDeclaration.Equals(input.ParcelCustomsDeclaration))
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
                if (this.ParcelParams != null)
                    hashCode = hashCode * 59 + this.ParcelParams.GetHashCode();
                if (this.ParcelServices != null)
                    hashCode = hashCode * 59 + this.ParcelServices.GetHashCode();
                if (this.ParcelAddress != null)
                    hashCode = hashCode * 59 + this.ParcelAddress.GetHashCode();
                if (this.ParcelAddressDocument != null)
                    hashCode = hashCode * 59 + this.ParcelAddressDocument.GetHashCode();
                if (this.ParcelCustomsDeclaration != null)
                    hashCode = hashCode * 59 + this.ParcelCustomsDeclaration.GetHashCode();
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