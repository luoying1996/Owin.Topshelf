using Microsoft.Owin;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;

namespace TopShelf.IPO.FP
{
    public class OwinContext
    {
        private const string OwinContextKey = "owin.IOwinContext";

        public static IOwinContext Current
        {
            get { return (IOwinContext)CallContext.LogicalGetData(OwinContextKey); }
        }

        public static void Set(IOwinContext context)
        {
            CallContext.LogicalSetData(OwinContextKey, context);
        }

        public static void Remove(IOwinContext context)
        {
            CallContext.FreeNamedDataSlot(OwinContextKey);
        }
    }

    public class OwinContextMiddleware : OwinMiddleware
    {
        public OwinContextMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            try
            {
                OwinContext.Set(context);
                await Next.Invoke(context);
            }
            finally
            {
                OwinContext.Remove(context);
            }
        }
    }
}
