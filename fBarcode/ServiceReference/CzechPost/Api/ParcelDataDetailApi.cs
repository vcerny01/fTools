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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using IO.Swagger.CzechPost.Client;
using IO.Swagger.CzechPost.Model;

namespace IO.Swagger.CzechPost.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
        public interface IParcelDataDetailApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get Parcel Data History.
        /// </summary>
        /// <remarks>
        /// Get informations of parcel history. It serves for POL submitters. /Získání historie zásilky. Slouží pro podavatele POL.
        /// </remarks>
        /// <exception cref="IO.Swagger.CzechPost.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parcelID">ID of parcel. / Čárový kód zásilky.</param>
        /// <returns>ParcelDataHistoryResult</returns>
        ParcelDataHistoryResult GetParcelDataHistory (string parcelID);

        /// <summary>
        /// Get Parcel Data History.
        /// </summary>
        /// <remarks>
        /// Get informations of parcel history. It serves for POL submitters. /Získání historie zásilky. Slouží pro podavatele POL.
        /// </remarks>
        /// <exception cref="IO.Swagger.CzechPost.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parcelID">ID of parcel. / Čárový kód zásilky.</param>
        /// <returns>ApiResponse of ParcelDataHistoryResult</returns>
        ApiResponse<ParcelDataHistoryResult> GetParcelDataHistoryWithHttpInfo (string parcelID);
        /// <summary>
        /// Get statuses of Parcels
        /// </summary>
        /// <remarks>
        /// Get informations about Parcel statuses. / Operace slouží k získání seznamu stavů zásilek.
        /// </remarks>
        /// <exception cref="IO.Swagger.CzechPost.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>ParcelStatusResponse</returns>
        ParcelStatusResponse GetParcelStatus (ParcelStatusRequest body);

        /// <summary>
        /// Get statuses of Parcels
        /// </summary>
        /// <remarks>
        /// Get informations about Parcel statuses. / Operace slouží k získání seznamu stavů zásilek.
        /// </remarks>
        /// <exception cref="IO.Swagger.CzechPost.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>ApiResponse of ParcelStatusResponse</returns>
        ApiResponse<ParcelStatusResponse> GetParcelStatusWithHttpInfo (ParcelStatusRequest body);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Get Parcel Data History.
        /// </summary>
        /// <remarks>
        /// Get informations of parcel history. It serves for POL submitters. /Získání historie zásilky. Slouží pro podavatele POL.
        /// </remarks>
        /// <exception cref="IO.Swagger.CzechPost.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parcelID">ID of parcel. / Čárový kód zásilky.</param>
        /// <returns>Task of ParcelDataHistoryResult</returns>
        System.Threading.Tasks.Task<ParcelDataHistoryResult> GetParcelDataHistoryAsync (string parcelID);

        /// <summary>
        /// Get Parcel Data History.
        /// </summary>
        /// <remarks>
        /// Get informations of parcel history. It serves for POL submitters. /Získání historie zásilky. Slouží pro podavatele POL.
        /// </remarks>
        /// <exception cref="IO.Swagger.CzechPost.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parcelID">ID of parcel. / Čárový kód zásilky.</param>
        /// <returns>Task of ApiResponse (ParcelDataHistoryResult)</returns>
        System.Threading.Tasks.Task<ApiResponse<ParcelDataHistoryResult>> GetParcelDataHistoryAsyncWithHttpInfo (string parcelID);
        /// <summary>
        /// Get statuses of Parcels
        /// </summary>
        /// <remarks>
        /// Get informations about Parcel statuses. / Operace slouží k získání seznamu stavů zásilek.
        /// </remarks>
        /// <exception cref="IO.Swagger.CzechPost.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Task of ParcelStatusResponse</returns>
        System.Threading.Tasks.Task<ParcelStatusResponse> GetParcelStatusAsync (ParcelStatusRequest body);

        /// <summary>
        /// Get statuses of Parcels
        /// </summary>
        /// <remarks>
        /// Get informations about Parcel statuses. / Operace slouží k získání seznamu stavů zásilek.
        /// </remarks>
        /// <exception cref="IO.Swagger.CzechPost.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Task of ApiResponse (ParcelStatusResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ParcelStatusResponse>> GetParcelStatusAsyncWithHttpInfo (ParcelStatusRequest body);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
        public partial class ParcelDataDetailApi : IParcelDataDetailApi
    {
        private IO.Swagger.CzechPost.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParcelDataDetailApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ParcelDataDetailApi(String basePath)
        {
            this.Configuration = new IO.Swagger.CzechPost.Client.Configuration { BasePath = basePath };

            ExceptionFactory = IO.Swagger.CzechPost.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParcelDataDetailApi"/> class
        /// </summary>
        /// <returns></returns>
        public ParcelDataDetailApi()
        {
            this.Configuration = IO.Swagger.CzechPost.Client.Configuration.Default;

            ExceptionFactory = IO.Swagger.CzechPost.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParcelDataDetailApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ParcelDataDetailApi(IO.Swagger.CzechPost.Client.Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = IO.Swagger.CzechPost.Client.Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = IO.Swagger.CzechPost.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public IO.Swagger.CzechPost.Client.Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public IO.Swagger.CzechPost.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Get Parcel Data History. Get informations of parcel history. It serves for POL submitters. /Získání historie zásilky. Slouží pro podavatele POL.
        /// </summary>
        /// <exception cref="IO.Swagger.CzechPost.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parcelID">ID of parcel. / Čárový kód zásilky.</param>
        /// <returns>ParcelDataHistoryResult</returns>
        public ParcelDataHistoryResult GetParcelDataHistory (string parcelID)
        {
             ApiResponse<ParcelDataHistoryResult> localVarResponse = GetParcelDataHistoryWithHttpInfo(parcelID);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get Parcel Data History. Get informations of parcel history. It serves for POL submitters. /Získání historie zásilky. Slouží pro podavatele POL.
        /// </summary>
        /// <exception cref="IO.Swagger.CzechPost.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parcelID">ID of parcel. / Čárový kód zásilky.</param>
        /// <returns>ApiResponse of ParcelDataHistoryResult</returns>
        public ApiResponse< ParcelDataHistoryResult > GetParcelDataHistoryWithHttpInfo (string parcelID)
        {
            // verify the required parameter 'parcelID' is set
            if (parcelID == null)
                throw new ApiException(400, "Missing required parameter 'parcelID' when calling ParcelDataDetailApi->GetParcelDataHistory");

            var localVarPath = "/parcelDataHistory/parcelID/{parcelID}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (parcelID != null) localVarPathParams.Add("parcelID", this.Configuration.ApiClient.ParameterToString(parcelID)); // path parameter
            // authentication (Api-Token) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Api-Token")))
            {
                localVarHeaderParams["Api-Token"] = this.Configuration.GetApiKeyWithPrefix("Api-Token");
            }
            // authentication (Authorization-Timestamp) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization-Timestamp")))
            {
                localVarHeaderParams["Authorization-Timestamp"] = this.Configuration.GetApiKeyWithPrefix("Authorization-Timestamp");
            }
            // authentication (HMAC_SHA256_Auth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetParcelDataHistory", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ParcelDataHistoryResult>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (ParcelDataHistoryResult) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(ParcelDataHistoryResult)));
        }

        /// <summary>
        /// Get Parcel Data History. Get informations of parcel history. It serves for POL submitters. /Získání historie zásilky. Slouží pro podavatele POL.
        /// </summary>
        /// <exception cref="IO.Swagger.CzechPost.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parcelID">ID of parcel. / Čárový kód zásilky.</param>
        /// <returns>Task of ParcelDataHistoryResult</returns>
        public async System.Threading.Tasks.Task<ParcelDataHistoryResult> GetParcelDataHistoryAsync (string parcelID)
        {
             ApiResponse<ParcelDataHistoryResult> localVarResponse = await GetParcelDataHistoryAsyncWithHttpInfo(parcelID);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get Parcel Data History. Get informations of parcel history. It serves for POL submitters. /Získání historie zásilky. Slouží pro podavatele POL.
        /// </summary>
        /// <exception cref="IO.Swagger.CzechPost.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parcelID">ID of parcel. / Čárový kód zásilky.</param>
        /// <returns>Task of ApiResponse (ParcelDataHistoryResult)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ParcelDataHistoryResult>> GetParcelDataHistoryAsyncWithHttpInfo (string parcelID)
        {
            // verify the required parameter 'parcelID' is set
            if (parcelID == null)
                throw new ApiException(400, "Missing required parameter 'parcelID' when calling ParcelDataDetailApi->GetParcelDataHistory");

            var localVarPath = "/parcelDataHistory/parcelID/{parcelID}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (parcelID != null) localVarPathParams.Add("parcelID", this.Configuration.ApiClient.ParameterToString(parcelID)); // path parameter
            // authentication (Api-Token) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Api-Token")))
            {
                localVarHeaderParams["Api-Token"] = this.Configuration.GetApiKeyWithPrefix("Api-Token");
            }
            // authentication (Authorization-Timestamp) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization-Timestamp")))
            {
                localVarHeaderParams["Authorization-Timestamp"] = this.Configuration.GetApiKeyWithPrefix("Authorization-Timestamp");
            }
            // authentication (HMAC_SHA256_Auth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetParcelDataHistory", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ParcelDataHistoryResult>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (ParcelDataHistoryResult) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(ParcelDataHistoryResult)));
        }

        /// <summary>
        /// Get statuses of Parcels Get informations about Parcel statuses. / Operace slouží k získání seznamu stavů zásilek.
        /// </summary>
        /// <exception cref="IO.Swagger.CzechPost.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>ParcelStatusResponse</returns>
        public ParcelStatusResponse GetParcelStatus (ParcelStatusRequest body)
        {
             ApiResponse<ParcelStatusResponse> localVarResponse = GetParcelStatusWithHttpInfo(body);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get statuses of Parcels Get informations about Parcel statuses. / Operace slouží k získání seznamu stavů zásilek.
        /// </summary>
        /// <exception cref="IO.Swagger.CzechPost.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>ApiResponse of ParcelStatusResponse</returns>
        public ApiResponse< ParcelStatusResponse > GetParcelStatusWithHttpInfo (ParcelStatusRequest body)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling ParcelDataDetailApi->GetParcelStatus");

            var localVarPath = "/parcelStatus";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (Api-Token) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Api-Token")))
            {
                localVarHeaderParams["Api-Token"] = this.Configuration.GetApiKeyWithPrefix("Api-Token");
            }
            // authentication (Authorization-Timestamp) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization-Timestamp")))
            {
                localVarHeaderParams["Authorization-Timestamp"] = this.Configuration.GetApiKeyWithPrefix("Authorization-Timestamp");
            }
            // authentication (Authorization-content-SHA256) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization-Content-SHA256")))
            {
                localVarHeaderParams["Authorization-Content-SHA256"] = this.Configuration.GetApiKeyWithPrefix("Authorization-Content-SHA256");
            }
            // authentication (HMAC_SHA256_Auth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetParcelStatus", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ParcelStatusResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (ParcelStatusResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(ParcelStatusResponse)));
        }

        /// <summary>
        /// Get statuses of Parcels Get informations about Parcel statuses. / Operace slouží k získání seznamu stavů zásilek.
        /// </summary>
        /// <exception cref="IO.Swagger.CzechPost.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Task of ParcelStatusResponse</returns>
        public async System.Threading.Tasks.Task<ParcelStatusResponse> GetParcelStatusAsync (ParcelStatusRequest body)
        {
             ApiResponse<ParcelStatusResponse> localVarResponse = await GetParcelStatusAsyncWithHttpInfo(body);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get statuses of Parcels Get informations about Parcel statuses. / Operace slouží k získání seznamu stavů zásilek.
        /// </summary>
        /// <exception cref="IO.Swagger.CzechPost.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Task of ApiResponse (ParcelStatusResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ParcelStatusResponse>> GetParcelStatusAsyncWithHttpInfo (ParcelStatusRequest body)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling ParcelDataDetailApi->GetParcelStatus");

            var localVarPath = "/parcelStatus";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (Api-Token) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Api-Token")))
            {
                localVarHeaderParams["Api-Token"] = this.Configuration.GetApiKeyWithPrefix("Api-Token");
            }
            // authentication (Authorization-Timestamp) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization-Timestamp")))
            {
                localVarHeaderParams["Authorization-Timestamp"] = this.Configuration.GetApiKeyWithPrefix("Authorization-Timestamp");
            }
            // authentication (Authorization-content-SHA256) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization-Content-SHA256")))
            {
                localVarHeaderParams["Authorization-Content-SHA256"] = this.Configuration.GetApiKeyWithPrefix("Authorization-Content-SHA256");
            }
            // authentication (HMAC_SHA256_Auth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetParcelStatus", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ParcelStatusResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (ParcelStatusResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(ParcelStatusResponse)));
        }

    }
}