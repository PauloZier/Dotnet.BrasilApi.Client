using System;
using BrasilApi.Client.V1.Interfaces.Services;
using BrasilApi.Client.V1.Services;

namespace BrasilApi.Client
{
    public class BrasilApiClient : IBrasilApiClient
    {
        private readonly BrasilApiConfiguration _configuration;
        public Versao1 V1 { get; }
        public Versao2 V2 { get; }

        public BrasilApiClient(BrasilApiConfiguration configuration = null)
        {
            _configuration = configuration ?? new BrasilApiConfiguration();
            V1 = new Versao1(_configuration);
            V2 = new Versao2(_configuration);
        }
    }

    public class Versao1
    {
        private readonly BrasilApiConfiguration _configuration;

        public Versao1(BrasilApiConfiguration configuration = null)
        {
            _configuration = configuration ?? new BrasilApiConfiguration();
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
                    _bankService = new BankService(_configuration);

                return _bankService;
            }
        }

        public ICepService Cep
        {
            get
            {
                if (_cepService == null)
                    _cepService = new CepService(_configuration);

                return _cepService;
            }
        }

        public IDadosCnpjService Cnpj
        {
            get
            {
                if (_dadosCnpjService == null)
                    _dadosCnpjService = new DadosCnpjService(_configuration);

                return _dadosCnpjService;
            }
        }

        public IDDDService DDD
        {
            get
            {
                if (_dddService == null)
                    _dddService = new DDDService(_configuration);

                return _dddService;
            }
        }

        public IFeriadoService Feriado
        {
            get
            {
                if (_feriadoService == null)
                    _feriadoService = new FeriadoService(_configuration);

                return _feriadoService;
            }
        }

        public IFipeService Fipe
        {
            get
            {
                if (_fipeService == null)
                    _fipeService = new FipeService(_configuration);

                return _fipeService;
            }
        }

        public IIbgeService IBGE
        {
            get
            {
                if (_ibgeService == null)
                    _ibgeService = new IbgeService(_configuration);

                return _ibgeService;
            }
        }
    }

    public class Versao2
    {
        private readonly BrasilApiConfiguration _configuration;

        public Versao2(BrasilApiConfiguration configuration = null)
        {
            _configuration = configuration ?? new BrasilApiConfiguration();
        }

        private V2.Interfaces.Services.ICepService _cepService;

        public V2.Interfaces.Services.ICepService Cep
        {
            get
            {
                if (_cepService == null)
                    _cepService = new V2.Services.CepService(_configuration);

                return _cepService;
            }
        }
    }
}
