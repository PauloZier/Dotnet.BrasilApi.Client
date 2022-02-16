using System.Net;
using System.Net.Http;
using System;

namespace BrasilApi.Client
{
    public class BrasilApiClientException : HttpRequestException
    {
        public HttpResponseMessage ResponseMessage { get; }
        public HttpStatusCode StatusCode => ResponseMessage.StatusCode;
        public string Content => ResponseMessage.Content.ReadAsStringAsync().Result;

        public BrasilApiClientException(HttpResponseMessage responseMessage, string message)
            : base(message)
        {   
            this.ResponseMessage = responseMessage;
        }

        public BrasilApiClientException()
        {
        }

        public BrasilApiClientException(string message) : base(message)
        {
        }

        public BrasilApiClientException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
