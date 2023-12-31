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
    /// ResultLetter
    /// </summary>
    [DataContract]
        public partial class ResultLetter :  IEquatable<ResultLetter>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultLetter" /> class.
        /// </summary>
        /// <param name="statusResponse">statusResponse (required).</param>
        /// <param name="parcelParamsResult">parcelParamsResult.</param>
        public ResultLetter(List<StatusResponseItem> statusResponse = default(List<StatusResponseItem>), List<ParcelParamsResult> parcelParamsResult = default(List<ParcelParamsResult>))
        {
            // to ensure "statusResponse" is required (not null)
            if (statusResponse == null)
            {
                throw new InvalidDataException("statusResponse is a required property for ResultLetter and cannot be null");
            }
            else
            {
                this.StatusResponse = statusResponse;
            }
            this.ParcelParamsResult = parcelParamsResult;
        }
        
        /// <summary>
        /// Gets or Sets StatusResponse
        /// </summary>
        [DataMember(Name="StatusResponse", EmitDefaultValue=false)]
        public List<StatusResponseItem> StatusResponse { get; set; }

        /// <summary>
        /// Gets or Sets ParcelParamsResult
        /// </summary>
        [DataMember(Name="parcelParamsResult", EmitDefaultValue=false)]
        public List<ParcelParamsResult> ParcelParamsResult { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ResultLetter {\n");
            sb.Append("  StatusResponse: ").Append(StatusResponse).Append("\n");
            sb.Append("  ParcelParamsResult: ").Append(ParcelParamsResult).Append("\n");
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
            return this.Equals(input as ResultLetter);
        }

        /// <summary>
        /// Returns true if ResultLetter instances are equal
        /// </summary>
        /// <param name="input">Instance of ResultLetter to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ResultLetter input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.StatusResponse == input.StatusResponse ||
                    this.StatusResponse != null &&
                    input.StatusResponse != null &&
                    this.StatusResponse.SequenceEqual(input.StatusResponse)
                ) && 
                (
                    this.ParcelParamsResult == input.ParcelParamsResult ||
                    this.ParcelParamsResult != null &&
                    input.ParcelParamsResult != null &&
                    this.ParcelParamsResult.SequenceEqual(input.ParcelParamsResult)
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
                if (this.StatusResponse != null)
                    hashCode = hashCode * 59 + this.StatusResponse.GetHashCode();
                if (this.ParcelParamsResult != null)
                    hashCode = hashCode * 59 + this.ParcelParamsResult.GetHashCode();
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
