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
    /// ParcelServiceHeader
    /// </summary>
    [DataContract]
        public partial class ParcelServiceHeader :  IEquatable<ParcelServiceHeader>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParcelServiceHeader" /> class.
        /// </summary>
        /// <param name="parcelServiceHeaderCom">parcelServiceHeaderCom.</param>
        /// <param name="transmissionEnd">transmissionEnd.</param>
        /// <param name="printParams">printParams.</param>
        /// <param name="position">position.</param>
        /// <param name="senderAddress">senderAddress.</param>
        /// <param name="senderContacts">senderContacts.</param>
        /// <param name="codAddress">codAddress.</param>
        /// <param name="codBank">codBank.</param>
        public ParcelServiceHeader(LetterHeader parcelServiceHeaderCom = default(LetterHeader), bool? transmissionEnd = default(bool?), PrintParams printParams = default(PrintParams), decimal? position = default(decimal?), Address senderAddress = default(Address), SenderContacts senderContacts = default(SenderContacts), Address codAddress = default(Address), Bank codBank = default(Bank))
        {
            this.ParcelServiceHeaderCom = parcelServiceHeaderCom;
            this.TransmissionEnd = transmissionEnd;
            this.PrintParams = printParams;
            this.Position = position;
            this.SenderAddress = senderAddress;
            this.SenderContacts = senderContacts;
            this.CodAddress = codAddress;
            this.CodBank = codBank;
        }
        
        /// <summary>
        /// Gets or Sets ParcelServiceHeaderCom
        /// </summary>
        [DataMember(Name="parcelServiceHeaderCom", EmitDefaultValue=false)]
        public LetterHeader ParcelServiceHeaderCom { get; set; }

        /// <summary>
        /// Gets or Sets TransmissionEnd
        /// </summary>
        [DataMember(Name="transmissionEnd", EmitDefaultValue=false)]
        public bool? TransmissionEnd { get; set; }

        /// <summary>
        /// Gets or Sets PrintParams
        /// </summary>
        [DataMember(Name="printParams", EmitDefaultValue=false)]
        public PrintParams PrintParams { get; set; }

        /// <summary>
        /// Gets or Sets Position
        /// </summary>
        [DataMember(Name="position", EmitDefaultValue=false)]
        public decimal? Position { get; set; }

        /// <summary>
        /// Gets or Sets SenderAddress
        /// </summary>
        [DataMember(Name="senderAddress", EmitDefaultValue=false)]
        public Address SenderAddress { get; set; }

        /// <summary>
        /// Gets or Sets SenderContacts
        /// </summary>
        [DataMember(Name="senderContacts", EmitDefaultValue=false)]
        public SenderContacts SenderContacts { get; set; }

        /// <summary>
        /// Gets or Sets CodAddress
        /// </summary>
        [DataMember(Name="codAddress", EmitDefaultValue=false)]
        public Address CodAddress { get; set; }

        /// <summary>
        /// Gets or Sets CodBank
        /// </summary>
        [DataMember(Name="codBank", EmitDefaultValue=false)]
        public Bank CodBank { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ParcelServiceHeader {\n");
            sb.Append("  ParcelServiceHeaderCom: ").Append(ParcelServiceHeaderCom).Append("\n");
            sb.Append("  TransmissionEnd: ").Append(TransmissionEnd).Append("\n");
            sb.Append("  PrintParams: ").Append(PrintParams).Append("\n");
            sb.Append("  Position: ").Append(Position).Append("\n");
            sb.Append("  SenderAddress: ").Append(SenderAddress).Append("\n");
            sb.Append("  SenderContacts: ").Append(SenderContacts).Append("\n");
            sb.Append("  CodAddress: ").Append(CodAddress).Append("\n");
            sb.Append("  CodBank: ").Append(CodBank).Append("\n");
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
            return this.Equals(input as ParcelServiceHeader);
        }

        /// <summary>
        /// Returns true if ParcelServiceHeader instances are equal
        /// </summary>
        /// <param name="input">Instance of ParcelServiceHeader to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ParcelServiceHeader input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ParcelServiceHeaderCom == input.ParcelServiceHeaderCom ||
                    (this.ParcelServiceHeaderCom != null &&
                    this.ParcelServiceHeaderCom.Equals(input.ParcelServiceHeaderCom))
                ) && 
                (
                    this.TransmissionEnd == input.TransmissionEnd ||
                    (this.TransmissionEnd != null &&
                    this.TransmissionEnd.Equals(input.TransmissionEnd))
                ) && 
                (
                    this.PrintParams == input.PrintParams ||
                    (this.PrintParams != null &&
                    this.PrintParams.Equals(input.PrintParams))
                ) && 
                (
                    this.Position == input.Position ||
                    (this.Position != null &&
                    this.Position.Equals(input.Position))
                ) && 
                (
                    this.SenderAddress == input.SenderAddress ||
                    (this.SenderAddress != null &&
                    this.SenderAddress.Equals(input.SenderAddress))
                ) && 
                (
                    this.SenderContacts == input.SenderContacts ||
                    (this.SenderContacts != null &&
                    this.SenderContacts.Equals(input.SenderContacts))
                ) && 
                (
                    this.CodAddress == input.CodAddress ||
                    (this.CodAddress != null &&
                    this.CodAddress.Equals(input.CodAddress))
                ) && 
                (
                    this.CodBank == input.CodBank ||
                    (this.CodBank != null &&
                    this.CodBank.Equals(input.CodBank))
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
                if (this.ParcelServiceHeaderCom != null)
                    hashCode = hashCode * 59 + this.ParcelServiceHeaderCom.GetHashCode();
                if (this.TransmissionEnd != null)
                    hashCode = hashCode * 59 + this.TransmissionEnd.GetHashCode();
                if (this.PrintParams != null)
                    hashCode = hashCode * 59 + this.PrintParams.GetHashCode();
                if (this.Position != null)
                    hashCode = hashCode * 59 + this.Position.GetHashCode();
                if (this.SenderAddress != null)
                    hashCode = hashCode * 59 + this.SenderAddress.GetHashCode();
                if (this.SenderContacts != null)
                    hashCode = hashCode * 59 + this.SenderContacts.GetHashCode();
                if (this.CodAddress != null)
                    hashCode = hashCode * 59 + this.CodAddress.GetHashCode();
                if (this.CodBank != null)
                    hashCode = hashCode * 59 + this.CodBank.GetHashCode();
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
