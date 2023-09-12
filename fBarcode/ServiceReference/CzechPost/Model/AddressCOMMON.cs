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
    /// AddressCOMMON
    /// </summary>
    [DataContract]
        public partial class AddressCOMMON :  IEquatable<AddressCOMMON>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressCOMMON" /> class.
        /// </summary>
        /// <param name="street">Street (maxLength &#x3D; 40 ). / Ulice..</param>
        /// <param name="houseNumber">Descriptive (house) number (maxLength &#x3D; 6). / Číslo popisné..</param>
        /// <param name="sequenceNumber">Orientation (sequence) number (maxLength &#x3D; 6). / Číslo orientační..</param>
        /// <param name="cityPart">Part of the city (maxLength &#x3D; 40). / Část obce..</param>
        /// <param name="city">City (maxLength &#x3D; 40). / Obec..</param>
        /// <param name="zipCode">Postal code (maxLength &#x3D; 25). / PSČ..</param>
        /// <param name="isoCountry">ISO code of the country (maxLength &#x3D; 2). / ISO kód země. (default to &quot;CZ&quot;).</param>
        /// <param name="subIsoCountry">ISO code of the land (maxLength &#x3D; 6). / ISO kód území..</param>
        /// <param name="addressCode">Code of address RUIAN. / Kód adresního místa RUIAN..</param>
        public AddressCOMMON(string street = default(string), string houseNumber = default(string), string sequenceNumber = default(string), string cityPart = default(string), string city = default(string), string zipCode = default(string), string isoCountry = "CZ", string subIsoCountry = default(string), int? addressCode = default(int?))
        {
            this.Street = street;
            this.HouseNumber = houseNumber;
            this.SequenceNumber = sequenceNumber;
            this.CityPart = cityPart;
            this.City = city;
            this.ZipCode = zipCode;
            // use default value if no "isoCountry" provided
            if (isoCountry == null)
            {
                this.IsoCountry = "CZ";
            }
            else
            {
                this.IsoCountry = isoCountry;
            }
            this.SubIsoCountry = subIsoCountry;
            this.AddressCode = addressCode;
        }
        
        /// <summary>
        /// Street (maxLength &#x3D; 40 ). / Ulice.
        /// </summary>
        /// <value>Street (maxLength &#x3D; 40 ). / Ulice.</value>
        [DataMember(Name="street", EmitDefaultValue=false)]
        public string Street { get; set; }

        /// <summary>
        /// Descriptive (house) number (maxLength &#x3D; 6). / Číslo popisné.
        /// </summary>
        /// <value>Descriptive (house) number (maxLength &#x3D; 6). / Číslo popisné.</value>
        [DataMember(Name="houseNumber", EmitDefaultValue=false)]
        public string HouseNumber { get; set; }

        /// <summary>
        /// Orientation (sequence) number (maxLength &#x3D; 6). / Číslo orientační.
        /// </summary>
        /// <value>Orientation (sequence) number (maxLength &#x3D; 6). / Číslo orientační.</value>
        [DataMember(Name="sequenceNumber", EmitDefaultValue=false)]
        public string SequenceNumber { get; set; }

        /// <summary>
        /// Part of the city (maxLength &#x3D; 40). / Část obce.
        /// </summary>
        /// <value>Part of the city (maxLength &#x3D; 40). / Část obce.</value>
        [DataMember(Name="cityPart", EmitDefaultValue=false)]
        public string CityPart { get; set; }

        /// <summary>
        /// City (maxLength &#x3D; 40). / Obec.
        /// </summary>
        /// <value>City (maxLength &#x3D; 40). / Obec.</value>
        [DataMember(Name="city", EmitDefaultValue=false)]
        public string City { get; set; }

        /// <summary>
        /// Postal code (maxLength &#x3D; 25). / PSČ.
        /// </summary>
        /// <value>Postal code (maxLength &#x3D; 25). / PSČ.</value>
        [DataMember(Name="zipCode", EmitDefaultValue=false)]
        public string ZipCode { get; set; }

        /// <summary>
        /// ISO code of the country (maxLength &#x3D; 2). / ISO kód země.
        /// </summary>
        /// <value>ISO code of the country (maxLength &#x3D; 2). / ISO kód země.</value>
        [DataMember(Name="isoCountry", EmitDefaultValue=false)]
        public string IsoCountry { get; set; }

        /// <summary>
        /// ISO code of the land (maxLength &#x3D; 6). / ISO kód území.
        /// </summary>
        /// <value>ISO code of the land (maxLength &#x3D; 6). / ISO kód území.</value>
        [DataMember(Name="subIsoCountry", EmitDefaultValue=false)]
        public string SubIsoCountry { get; set; }

        /// <summary>
        /// Code of address RUIAN. / Kód adresního místa RUIAN.
        /// </summary>
        /// <value>Code of address RUIAN. / Kód adresního místa RUIAN.</value>
        [DataMember(Name="addressCode", EmitDefaultValue=false)]
        public int? AddressCode { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AddressCOMMON {\n");
            sb.Append("  Street: ").Append(Street).Append("\n");
            sb.Append("  HouseNumber: ").Append(HouseNumber).Append("\n");
            sb.Append("  SequenceNumber: ").Append(SequenceNumber).Append("\n");
            sb.Append("  CityPart: ").Append(CityPart).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  ZipCode: ").Append(ZipCode).Append("\n");
            sb.Append("  IsoCountry: ").Append(IsoCountry).Append("\n");
            sb.Append("  SubIsoCountry: ").Append(SubIsoCountry).Append("\n");
            sb.Append("  AddressCode: ").Append(AddressCode).Append("\n");
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
            return this.Equals(input as AddressCOMMON);
        }

        /// <summary>
        /// Returns true if AddressCOMMON instances are equal
        /// </summary>
        /// <param name="input">Instance of AddressCOMMON to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AddressCOMMON input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Street == input.Street ||
                    (this.Street != null &&
                    this.Street.Equals(input.Street))
                ) && 
                (
                    this.HouseNumber == input.HouseNumber ||
                    (this.HouseNumber != null &&
                    this.HouseNumber.Equals(input.HouseNumber))
                ) && 
                (
                    this.SequenceNumber == input.SequenceNumber ||
                    (this.SequenceNumber != null &&
                    this.SequenceNumber.Equals(input.SequenceNumber))
                ) && 
                (
                    this.CityPart == input.CityPart ||
                    (this.CityPart != null &&
                    this.CityPart.Equals(input.CityPart))
                ) && 
                (
                    this.City == input.City ||
                    (this.City != null &&
                    this.City.Equals(input.City))
                ) && 
                (
                    this.ZipCode == input.ZipCode ||
                    (this.ZipCode != null &&
                    this.ZipCode.Equals(input.ZipCode))
                ) && 
                (
                    this.IsoCountry == input.IsoCountry ||
                    (this.IsoCountry != null &&
                    this.IsoCountry.Equals(input.IsoCountry))
                ) && 
                (
                    this.SubIsoCountry == input.SubIsoCountry ||
                    (this.SubIsoCountry != null &&
                    this.SubIsoCountry.Equals(input.SubIsoCountry))
                ) && 
                (
                    this.AddressCode == input.AddressCode ||
                    (this.AddressCode != null &&
                    this.AddressCode.Equals(input.AddressCode))
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
                if (this.Street != null)
                    hashCode = hashCode * 59 + this.Street.GetHashCode();
                if (this.HouseNumber != null)
                    hashCode = hashCode * 59 + this.HouseNumber.GetHashCode();
                if (this.SequenceNumber != null)
                    hashCode = hashCode * 59 + this.SequenceNumber.GetHashCode();
                if (this.CityPart != null)
                    hashCode = hashCode * 59 + this.CityPart.GetHashCode();
                if (this.City != null)
                    hashCode = hashCode * 59 + this.City.GetHashCode();
                if (this.ZipCode != null)
                    hashCode = hashCode * 59 + this.ZipCode.GetHashCode();
                if (this.IsoCountry != null)
                    hashCode = hashCode * 59 + this.IsoCountry.GetHashCode();
                if (this.SubIsoCountry != null)
                    hashCode = hashCode * 59 + this.SubIsoCountry.GetHashCode();
                if (this.AddressCode != null)
                    hashCode = hashCode * 59 + this.AddressCode.GetHashCode();
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
