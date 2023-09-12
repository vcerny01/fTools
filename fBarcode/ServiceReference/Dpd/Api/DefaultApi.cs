using System;
using System.Collections.Generic;
using RestSharp;
using IO.Swagger.Dpd.Client;
using IO.Swagger.Dpd.Model;

namespace IO.Swagger.Dpd.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDefaultApi
    {
        /// <summary>
        /// List all available countries for your account 
        /// </summary>
        /// <returns>List&lt;Country&gt;</returns>
        List<Country> CountriesGet ();
        /// <summary>
        /// List all addresses associated with the specified customer You can use these customer addresses when creating a new shipment or pickup order.  If the customer is not associated with your account, an error will be returned. 
        /// </summary>
        /// <param name="customerDSW">The DSW of the customer in question</param>
        /// <returns>List&lt;CustomerAddress&gt;</returns>
        List<CustomerAddress> CustomersCustomerDSWAddressesGet (string customerDSW);
        /// <summary>
        /// List all customers associated with the active user account Each user account has multiple customers associated with it.    Each customer has its own [DSW](#/CustomerDSW) and his own customer addresses. 
        /// </summary>
        /// <returns>List&lt;Customer&gt;</returns>
        List<Customer> CustomersGet ();
        /// <summary>
        /// Get the active customers of the user account and their list of addresses. Use this method to get information about your customers and customer addresses.  User account which is used to find the data is determined by an API key provided in a request header. 
        /// </summary>
        /// <returns>Me</returns>
        Me MeGet ();
        /// <summary>
        /// List all parcels for the current active user account Use this for getting the list of all parcels associated with any of the customers under this user account.   Returns everything that was created in a selected time-frame by the current user account.   The goal is to provide an overview of every parcel via a single endpoint. 
        /// </summary>
        /// <param name="from">Start of the time-frame in the YYYY-MM-DD (ISO 8601) format</param>
        /// <param name="to">End of the time-frame in the YYYY-MM-DD (ISO 8601) format</param>
        /// <returns>List&lt;Parcel&gt;</returns>
        List<Parcel> ParcelsGet (string from, string to);
        /// <summary>
        /// Print the labels for multiple parcels Same as the &#x60;POST /parcels/{parcelIdent}/labels&#x60; endpoint but for batched printing.   A single ZPL/EPL script will contain instructions for printing multiple labels.   The PDF will contain one or multiple pages with all labels.  **Capabilities**  Same as the &#x60;POST /parcels/{parcelIdent}/labels&#x60;   **Limitations**  Same as the &#x60;POST /parcels/{parcelIdent}/labels&#x60; 
        /// </summary>
        /// <param name="body">The printing options and parcels</param>
        /// <returns>string</returns>
        string ParcelsLabelsPost (ParcelsLabelsPostRequest body);
        /// <summary>
        /// Print the parcel labels The parcel can have multiple labels, so an array is always returned.   The script/PDF always contains only single label.  Two labels will be returned when printing the labels for a swap parcel.   One of the labels, that is designated for the return journey to the sender, is placed into the package.   The system allows only for a single parcel swap shipments. The exchange is always done on a piece-by-piece bases.  **Capabilities**  - You can choose between the following formats: **ZPL, EPL, PDF and raw data**.     For more info see [Print Type](#/PrintType)   - The ZPL/EPL script can be sent directly to the printer port.     - The decoded Base64 can be saved as a PDF file.     - The raw data output can be used to populate a custom print template.  **Limitations**  - **This endpoint cannot be called for collection parcels, DPD will take care of printing their shipping labels.**     Collection parcels - Parcels that are sent from the customer to you (e.g. a complaint) 
        /// </summary>
        /// <param name="body">The printing options</param>
        /// <param name="parcelIdent">The identification number of the parcel in question</param>
        /// <returns>string</returns>
        string ParcelsParcelIdentLabelsPost (ParcelsParcelIdentLabelsPostRequest body, ParcelsParcelIdentLabelsPostParcelIdentParameter parcelIdent);
        /// <summary>
        /// Get parcel tracking info 
        /// </summary>
        /// <param name="parcelNo">The parcel number of the parcel in question</param>
        /// <returns>ParcelEvent</returns>
        ParcelEvent ParcelsParcelNoTrackingGet (string parcelNo);
        /// <summary>
        /// Get the tracking info for multiple parcels Same as the &#x60;GET /parcels/{parcelNo}/tracking&#x60; endpoint but for batched tracking information.   
        /// </summary>
        /// <param name="body"></param>
        /// <returns>List&lt;ParcelEvent&gt;</returns>
        List<ParcelEvent> ParcelsTrackingPost (ParcelsTrackingPostRequest body);
        /// <summary>
        /// Cancel pickup order by pickupOrderId Use this endpoint to cancel your parcel pickup orders.  **Limitations**  It might not be possible to cancel some pickup orders.   Pickup orders can be canceled only until a certain deadline    This is usually early in the morning of the pickup day. 
        /// </summary>
        /// <param name="pickupOrderId">The unique ID of the pickup order in question</param>
        /// <returns>PickupOrdersPickupOrderIdDelete200Response</returns>
        PickupOrdersPickupOrderIdDelete200Response PickupOrdersPickupOrderIdDelete (decimal? pickupOrderId);
        /// <summary>
        /// Show information about a specific pickup order. 
        /// </summary>
        /// <param name="pickupOrderId">The unique ID of the pickup order in question</param>
        /// <returns>PickupOrder</returns>
        PickupOrder PickupOrdersPickupOrderIdGet (decimal? pickupOrderId);
        /// <summary>
        /// Create a new pickup order. You can create pickup orders via this endpoint.   A pickup order is a request for a courier to come and pick your parcels up.   The courier will then proceed to forward the parcels into further transit and make sure they will eventually reach their shipping destination.    If the customerAddress (standard) or parcelNo (collection) is not found, an error will be returned  If you provide a parcel number that belongs to a standard parcel when creating the pickup order,   an error will be thrown as the parcel number is only expected to be provided when ordering a pickup for a collection parcel.    **Other means of ordering pickups**  - The pickup can be ordered via the &#x60;POST /pickup-orders&#x60; endpoint or it can be personally negotiated (you can setup recurring pickups this way). 
        /// </summary>
        /// <param name="body">The pickup order options</param>
        /// <returns>List&lt;PickupOrder&gt;</returns>
        List<PickupOrder> PickupOrdersPost (List<NewPickupOrder> body);
        /// <summary>
        /// Create new shipments Use this endpoint to create new parcel shipments.  Shipments consist of one or more parcels.  **Recommendations:**   *It is strongly recommended to batch the shipments into bigger requests. Sending many small requests at once can cause performance degradation. GeoApi is perfectly capable of handling 50 and more shipments in one request.*  In case you have incorporated a mistake into the shipment data,   just create a new shipment with corrected data.   You can then throw away the printed labels and use new ones. 
        /// </summary>
        /// <param name="body">The shipment specifications</param>
        /// <returns>List&lt;Shipment&gt;</returns>
        List<Shipment> ShipmentsPost (List<NewShipment> body);
        /// <summary>
        /// List of all available shipping services in JSON. 
        /// </summary>
        /// <returns>List&lt;ShippingServiceList&gt;</returns>
        List<ShippingServiceList> ShippingServicesGet ();
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DefaultApi : IDefaultApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public DefaultApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DefaultApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }
    
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }
    
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }
    
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient {get; set;}
    
        /// <summary>
        /// List all available countries for your account 
        /// </summary>
        /// <returns>List&lt;Country&gt;</returns>
        public List<Country> CountriesGet ()
        {
    
            var path = "/countries";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    
            // authentication setting, if any
            String[] authSettings = new String[] { "ApiKeyAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CountriesGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CountriesGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<Country>) ApiClient.Deserialize(response.Content, typeof(List<Country>), response.Headers);
        }
    
        /// <summary>
        /// List all addresses associated with the specified customer You can use these customer addresses when creating a new shipment or pickup order.  If the customer is not associated with your account, an error will be returned. 
        /// </summary>
        /// <param name="customerDSW">The DSW of the customer in question</param>
        /// <returns>List&lt;CustomerAddress&gt;</returns>
        public List<CustomerAddress> CustomersCustomerDSWAddressesGet (string customerDSW)
        {
            // verify the required parameter 'customerDSW' is set
            if (customerDSW == null) throw new ApiException(400, "Missing required parameter 'customerDSW' when calling CustomersCustomerDSWAddressesGet");
    
            var path = "/customers/{customerDSW}/addresses";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "customerDSW" + "}", ApiClient.ParameterToString(customerDSW));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    
            // authentication setting, if any
            String[] authSettings = new String[] { "ApiKeyAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CustomersCustomerDSWAddressesGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CustomersCustomerDSWAddressesGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<CustomerAddress>) ApiClient.Deserialize(response.Content, typeof(List<CustomerAddress>), response.Headers);
        }
    
        /// <summary>
        /// List all customers associated with the active user account Each user account has multiple customers associated with it.    Each customer has its own [DSW](#/CustomerDSW) and his own customer addresses. 
        /// </summary>
        /// <returns>List&lt;Customer&gt;</returns>
        public List<Customer> CustomersGet ()
        {
    
            var path = "/customers";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    
            // authentication setting, if any
            String[] authSettings = new String[] { "ApiKeyAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CustomersGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CustomersGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<Customer>) ApiClient.Deserialize(response.Content, typeof(List<Customer>), response.Headers);
        }
    
        /// <summary>
        /// Get the active customers of the user account and their list of addresses. Use this method to get information about your customers and customer addresses.  User account which is used to find the data is determined by an API key provided in a request header. 
        /// </summary>
        /// <returns>Me</returns>
        public Me MeGet ()
        {
    
            var path = "/me";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    
            // authentication setting, if any
            String[] authSettings = new String[] { "ApiKeyAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling MeGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling MeGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (Me) ApiClient.Deserialize(response.Content, typeof(Me), response.Headers);
        }
    
        /// <summary>
        /// List all parcels for the current active user account Use this for getting the list of all parcels associated with any of the customers under this user account.   Returns everything that was created in a selected time-frame by the current user account.   The goal is to provide an overview of every parcel via a single endpoint. 
        /// </summary>
        /// <param name="from">Start of the time-frame in the YYYY-MM-DD (ISO 8601) format</param>
        /// <param name="to">End of the time-frame in the YYYY-MM-DD (ISO 8601) format</param>
        /// <returns>List&lt;Parcel&gt;</returns>
        public List<Parcel> ParcelsGet (string from, string to)
        {
            // verify the required parameter 'from' is set
            if (from == null) throw new ApiException(400, "Missing required parameter 'from' when calling ParcelsGet");
            // verify the required parameter 'to' is set
            if (to == null) throw new ApiException(400, "Missing required parameter 'to' when calling ParcelsGet");
    
            var path = "/parcels";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (from != null) queryParams.Add("from", ApiClient.ParameterToString(from)); // query parameter
 if (to != null) queryParams.Add("to", ApiClient.ParameterToString(to)); // query parameter
                        
            // authentication setting, if any
            String[] authSettings = new String[] { "ApiKeyAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ParcelsGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ParcelsGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<Parcel>) ApiClient.Deserialize(response.Content, typeof(List<Parcel>), response.Headers);
        }
    
        /// <summary>
        /// Print the labels for multiple parcels Same as the &#x60;POST /parcels/{parcelIdent}/labels&#x60; endpoint but for batched printing.   A single ZPL/EPL script will contain instructions for printing multiple labels.   The PDF will contain one or multiple pages with all labels.  **Capabilities**  Same as the &#x60;POST /parcels/{parcelIdent}/labels&#x60;   **Limitations**  Same as the &#x60;POST /parcels/{parcelIdent}/labels&#x60; 
        /// </summary>
        /// <param name="body">The printing options and parcels</param>
        /// <returns>string</returns>
        public string ParcelsLabelsPost (ParcelsLabelsPostRequest body)
        {
            // verify the required parameter 'body' is set
            if (body == null) throw new ApiException(400, "Missing required parameter 'body' when calling ParcelsLabelsPost");
    
            var path = "/parcels/labels";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    postBody = ApiClient.Serialize(body); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "ApiKeyAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ParcelsLabelsPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ParcelsLabelsPost: " + response.ErrorMessage, response.ErrorMessage);
    
            return (string) ApiClient.Deserialize(response.Content, typeof(string), response.Headers);
        }
    
        /// <summary>
        /// Print the parcel labels The parcel can have multiple labels, so an array is always returned.   The script/PDF always contains only single label.  Two labels will be returned when printing the labels for a swap parcel.   One of the labels, that is designated for the return journey to the sender, is placed into the package.   The system allows only for a single parcel swap shipments. The exchange is always done on a piece-by-piece bases.  **Capabilities**  - You can choose between the following formats: **ZPL, EPL, PDF and raw data**.     For more info see [Print Type](#/PrintType)   - The ZPL/EPL script can be sent directly to the printer port.     - The decoded Base64 can be saved as a PDF file.     - The raw data output can be used to populate a custom print template.  **Limitations**  - **This endpoint cannot be called for collection parcels, DPD will take care of printing their shipping labels.**     Collection parcels - Parcels that are sent from the customer to you (e.g. a complaint) 
        /// </summary>
        /// <param name="body">The printing options</param>
        /// <param name="parcelIdent">The identification number of the parcel in question</param>
        /// <returns>string</returns>
        public string ParcelsParcelIdentLabelsPost (ParcelsParcelIdentLabelsPostRequest body, ParcelsParcelIdentLabelsPostParcelIdentParameter parcelIdent)
        {
            // verify the required parameter 'body' is set
            if (body == null) throw new ApiException(400, "Missing required parameter 'body' when calling ParcelsParcelIdentLabelsPost");
            // verify the required parameter 'parcelIdent' is set
            if (parcelIdent == null) throw new ApiException(400, "Missing required parameter 'parcelIdent' when calling ParcelsParcelIdentLabelsPost");
    
            var path = "/parcels/{parcelIdent}/labels";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "parcelIdent" + "}", ApiClient.ParameterToString(parcelIdent));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    postBody = ApiClient.Serialize(body); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "ApiKeyAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ParcelsParcelIdentLabelsPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ParcelsParcelIdentLabelsPost: " + response.ErrorMessage, response.ErrorMessage);
    
            return (string) ApiClient.Deserialize(response.Content, typeof(string), response.Headers);
        }
    
        /// <summary>
        /// Get parcel tracking info 
        /// </summary>
        /// <param name="parcelNo">The parcel number of the parcel in question</param>
        /// <returns>ParcelEvent</returns>
        public ParcelEvent ParcelsParcelNoTrackingGet (string parcelNo)
        {
            // verify the required parameter 'parcelNo' is set
            if (parcelNo == null) throw new ApiException(400, "Missing required parameter 'parcelNo' when calling ParcelsParcelNoTrackingGet");
    
            var path = "/parcels/{parcelNo}/tracking";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "parcelNo" + "}", ApiClient.ParameterToString(parcelNo));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    
            // authentication setting, if any
            String[] authSettings = new String[] { "ApiKeyAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ParcelsParcelNoTrackingGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ParcelsParcelNoTrackingGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ParcelEvent) ApiClient.Deserialize(response.Content, typeof(ParcelEvent), response.Headers);
        }
    
        /// <summary>
        /// Get the tracking info for multiple parcels Same as the &#x60;GET /parcels/{parcelNo}/tracking&#x60; endpoint but for batched tracking information.   
        /// </summary>
        /// <param name="body"></param>
        /// <returns>List&lt;ParcelEvent&gt;</returns>
        public List<ParcelEvent> ParcelsTrackingPost (ParcelsTrackingPostRequest body)
        {
            // verify the required parameter 'body' is set
            if (body == null) throw new ApiException(400, "Missing required parameter 'body' when calling ParcelsTrackingPost");
    
            var path = "/parcels/tracking";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    postBody = ApiClient.Serialize(body); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "ApiKeyAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ParcelsTrackingPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ParcelsTrackingPost: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<ParcelEvent>) ApiClient.Deserialize(response.Content, typeof(List<ParcelEvent>), response.Headers);
        }
    
        /// <summary>
        /// Cancel pickup order by pickupOrderId Use this endpoint to cancel your parcel pickup orders.  **Limitations**  It might not be possible to cancel some pickup orders.   Pickup orders can be canceled only until a certain deadline    This is usually early in the morning of the pickup day. 
        /// </summary>
        /// <param name="pickupOrderId">The unique ID of the pickup order in question</param>
        /// <returns>PickupOrdersPickupOrderIdDelete200Response</returns>
        public PickupOrdersPickupOrderIdDelete200Response PickupOrdersPickupOrderIdDelete (decimal? pickupOrderId)
        {
            // verify the required parameter 'pickupOrderId' is set
            if (pickupOrderId == null) throw new ApiException(400, "Missing required parameter 'pickupOrderId' when calling PickupOrdersPickupOrderIdDelete");
    
            var path = "/pickup-orders/{pickupOrderId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "pickupOrderId" + "}", ApiClient.ParameterToString(pickupOrderId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    
            // authentication setting, if any
            String[] authSettings = new String[] { "ApiKeyAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PickupOrdersPickupOrderIdDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PickupOrdersPickupOrderIdDelete: " + response.ErrorMessage, response.ErrorMessage);
    
            return (PickupOrdersPickupOrderIdDelete200Response) ApiClient.Deserialize(response.Content, typeof(PickupOrdersPickupOrderIdDelete200Response), response.Headers);
        }
    
        /// <summary>
        /// Show information about a specific pickup order. 
        /// </summary>
        /// <param name="pickupOrderId">The unique ID of the pickup order in question</param>
        /// <returns>PickupOrder</returns>
        public PickupOrder PickupOrdersPickupOrderIdGet (decimal? pickupOrderId)
        {
            // verify the required parameter 'pickupOrderId' is set
            if (pickupOrderId == null) throw new ApiException(400, "Missing required parameter 'pickupOrderId' when calling PickupOrdersPickupOrderIdGet");
    
            var path = "/pickup-orders/{pickupOrderId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "pickupOrderId" + "}", ApiClient.ParameterToString(pickupOrderId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    
            // authentication setting, if any
            String[] authSettings = new String[] { "ApiKeyAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PickupOrdersPickupOrderIdGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PickupOrdersPickupOrderIdGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (PickupOrder) ApiClient.Deserialize(response.Content, typeof(PickupOrder), response.Headers);
        }
    
        /// <summary>
        /// Create a new pickup order. You can create pickup orders via this endpoint.   A pickup order is a request for a courier to come and pick your parcels up.   The courier will then proceed to forward the parcels into further transit and make sure they will eventually reach their shipping destination.    If the customerAddress (standard) or parcelNo (collection) is not found, an error will be returned  If you provide a parcel number that belongs to a standard parcel when creating the pickup order,   an error will be thrown as the parcel number is only expected to be provided when ordering a pickup for a collection parcel.    **Other means of ordering pickups**  - The pickup can be ordered via the &#x60;POST /pickup-orders&#x60; endpoint or it can be personally negotiated (you can setup recurring pickups this way). 
        /// </summary>
        /// <param name="body">The pickup order options</param>
        /// <returns>List&lt;PickupOrder&gt;</returns>
        public List<PickupOrder> PickupOrdersPost (List<NewPickupOrder> body)
        {
            // verify the required parameter 'body' is set
            if (body == null) throw new ApiException(400, "Missing required parameter 'body' when calling PickupOrdersPost");
    
            var path = "/pickup-orders";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    postBody = ApiClient.Serialize(body); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "ApiKeyAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling PickupOrdersPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling PickupOrdersPost: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<PickupOrder>) ApiClient.Deserialize(response.Content, typeof(List<PickupOrder>), response.Headers);
        }
    
        /// <summary>
        /// Create new shipments Use this endpoint to create new parcel shipments.  Shipments consist of one or more parcels.  **Recommendations:**   *It is strongly recommended to batch the shipments into bigger requests. Sending many small requests at once can cause performance degradation. GeoApi is perfectly capable of handling 50 and more shipments in one request.*  In case you have incorporated a mistake into the shipment data,   just create a new shipment with corrected data.   You can then throw away the printed labels and use new ones. 
        /// </summary>
        /// <param name="body">The shipment specifications</param>
        /// <returns>List&lt;Shipment&gt;</returns>
        public List<Shipment> ShipmentsPost (List<NewShipment> body)
        {
            // verify the required parameter 'body' is set
            if (body == null) throw new ApiException(400, "Missing required parameter 'body' when calling ShipmentsPost");
    
            var path = "/shipments";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    postBody = ApiClient.Serialize(body); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "ApiKeyAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ShipmentsPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ShipmentsPost: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<Shipment>) ApiClient.Deserialize(response.Content, typeof(List<Shipment>), response.Headers);
        }
    
        /// <summary>
        /// List of all available shipping services in JSON. 
        /// </summary>
        /// <returns>List&lt;ShippingServiceList&gt;</returns>
        public List<ShippingServiceList> ShippingServicesGet ()
        {
    
            var path = "/shipping-services";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    
            // authentication setting, if any
            String[] authSettings = new String[] { "ApiKeyAuth" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ShippingServicesGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ShippingServicesGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<ShippingServiceList>) ApiClient.Deserialize(response.Content, typeof(List<ShippingServiceList>), response.Headers);
        }
    
    }
}
