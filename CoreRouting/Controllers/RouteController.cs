using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CoreRouting.Models;

namespace CoreRouting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        /// <summary>
        /// Receives an HTTP GET request and provides a response message.
        /// </summary>
        /// <returns>An HTTP response with a body indicating the usage.</returns>
        /// <example>
        /// GET api/Route -> Received a GET request
        /// </example>
        [HttpGet]
        public string Get()
        {
            return "Received a GET request";
        }

        /// <summary>
        /// Receives an HTTP GET request and provides a response message.
        /// </summary>
        /// <returns>An HTTP response with a body indicating the usage.</returns>
        /// <example>
        /// GET api/Route/Get1 -> Received a different GET request
        /// </example>
        /// <remarks>
        /// The template allows us to have multiple different GET requests starting with /api/Route, each with a unique identifier (URL)
        /// </remarks>
        [HttpGet(template: "Get1")]
        public string Get1()
        {
            return "Received a different GET request";
        }

        /// <summary>
        /// Receives an HTTP GET request with one query parameter and provides a response message.
        /// </summary>
        /// <returns>An HTTP response with a body indicating the usage, echoing the value of queryParam1.</returns>
        /// <example>
        /// GET api/Route/Get2?queryParam1=hello -> Get method with one parameter. queryParam1: hello
        /// GET api/Route/Get2?queryParam1=world -> Get method with one parameter. queryParam1: world
        /// GET api/Route/Get2?queryParam1=100 -> Get method with one parameter. queryParam1: 100
        /// GET api/Route/Get2?queryParam1=hello%20world -> Get method with one parameter. queryParam1: hello world
        /// </example>
        /// <remarks>
        /// Allowed in URL: 
        /// Uppercase alpha (A-Z), lowercase alpha (a-z), numerical (0-9), - _ . ~ 
        /// Reserved in URL: 
        /// @ : / ? &  = # % + [ ] ! $ ( ) * , ;
        /// Characters not in the allowed list, or reserved characters used outside of their special meaning, must be "URL encoded".
        /// i.e. test@test.ca -> test%40test.ca
        /// </remarks>
        [HttpGet(template: "Get2")]
        public string Get2(string queryParam1)
        {
            return $"Received a GET request with one parameter. param1:{queryParam1}";
        }


        /// <summary>
        /// Receives an HTTP GET request with two query parameters and provides a response message.
        /// </summary>
        /// <returns>An HTTP response with a body indicating the usage, echoing the value of queryParam1 and queryParam2.</returns>
        /// <example>
        /// GET api/Route/Get3?queryParam1=20&queryParam2=5 -> Received a GET request with two parameters. queryParam1:20 queryParam2:5
        /// GET api/Route/Get3?queryParam1=6&queryParam2=-1 -> Received a GET request with two parameters. queryParam1:6 queryParam2:-1
        /// </example>
        [HttpGet(template: "Get3")]
        public string Get3(int queryParam1, int queryParam2)
        {
            return $"Received a GET request with two parameters. queryParam1:{queryParam1} queryParam2:{queryParam2}";
        }

        /// <summary>
        /// Receives an HTTP GET request with three query parameters and provides a response message.
        /// </summary>
        /// <returns>An HTTP response with the response body indicating the usage, echoing the value of queryParam1, queryParam2, and queryParam3.</returns>
        /// <example>
        /// GET api/Route/Get4?queryParam1=hello&queryParam2=2&queryParam3=people -> Received a GET request with three parameters. queryParam1: hello queryParam2: 2 queryParam3: people
        /// GET api/Route/Get4?queryParam1=test&queryParam2=0&queryParam3=test -> Received a GET request with three parameters. queryParam1: test queryParam2: 0 queryParam3: test
        /// </example>
        [HttpGet(template: "Get4")]
        public string Get4(string queryParam1, int queryParam2, string queryParam3)
        {
            return $"Received a GET request with three parameters. queryParam1: {queryParam1} queryParam2: {queryParam2} queryParam3: {queryParam3}";
        }

        /// <summary>
        /// Receives an HTTP GET request with one string route parameter and provides a response message.
        /// </summary>
        /// <returns>An HTTP response with a body indicating the usage, echoing the value of routeParam1.</returns>
        /// <example>
        /// GET api/Route/Get5/test -> Received a GET request with one parameter in the path. routeParam1: test
        /// GET api/Route/Get5/hi -> Received a GET request with one parameter in the path. routeParam1: hi
        /// </example>
        [HttpGet(template: "Get5/{routeParam1}")]
        public string Get5(string routeParam1)
        {
            return $"Received a GET request with one parameter in the path. routeParam1: {routeParam1}";
        }

        /// <summary>
        /// Receives an HTTP GET request with one integer route parameter and provides a response message.
        /// </summary>
        /// <returns>An HTTP response with a body echoing the value of routeParam1.</returns>
        /// <example>
        /// GET api/Route/Get6/0 -> Received a GET request with one parameter in the path. routeParam1: 0
        /// GET api/Route/Get6/-1 -> Received a GET request with one parameter in the path. routeParam1: -1
        /// GET api/Route/Get6/10 -> Received a GET request with one parameter in the path. routeParam1: 10
        /// </example>
        [HttpGet(template: "Get6/{routeParam1:int}")]
        public string Get6(int routeParam1)
        {
            return $"Received a GET request with one parameter in the path. routeParam1: {routeParam1}";
        }


        /// <summary>
        /// Receives an HTTP POST request with an empty body and provides a response message.
        /// </summary>
        /// <returns>An HTTP response with a body indicating the usage.</returns>
        /// <example>
        /// POST api/Route/Post1
        /// FORM DATA: (empty)
        /// -> Received a POST request with no request body
        /// </example>
        [HttpPost(template: "Post1")]
        public string Post1()
        {
            return "Received a POST request with no request body";
        }

        /// <summary>
        /// Receives an HTTP POST request with a body and provides a response message.
        /// </summary>
        /// <returns>An HTTP response with a body echoing the request body.</returns>
        /// <example>
        /// POST api/Route/Post2
        /// HEADERS: Content-Type: application/json
        /// FORM DATA: "request body"
        /// -> A post method with a request body. Body Content: request body
        /// </example>
        /// <remarks>
        /// In this example, the form data must be valid JSON string (with quotation marks). This is indicated with the request header Content-Type: application/json
        /// </remarks>
        [HttpPost(template: "Post2")]
        public string Post2([FromBody] string requestBody)
        {
            return $"Received a POST request with a request body. body: {requestBody}";
        }


        /// <summary>
        /// Receives an HTTP POST request with a body and path parameter and provides a response message.
        /// </summary>
        /// <returns>An HTTP response with a body echoing the request body and a path parameter.</returns>
        /// <example>
        /// POST api/Route/Post3/50
        /// HEADERS: Content-Type: application/json
        /// FORM DATA: "another request body"
        /// -> A post method with a request body. Body Content: another request body param1:50
        /// </example>
        [HttpPost(template: "Post3/{routeParam1}")]
        public string Post3([FromBody] string requestBody, int routeParam1)
        {
            return $"Received a POST request with both a route parameter and request body. body content: {requestBody} param1: {routeParam1}";
        }

        /// <summary>
        /// Receives an HTTP POST request with a form-encoded body containing two parameters.
        /// </summary>
        /// <returns>An HTTP response with a body echoing the request body parameters.</returns>
        /// <example>
        /// POST api/Route/Post4
        /// HEADERS: Content-Type: application/x-www-form-urlencoded
        /// FORM DATA: "bodyParam1=hello&bodyParam2=world"
        /// -> A post method with a form encoded request body. Body Content: bodyParam1: hello bodyParam2: world
        /// </example>
        [HttpPost(template: "Post4")]
        [Consumes("application/x-www-form-urlencoded")]
        public string Post4([FromForm]string bodyParam1, [FromForm]string bodyParam2)
        {
            return $"Received a POST request with both query parameter and request body. bodyParam1: {bodyParam1} bodyParam2: {bodyParam2}";
        }


        /// <summary>
        /// Receives an HTTP POST request with a mutlipart/form-data body containing two parameters.
        /// </summary>
        /// <returns>An HTTP response with a body echoing the request body parameters.</returns>
        /// <example>
        /// POST api/Route/Post5
        /// HEADERS: Content-Type: multipart/form-data; boundary=------{boundaryDelimiter}
        /// FORM DATA: 
        /// ------{boundaryDelimiter}
        /// Content-Disposition: form-data; name="bodyParam1"
        /// hello
        /// ------{boundaryDelimiter}
        /// Content-Disposition: form-data; name="bodyParam2"
        /// world
        /// ------{boundaryDelimiter}--
        /// -> A post method with a form encoded request body. bodyParam1: hello bodyParam2: world
        /// </example>
        /// <remarks>
        /// Useful for receiving file/binary data
        /// </remarks>
        [HttpPost(template: "Post5")]
        public string Post5([FromForm] string bodyParam1, [FromForm] string bodyParam2)
        {
            return $"Received a POST request with a form encoded request body. bodyParam1: {bodyParam1} bodyParam2: {bodyParam2}";
        }

        /// <summary>
        /// Receives an HTTP POST request with a request body containing two parameters in JSON format.
        /// </summary>
        /// <param name="JSONData">A model representing the information to receive. Defined in /Models/Payload.cs</param>
        /// <returns>An HTTP response with a body echoing the request body parameters.</returns>
        /// <example>
        /// POST api/Route/Post6
        /// HEADERS: Content-Type: application/json
        /// FORM DATA: {"bodyParam1":"hello","bodyParam2":"world"}
        /// -> Received a POST request with a JSON encoded request body. bodyParam1: hello bodyParam2: world
        /// </example>
        /// <remarks>
        ///  Commonly used technique to receive information and Create a resource as part of Create, Read, Update, Delete (CRUD) RESTful api. Generally non-idempotent (multiple duplicate calls will have an effect on the system state).
        ///  </remarks>
        [HttpPost(template: "Post6")]
        public string Post6([FromBody] Payload JSONData)
        {
            return $"Received a POST request with a JSON encoded request body. bodyParam1: {JSONData.BodyParam1} bodyParam2: {JSONData.BodyParam2}";
        }

        /// <summary>
        /// Receives an HTTP PUT request with a response body containing two parameters in JSON format and route parameter.
        /// </summary>
        /// <param name="JSONData">A model representing the information to receive. Defined in /Models/Payload.cs</param>
        /// <returns>An HTTP response with a body echoing the request body parameters.</returns>
        /// <example>
        /// PUT api/Route
        /// HEADERS: Content-Type: application/json
        /// FORM DATA: {"bodyParam1":"put","bodyParam2":"content"}
        /// -> Received a PUT request with a JSON encoded request body and route parameter. param1: bodyParam1 bodyParam2
        /// </example>
        /// <remarks>
        /// Commonly used technique to Update all elements of a resource as part of Create, Read, Update, Delete (CRUD) RESTful api. Generally idempotent (multiple duplicate calls will have the no effect on the system state).
        /// </remarks>
        [HttpPut(template: "{routeParam1}")]
        public string Put([FromBody] Payload JSONData, int routeParam1)
        {
            return $"Received a PUT request with a JSON encoded request body and route parameter. routeParam1: {routeParam1} bodyParam1: {JSONData.BodyParam1} bodyParam2: {JSONData.BodyParam2}";
        }

        /// <summary>
        /// Receives an HTTP PATCH request with a request body containing two parameters in JSON format and route parameter.
        /// </summary>
        /// <param name="routeParam1">An integer route parameter. Commonly an identifier of a resource (id).</param>
        /// <param name="JSONData">A model representing the information to receive. Defined in /Models/Payload.cs</param>
        /// <returns>An HTTP response with a body echoing information from the request body, and route parameters.</returns>
        /// <example>
        /// PATCH api/Route/2
        /// HEADERS: Content-Type: application/json
        /// FORM DATA: {"bodyParam1":"put","bodyParam2":"content"}
        /// -> Received a PUT request with a JSON encoded request body and route parameter. param1: 2 bodyParam1: put bodyParam2: content
        /// </example>
        /// <remarks>
        ///  Not as commonly used technique to Update parts of a resource as part of Create, Read, Update, Delete (CRUD) RESTful api. Idempotency depends on implementation (multiple duplicate calls may have an effect on the system state, depending on the definition).
        /// </remarks>
        [HttpPatch(template: "{routeParam1}")]
        public string Patch([FromBody] Payload JSONData, int routeParam1)
        {
            return $"Received a PUT request with a JSON encoded request body and route parameter. routeParam1: {routeParam1} bodyParam1: {JSONData.BodyParam1} bodyParam2: {JSONData.BodyParam2}";
        }

        /// <summary>
        /// Receives an HTTP DELETE request with a route parameter.
        /// </summary>
        /// <param name="routeParam1">An integer route parameter. Commonly an identifier of a resource (id).</param>
        /// <returns>An HTTP response with a body echoing the route parameter.</returns>
        /// <example>
        /// DELETE api/Route/5 ->
        /// </example>
        /// <remarks>
        /// Commonly used technique to Delete a resource as part of Create, Read, Update, Delete (CRUD) RESTful api. Generally idempotent (multiple duplicate calls will have no effect on the system state)
        /// </remarks>
        [HttpDelete(template: "{routeParam1}")]
        public string Delete(int routeParam1)
        {
            return "Received a DELETE request with a route parameter. routeParam1: {routeParam1}";
        }
    }
}
