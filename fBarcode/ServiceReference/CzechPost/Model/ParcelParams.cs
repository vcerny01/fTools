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
    /// ParcelParams
    /// </summary>
    [DataContract]
        public partial class ParcelParams :  IEquatable<ParcelParams>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParcelParams" /> class.
        /// </summary>
        /// <param name="recordID">recordID (required).</param>
        /// <param name="parcelCode">parcelCode.</param>
        /// <param name="masterCode">masterCode.</param>
        /// <param name="prefixParcelCode">prefixParcelCode (required).</param>
        /// <param name="weight">weight.</param>
        /// <param name="insuredValue">insuredValue.</param>
        /// <param name="amount">amount.</param>
        /// <param name="currency">currency.</param>
        /// <param name="vsVoucher">vsVoucher.</param>
        /// <param name="vsParcel">vsParcel.</param>
        /// <param name="sequenceParcel">sequenceParcel.</param>
        /// <param name="quantityParcel">quantityParcel.</param>
        /// <param name="note">note.</param>
        /// <param name="notePrint">Note for printing. / Poznamka pro tisk..</param>
        /// <param name="length">length.</param>
        /// <param name="width">width.</param>
        /// <param name="height">height.</param>
        /// <param name="mrn">MRN code. / Kod MRN..</param>
        /// <param name="referenceNumber">Reference number. / Číslo jednací..</param>
        /// <param name="pallets">Number of pallets. / Počet palet..</param>
        /// <param name="specSym">Specific symbol. / Specifický symbol..</param>
        /// <param name="note2">Note no. 2. / Poznámka 2..</param>
        /// <param name="numSign">Number of documents. / Počet dokumentů..</param>
        /// <param name="score">Service price calculation. / Nápočet ceny služby..</param>
        /// <param name="orderNumberZPRO">Number of ZPRO&#x27;s number. / Číslo objednávky ZPRO..</param>
        /// <param name="returnNumDays">Number of days for returning the parcel. / Počet dní pro vrácení zásilky..</param>
        public ParcelParams(string recordID = default(string), string parcelCode = default(string), string masterCode = default(string), string prefixParcelCode = default(string), string weight = default(string), double? insuredValue = default(double?), double? amount = default(double?), string currency = default(string), string vsVoucher = default(string), string vsParcel = default(string), int? sequenceParcel = default(int?), int? quantityParcel = default(int?), string note = default(string), string notePrint = default(string), int? length = default(int?), int? width = default(int?), int? height = default(int?), string mrn = default(string), string referenceNumber = default(string), int? pallets = default(int?), string specSym = default(string), string note2 = default(string), string numSign = default(string), string score = default(string), string orderNumberZPRO = default(string), string returnNumDays = default(string))
        {
            // to ensure "recordID" is required (not null)
            //if (recordID == null)
            //{
            //    throw new InvalidDataException("recordID is a required property for ParcelParams and cannot be null");
            //}
            //else
            //{
            this.RecordID = recordID;
            //}
            // to ensure "prefixParcelCode" is required (not null)
            //if (prefixParcelCode == null)
            //{
            //    throw new InvalidDataException("prefixParcelCode is a required property for ParcelParams and cannot be null");
            //}
            //else
            //{
                this.PrefixParcelCode = prefixParcelCode;
            //}
            this.ParcelCode = parcelCode;
            this.MasterCode = masterCode;
            this.Weight = weight;
            this.InsuredValue = insuredValue;
            this.Amount = amount;
            this.Currency = currency;
            this.VsVoucher = vsVoucher;
            this.VsParcel = vsParcel;
            this.SequenceParcel = sequenceParcel;
            this.QuantityParcel = quantityParcel;
            this.Note = note;
            this.NotePrint = notePrint;
            this.Length = length;
            this.Width = width;
            this.Height = height;
            this.Mrn = mrn;
            this.ReferenceNumber = referenceNumber;
            this.Pallets = pallets;
            this.SpecSym = specSym;
            this.Note2 = note2;
            this.NumSign = numSign;
            this.Score = score;
            this.OrderNumberZPRO = orderNumberZPRO;
            this.ReturnNumDays = returnNumDays;
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
        /// Gets or Sets MasterCode
        /// </summary>
        [DataMember(Name="masterCode", EmitDefaultValue=false)]
        public string MasterCode { get; set; }

        /// <summary>
        /// Gets or Sets PrefixParcelCode
        /// </summary>
        [DataMember(Name="prefixParcelCode", EmitDefaultValue=false)]
        public string PrefixParcelCode { get; set; }

        /// <summary>
        /// Gets or Sets Weight
        /// </summary>
        [DataMember(Name="weight", EmitDefaultValue=false)]
        public string Weight { get; set; }

        /// <summary>
        /// Gets or Sets InsuredValue
        /// </summary>
        [DataMember(Name="insuredValue", EmitDefaultValue=false)]
        public double? InsuredValue { get; set; }

        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue=false)]
        public double? Amount { get; set; }

        /// <summary>
        /// Gets or Sets Currency
        /// </summary>
        [DataMember(Name="currency", EmitDefaultValue=false)]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or Sets VsVoucher
        /// </summary>
        [DataMember(Name="vsVoucher", EmitDefaultValue=false)]
        public string VsVoucher { get; set; }

        /// <summary>
        /// Gets or Sets VsParcel
        /// </summary>
        [DataMember(Name="vsParcel", EmitDefaultValue=false)]
        public string VsParcel { get; set; }

        /// <summary>
        /// Gets or Sets SequenceParcel
        /// </summary>
        [DataMember(Name="sequenceParcel", EmitDefaultValue=false)]
        public int? SequenceParcel { get; set; }

        /// <summary>
        /// Gets or Sets QuantityParcel
        /// </summary>
        [DataMember(Name="quantityParcel", EmitDefaultValue=false)]
        public int? QuantityParcel { get; set; }

        /// <summary>
        /// Gets or Sets Note
        /// </summary>
        [DataMember(Name="note", EmitDefaultValue=false)]
        public string Note { get; set; }

        /// <summary>
        /// Note for printing. / Poznamka pro tisk.
        /// </summary>
        /// <value>Note for printing. / Poznamka pro tisk.</value>
        [DataMember(Name="notePrint", EmitDefaultValue=false)]
        public string NotePrint { get; set; }

        /// <summary>
        /// Gets or Sets Length
        /// </summary>
        [DataMember(Name="length", EmitDefaultValue=false)]
        public int? Length { get; set; }

        /// <summary>
        /// Gets or Sets Width
        /// </summary>
        [DataMember(Name="width", EmitDefaultValue=false)]
        public int? Width { get; set; }

        /// <summary>
        /// Gets or Sets Height
        /// </summary>
        [DataMember(Name="height", EmitDefaultValue=false)]
        public int? Height { get; set; }

        /// <summary>
        /// MRN code. / Kod MRN.
        /// </summary>
        /// <value>MRN code. / Kod MRN.</value>
        [DataMember(Name="mrn", EmitDefaultValue=false)]
        public string Mrn { get; set; }

        /// <summary>
        /// Reference number. / Číslo jednací.
        /// </summary>
        /// <value>Reference number. / Číslo jednací.</value>
        [DataMember(Name="referenceNumber", EmitDefaultValue=false)]
        public string ReferenceNumber { get; set; }

        /// <summary>
        /// Number of pallets. / Počet palet.
        /// </summary>
        /// <value>Number of pallets. / Počet palet.</value>
        [DataMember(Name="pallets", EmitDefaultValue=false)]
        public int? Pallets { get; set; }

        /// <summary>
        /// Specific symbol. / Specifický symbol.
        /// </summary>
        /// <value>Specific symbol. / Specifický symbol.</value>
        [DataMember(Name="specSym", EmitDefaultValue=false)]
        public string SpecSym { get; set; }

        /// <summary>
        /// Note no. 2. / Poznámka 2.
        /// </summary>
        /// <value>Note no. 2. / Poznámka 2.</value>
        [DataMember(Name="note2", EmitDefaultValue=false)]
        public string Note2 { get; set; }

        /// <summary>
        /// Number of documents. / Počet dokumentů.
        /// </summary>
        /// <value>Number of documents. / Počet dokumentů.</value>
        [DataMember(Name="numSign", EmitDefaultValue=false)]
        public string NumSign { get; set; }

        /// <summary>
        /// Service price calculation. / Nápočet ceny služby.
        /// </summary>
        /// <value>Service price calculation. / Nápočet ceny služby.</value>
        [DataMember(Name="score", EmitDefaultValue=false)]
        public string Score { get; set; }

        /// <summary>
        /// Number of ZPRO&#x27;s number. / Číslo objednávky ZPRO.
        /// </summary>
        /// <value>Number of ZPRO&#x27;s number. / Číslo objednávky ZPRO.</value>
        [DataMember(Name="orderNumberZPRO", EmitDefaultValue=false)]
        public string OrderNumberZPRO { get; set; }

        /// <summary>
        /// Number of days for returning the parcel. / Počet dní pro vrácení zásilky.
        /// </summary>
        /// <value>Number of days for returning the parcel. / Počet dní pro vrácení zásilky.</value>
        [DataMember(Name="returnNumDays", EmitDefaultValue=false)]
        public string ReturnNumDays { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ParcelParams {\n");
            sb.Append("  RecordID: ").Append(RecordID).Append("\n");
            sb.Append("  ParcelCode: ").Append(ParcelCode).Append("\n");
            sb.Append("  MasterCode: ").Append(MasterCode).Append("\n");
            sb.Append("  PrefixParcelCode: ").Append(PrefixParcelCode).Append("\n");
            sb.Append("  Weight: ").Append(Weight).Append("\n");
            sb.Append("  InsuredValue: ").Append(InsuredValue).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
            sb.Append("  VsVoucher: ").Append(VsVoucher).Append("\n");
            sb.Append("  VsParcel: ").Append(VsParcel).Append("\n");
            sb.Append("  SequenceParcel: ").Append(SequenceParcel).Append("\n");
            sb.Append("  QuantityParcel: ").Append(QuantityParcel).Append("\n");
            sb.Append("  Note: ").Append(Note).Append("\n");
            sb.Append("  NotePrint: ").Append(NotePrint).Append("\n");
            sb.Append("  Length: ").Append(Length).Append("\n");
            sb.Append("  Width: ").Append(Width).Append("\n");
            sb.Append("  Height: ").Append(Height).Append("\n");
            sb.Append("  Mrn: ").Append(Mrn).Append("\n");
            sb.Append("  ReferenceNumber: ").Append(ReferenceNumber).Append("\n");
            sb.Append("  Pallets: ").Append(Pallets).Append("\n");
            sb.Append("  SpecSym: ").Append(SpecSym).Append("\n");
            sb.Append("  Note2: ").Append(Note2).Append("\n");
            sb.Append("  NumSign: ").Append(NumSign).Append("\n");
            sb.Append("  Score: ").Append(Score).Append("\n");
            sb.Append("  OrderNumberZPRO: ").Append(OrderNumberZPRO).Append("\n");
            sb.Append("  ReturnNumDays: ").Append(ReturnNumDays).Append("\n");
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
            return this.Equals(input as ParcelParams);
        }

        /// <summary>
        /// Returns true if ParcelParams instances are equal
        /// </summary>
        /// <param name="input">Instance of ParcelParams to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ParcelParams input)
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
                    this.MasterCode == input.MasterCode ||
                    (this.MasterCode != null &&
                    this.MasterCode.Equals(input.MasterCode))
                ) && 
                (
                    this.PrefixParcelCode == input.PrefixParcelCode ||
                    (this.PrefixParcelCode != null &&
                    this.PrefixParcelCode.Equals(input.PrefixParcelCode))
                ) && 
                (
                    this.Weight == input.Weight ||
                    (this.Weight != null &&
                    this.Weight.Equals(input.Weight))
                ) && 
                (
                    this.InsuredValue == input.InsuredValue ||
                    (this.InsuredValue != null &&
                    this.InsuredValue.Equals(input.InsuredValue))
                ) && 
                (
                    this.Amount == input.Amount ||
                    (this.Amount != null &&
                    this.Amount.Equals(input.Amount))
                ) && 
                (
                    this.Currency == input.Currency ||
                    (this.Currency != null &&
                    this.Currency.Equals(input.Currency))
                ) && 
                (
                    this.VsVoucher == input.VsVoucher ||
                    (this.VsVoucher != null &&
                    this.VsVoucher.Equals(input.VsVoucher))
                ) && 
                (
                    this.VsParcel == input.VsParcel ||
                    (this.VsParcel != null &&
                    this.VsParcel.Equals(input.VsParcel))
                ) && 
                (
                    this.SequenceParcel == input.SequenceParcel ||
                    (this.SequenceParcel != null &&
                    this.SequenceParcel.Equals(input.SequenceParcel))
                ) && 
                (
                    this.QuantityParcel == input.QuantityParcel ||
                    (this.QuantityParcel != null &&
                    this.QuantityParcel.Equals(input.QuantityParcel))
                ) && 
                (
                    this.Note == input.Note ||
                    (this.Note != null &&
                    this.Note.Equals(input.Note))
                ) && 
                (
                    this.NotePrint == input.NotePrint ||
                    (this.NotePrint != null &&
                    this.NotePrint.Equals(input.NotePrint))
                ) && 
                (
                    this.Length == input.Length ||
                    (this.Length != null &&
                    this.Length.Equals(input.Length))
                ) && 
                (
                    this.Width == input.Width ||
                    (this.Width != null &&
                    this.Width.Equals(input.Width))
                ) && 
                (
                    this.Height == input.Height ||
                    (this.Height != null &&
                    this.Height.Equals(input.Height))
                ) && 
                (
                    this.Mrn == input.Mrn ||
                    (this.Mrn != null &&
                    this.Mrn.Equals(input.Mrn))
                ) && 
                (
                    this.ReferenceNumber == input.ReferenceNumber ||
                    (this.ReferenceNumber != null &&
                    this.ReferenceNumber.Equals(input.ReferenceNumber))
                ) && 
                (
                    this.Pallets == input.Pallets ||
                    (this.Pallets != null &&
                    this.Pallets.Equals(input.Pallets))
                ) && 
                (
                    this.SpecSym == input.SpecSym ||
                    (this.SpecSym != null &&
                    this.SpecSym.Equals(input.SpecSym))
                ) && 
                (
                    this.Note2 == input.Note2 ||
                    (this.Note2 != null &&
                    this.Note2.Equals(input.Note2))
                ) && 
                (
                    this.NumSign == input.NumSign ||
                    (this.NumSign != null &&
                    this.NumSign.Equals(input.NumSign))
                ) && 
                (
                    this.Score == input.Score ||
                    (this.Score != null &&
                    this.Score.Equals(input.Score))
                ) && 
                (
                    this.OrderNumberZPRO == input.OrderNumberZPRO ||
                    (this.OrderNumberZPRO != null &&
                    this.OrderNumberZPRO.Equals(input.OrderNumberZPRO))
                ) && 
                (
                    this.ReturnNumDays == input.ReturnNumDays ||
                    (this.ReturnNumDays != null &&
                    this.ReturnNumDays.Equals(input.ReturnNumDays))
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
                if (this.MasterCode != null)
                    hashCode = hashCode * 59 + this.MasterCode.GetHashCode();
                if (this.PrefixParcelCode != null)
                    hashCode = hashCode * 59 + this.PrefixParcelCode.GetHashCode();
                if (this.Weight != null)
                    hashCode = hashCode * 59 + this.Weight.GetHashCode();
                if (this.InsuredValue != null)
                    hashCode = hashCode * 59 + this.InsuredValue.GetHashCode();
                if (this.Amount != null)
                    hashCode = hashCode * 59 + this.Amount.GetHashCode();
                if (this.Currency != null)
                    hashCode = hashCode * 59 + this.Currency.GetHashCode();
                if (this.VsVoucher != null)
                    hashCode = hashCode * 59 + this.VsVoucher.GetHashCode();
                if (this.VsParcel != null)
                    hashCode = hashCode * 59 + this.VsParcel.GetHashCode();
                if (this.SequenceParcel != null)
                    hashCode = hashCode * 59 + this.SequenceParcel.GetHashCode();
                if (this.QuantityParcel != null)
                    hashCode = hashCode * 59 + this.QuantityParcel.GetHashCode();
                if (this.Note != null)
                    hashCode = hashCode * 59 + this.Note.GetHashCode();
                if (this.NotePrint != null)
                    hashCode = hashCode * 59 + this.NotePrint.GetHashCode();
                if (this.Length != null)
                    hashCode = hashCode * 59 + this.Length.GetHashCode();
                if (this.Width != null)
                    hashCode = hashCode * 59 + this.Width.GetHashCode();
                if (this.Height != null)
                    hashCode = hashCode * 59 + this.Height.GetHashCode();
                if (this.Mrn != null)
                    hashCode = hashCode * 59 + this.Mrn.GetHashCode();
                if (this.ReferenceNumber != null)
                    hashCode = hashCode * 59 + this.ReferenceNumber.GetHashCode();
                if (this.Pallets != null)
                    hashCode = hashCode * 59 + this.Pallets.GetHashCode();
                if (this.SpecSym != null)
                    hashCode = hashCode * 59 + this.SpecSym.GetHashCode();
                if (this.Note2 != null)
                    hashCode = hashCode * 59 + this.Note2.GetHashCode();
                if (this.NumSign != null)
                    hashCode = hashCode * 59 + this.NumSign.GetHashCode();
                if (this.Score != null)
                    hashCode = hashCode * 59 + this.Score.GetHashCode();
                if (this.OrderNumberZPRO != null)
                    hashCode = hashCode * 59 + this.OrderNumberZPRO.GetHashCode();
                if (this.ReturnNumDays != null)
                    hashCode = hashCode * 59 + this.ReturnNumDays.GetHashCode();
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
