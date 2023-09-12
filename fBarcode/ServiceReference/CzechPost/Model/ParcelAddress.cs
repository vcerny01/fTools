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
    /// ParcelAddress
    /// </summary>
    [DataContract]
        public partial class ParcelAddress :  IEquatable<ParcelAddress>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParcelAddress" /> class.
        /// </summary>
        /// <param name="recordID">Internal destination of the recipient./ Interni označení adresáta..</param>
        /// <param name="firstName">First name. / Jméno..</param>
        /// <param name="surname">Surname. / Příjmení..</param>
        /// <param name="company">Company name. / Název společnosti..</param>
        /// <param name="aditionAddress">Aditional information. / Doplňující informace k názvu adresáta..</param>
        /// <param name="subject">Recipient&#x27;s type. / Typ adresáta..</param>
        /// <param name="ic">CIN - company identification number. / IČO - identifikacni Číslo ekonomickych subjektů..</param>
        /// <param name="dic">VATIN - value added tax identification number. / DIČ - daňove identifikacni Číslo..</param>
        /// <param name="specification">Specification, eg. birthdate. / Specifikace, např. datum narození..</param>
        /// <param name="address">address.</param>
        /// <param name="bank">bank.</param>
        /// <param name="mobilNumber">mobilNumber.</param>
        /// <param name="phoneNumber">phoneNumber.</param>
        /// <param name="emailAddress">emailAddress.</param>
        /// <param name="custCardNum">custCardNum.</param>
        /// <param name="adviceInfo">adviceInfo.</param>
        public ParcelAddress(string recordID = default(string), string firstName = default(string), string surname = default(string), string company = default(string), string aditionAddress = default(string), string subject = default(string), long? ic = default(long?), string dic = default(string), string specification = default(string), AddressCOMMON address = default(AddressCOMMON), Bank bank = default(Bank), string mobilNumber = default(string), string phoneNumber = default(string), string emailAddress = default(string), string custCardNum = default(string), AdviceInfo adviceInfo = default(AdviceInfo))
        {
            this.RecordID = recordID;
            this.FirstName = firstName;
            this.Surname = surname;
            this.Company = company;
            this.AditionAddress = aditionAddress;
            this.Subject = subject;
            this.Ic = ic;
            this.Dic = dic;
            this.Specification = specification;
            this.Address = address;
            this.Bank = bank;
            this.MobilNumber = mobilNumber;
            this.PhoneNumber = phoneNumber;
            this.EmailAddress = emailAddress;
            this.CustCardNum = custCardNum;
            this.AdviceInfo = adviceInfo;
        }
        
        /// <summary>
        /// Internal destination of the recipient./ Interni označení adresáta.
        /// </summary>
        /// <value>Internal destination of the recipient./ Interni označení adresáta.</value>
        [DataMember(Name="recordID", EmitDefaultValue=false)]
        public string RecordID { get; set; }

        /// <summary>
        /// First name. / Jméno.
        /// </summary>
        /// <value>First name. / Jméno.</value>
        [DataMember(Name="firstName", EmitDefaultValue=false)]
        public string FirstName { get; set; }

        /// <summary>
        /// Surname. / Příjmení.
        /// </summary>
        /// <value>Surname. / Příjmení.</value>
        [DataMember(Name="surname", EmitDefaultValue=false)]
        public string Surname { get; set; }

        /// <summary>
        /// Company name. / Název společnosti.
        /// </summary>
        /// <value>Company name. / Název společnosti.</value>
        [DataMember(Name="company", EmitDefaultValue=false)]
        public string Company { get; set; }

        /// <summary>
        /// Aditional information. / Doplňující informace k názvu adresáta.
        /// </summary>
        /// <value>Aditional information. / Doplňující informace k názvu adresáta.</value>
        [DataMember(Name="aditionAddress", EmitDefaultValue=false)]
        public string AditionAddress { get; set; }

        /// <summary>
        /// Recipient&#x27;s type. / Typ adresáta.
        /// </summary>
        /// <value>Recipient&#x27;s type. / Typ adresáta.</value>
        [DataMember(Name="subject", EmitDefaultValue=false)]
        public string Subject { get; set; }

        /// <summary>
        /// CIN - company identification number. / IČO - identifikacni Číslo ekonomickych subjektů.
        /// </summary>
        /// <value>CIN - company identification number. / IČO - identifikacni Číslo ekonomickych subjektů.</value>
        [DataMember(Name="ic", EmitDefaultValue=false)]
        public long? Ic { get; set; }

        /// <summary>
        /// VATIN - value added tax identification number. / DIČ - daňove identifikacni Číslo.
        /// </summary>
        /// <value>VATIN - value added tax identification number. / DIČ - daňove identifikacni Číslo.</value>
        [DataMember(Name="dic", EmitDefaultValue=false)]
        public string Dic { get; set; }

        /// <summary>
        /// Specification, eg. birthdate. / Specifikace, např. datum narození.
        /// </summary>
        /// <value>Specification, eg. birthdate. / Specifikace, např. datum narození.</value>
        [DataMember(Name="specification", EmitDefaultValue=false)]
        public string Specification { get; set; }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name="address", EmitDefaultValue=false)]
        public AddressCOMMON Address { get; set; }

        /// <summary>
        /// Gets or Sets Bank
        /// </summary>
        [DataMember(Name="bank", EmitDefaultValue=false)]
        public Bank Bank { get; set; }

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
        /// Gets or Sets CustCardNum
        /// </summary>
        [DataMember(Name="custCardNum", EmitDefaultValue=false)]
        public string CustCardNum { get; set; }

        /// <summary>
        /// Gets or Sets AdviceInfo
        /// </summary>
        [DataMember(Name="adviceInfo", EmitDefaultValue=false)]
        public AdviceInfo AdviceInfo { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ParcelAddress {\n");
            sb.Append("  RecordID: ").Append(RecordID).Append("\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  Surname: ").Append(Surname).Append("\n");
            sb.Append("  Company: ").Append(Company).Append("\n");
            sb.Append("  AditionAddress: ").Append(AditionAddress).Append("\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
            sb.Append("  Ic: ").Append(Ic).Append("\n");
            sb.Append("  Dic: ").Append(Dic).Append("\n");
            sb.Append("  Specification: ").Append(Specification).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Bank: ").Append(Bank).Append("\n");
            sb.Append("  MobilNumber: ").Append(MobilNumber).Append("\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
            sb.Append("  EmailAddress: ").Append(EmailAddress).Append("\n");
            sb.Append("  CustCardNum: ").Append(CustCardNum).Append("\n");
            sb.Append("  AdviceInfo: ").Append(AdviceInfo).Append("\n");
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
            return this.Equals(input as ParcelAddress);
        }

        /// <summary>
        /// Returns true if ParcelAddress instances are equal
        /// </summary>
        /// <param name="input">Instance of ParcelAddress to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ParcelAddress input)
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
                    this.FirstName == input.FirstName ||
                    (this.FirstName != null &&
                    this.FirstName.Equals(input.FirstName))
                ) && 
                (
                    this.Surname == input.Surname ||
                    (this.Surname != null &&
                    this.Surname.Equals(input.Surname))
                ) && 
                (
                    this.Company == input.Company ||
                    (this.Company != null &&
                    this.Company.Equals(input.Company))
                ) && 
                (
                    this.AditionAddress == input.AditionAddress ||
                    (this.AditionAddress != null &&
                    this.AditionAddress.Equals(input.AditionAddress))
                ) && 
                (
                    this.Subject == input.Subject ||
                    (this.Subject != null &&
                    this.Subject.Equals(input.Subject))
                ) && 
                (
                    this.Ic == input.Ic ||
                    (this.Ic != null &&
                    this.Ic.Equals(input.Ic))
                ) && 
                (
                    this.Dic == input.Dic ||
                    (this.Dic != null &&
                    this.Dic.Equals(input.Dic))
                ) && 
                (
                    this.Specification == input.Specification ||
                    (this.Specification != null &&
                    this.Specification.Equals(input.Specification))
                ) && 
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) && 
                (
                    this.Bank == input.Bank ||
                    (this.Bank != null &&
                    this.Bank.Equals(input.Bank))
                ) && 
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
                ) && 
                (
                    this.CustCardNum == input.CustCardNum ||
                    (this.CustCardNum != null &&
                    this.CustCardNum.Equals(input.CustCardNum))
                ) && 
                (
                    this.AdviceInfo == input.AdviceInfo ||
                    (this.AdviceInfo != null &&
                    this.AdviceInfo.Equals(input.AdviceInfo))
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
                if (this.FirstName != null)
                    hashCode = hashCode * 59 + this.FirstName.GetHashCode();
                if (this.Surname != null)
                    hashCode = hashCode * 59 + this.Surname.GetHashCode();
                if (this.Company != null)
                    hashCode = hashCode * 59 + this.Company.GetHashCode();
                if (this.AditionAddress != null)
                    hashCode = hashCode * 59 + this.AditionAddress.GetHashCode();
                if (this.Subject != null)
                    hashCode = hashCode * 59 + this.Subject.GetHashCode();
                if (this.Ic != null)
                    hashCode = hashCode * 59 + this.Ic.GetHashCode();
                if (this.Dic != null)
                    hashCode = hashCode * 59 + this.Dic.GetHashCode();
                if (this.Specification != null)
                    hashCode = hashCode * 59 + this.Specification.GetHashCode();
                if (this.Address != null)
                    hashCode = hashCode * 59 + this.Address.GetHashCode();
                if (this.Bank != null)
                    hashCode = hashCode * 59 + this.Bank.GetHashCode();
                if (this.MobilNumber != null)
                    hashCode = hashCode * 59 + this.MobilNumber.GetHashCode();
                if (this.PhoneNumber != null)
                    hashCode = hashCode * 59 + this.PhoneNumber.GetHashCode();
                if (this.EmailAddress != null)
                    hashCode = hashCode * 59 + this.EmailAddress.GetHashCode();
                if (this.CustCardNum != null)
                    hashCode = hashCode * 59 + this.CustCardNum.GetHashCode();
                if (this.AdviceInfo != null)
                    hashCode = hashCode * 59 + this.AdviceInfo.GetHashCode();
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
