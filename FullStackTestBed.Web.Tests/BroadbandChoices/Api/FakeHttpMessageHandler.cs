using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FullStackTestBed.Web.Tests.BroadbandChoices.Api
{
    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, HttpResponseMessage> _action;
        private readonly HttpStatusCode _httpStatusCode;
        private bool _sendAsyncCalled;

        public FakeHttpMessageHandler(HttpStatusCode httpStatusCode)
        {
            _httpStatusCode = httpStatusCode;
        }

        public FakeHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> action)
        {
            _action = action;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _sendAsyncCalled = true;
            if (_action != null)
            {
                return Task.FromResult(_action(request));
            }

            var httpResponseMessage = new HttpResponseMessage
            {
                Content = new StringContent(""),
                StatusCode = _httpStatusCode
            };
            return Task.FromResult(httpResponseMessage);
        }

        public bool SendAsyncCalled
        {
            get { return _sendAsyncCalled; }
        }
    }
}
