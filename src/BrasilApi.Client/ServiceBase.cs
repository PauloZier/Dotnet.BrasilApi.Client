using System;

namespace BrasilApi.Client
{
    public abstract class ServiceBase
    {
        protected BrasilApiConfiguration Configuration { get; }

        public ServiceBase(BrasilApiConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentException(nameof(configuration));
        }
    }
}
