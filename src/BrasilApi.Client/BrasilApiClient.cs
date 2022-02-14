using System;
using BrasilApi.Client.V1.Interfaces.Services;
using BrasilApi.Client.V1.Services;

namespace BrasilApi.Client
{
    public class BrasilApiClient : ServiceBase, IBrasilApiClient
    {
        public Versao1 V1 { get; }
        public Versao2 V2 { get; }

        public BrasilApiClient(BrasilApiConfiguration configuration = null)
            : base(configuration ?? new BrasilApiConfiguration())
        {
            V1 = new Versao1(this.Configuration);
            V2 = new Versao2(this.Configuration);
        }
    }

    public class Versao1 : ServiceBase
    {
        public Versao1(BrasilApiConfiguration configuration)
            : base(configuration)
        {
        }

        private IBankService _bankService;
        private ICepService _cepService;
        private IDadosCnpjService _dadosCnpjService;
        private IDDDService _dddService;
        private IFeriadoService _feriadoService;
        private IFipeService _fipeService;
        private IIbgeService _ibgeService;

        public IBankService Banks
        {
            get
            {
                if (_bankService == null)
                    _bankService = new BankService(this.Configuration);

                return _bankService;
            }
        }

        public ICepService Cep
        {
            get
            {
                if (_cepService == null)
                    _cepService = new CepService(this.Configuration);

                return _cepService;
            }
        }

        public IDadosCnpjService Cnpj
        {
            get
            {
                if (_dadosCnpjService == null)
                    _dadosCnpjService = new DadosCnpjService(this.Configuration);

                return _dadosCnpjService;
            }
        }

        public IDDDService DDD
        {
            get
            {
                if (_dddService == null)
                    _dddService = new DDDService(this.Configuration);

                return _dddService;
            }
        }

        public IFeriadoService Feriado
        {
            get
            {
                if (_feriadoService == null)
                    _feriadoService = new FeriadoService(this.Configuration);

                return _feriadoService;
            }
        }

        public IFipeService Fipe
        {
            get
            {
                if (_fipeService == null)
                    _fipeService = new FipeService(this.Configuration);

                return _fipeService;
            }
        }

        public IIbgeService IBGE
        {
            get
            {
                if (_ibgeService == null)
                    _ibgeService = new IbgeService(this.Configuration);

                return _ibgeService;
            }
        }
    }

    public class Versao2 : ServiceBase
    {
        public Versao2(BrasilApiConfiguration configuration)
            : base(configuration)
        {
        }

        private V2.Interfaces.Services.ICepService _cepService;

        public V2.Interfaces.Services.ICepService Cep
        {
            get
            {
                if (_cepService == null)
                    _cepService = new V2.Services.CepService(this.Configuration);

                return _cepService;
            }
        }
    }
}
