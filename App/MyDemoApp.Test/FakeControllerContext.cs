using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;

namespace MyDemoApp.Test
{
    public class FakeControllerContext : ControllerContext
    {
        private HttpContextBase _context = new FakeHttpContext();

        public override HttpContextBase HttpContext
        {
            get
            {
                return this._context;
            }
            set
            {
                this._context = value;
            }
        }
    }

    public class FakeHttpContext : HttpContextBase
    {
        private HttpRequestBase _request = new FakeHttpRequest();

        public override HttpRequestBase Request
        {
            get
            {
                return this._request;
            }
        }
    }

    public class FakeHttpRequest : HttpRequestBase
    {
        public override string this[string key]
        {
            get
            {
                return null;
            }
        }

        public override NameValueCollection Headers
        {
            get
            {
                return new NameValueCollection();
            }
        }
    }
}