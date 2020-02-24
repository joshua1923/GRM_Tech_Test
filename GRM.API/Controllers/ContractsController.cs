using GRM.Shared.Interfaces;
using GRM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GRM.API.Controllers
{
    public class ContractsController : ApiController
    {
        readonly IGenericRepository<Contracts> _contractsRepository;
        readonly IGenericRepository<DistributionPartners> _partnersRepository;
        readonly IManager _manager;

        public ContractsController(IGenericRepository<Contracts> contractsRepository, IGenericRepository<DistributionPartners> partnersRepository, IManager manager)
        {
            _contractsRepository = contractsRepository;
            _partnersRepository = partnersRepository;
            _manager = manager;
        }

        [Route("api/GetAllContracts")]
        [HttpGet]
        public IEnumerable<Contracts> Get()
        {
            return _contractsRepository.GetAll();
        }

        [Route("api/GetContractsByCritera")]
        [HttpPost]
        public List<Contracts> Get(string date, string partner)
        {
            var usage = _partnersRepository.Get(x => x.Partner.Equals(partner, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().Usage;

            var contractsByUsage = _contractsRepository.Get(x => x.Usage.Equals(usage, StringComparison.InvariantCultureIgnoreCase)).ToList();

            return contractsByUsage.Where(x => x.StartDate.Equals(date, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        [Route("api/LoadContractsFile")]
        [HttpPost]
        public HttpResponseMessage PostContractFile(string filePath)
        {
            var response = _manager.ReadContractsFromFile(filePath);

            _contractsRepository.Add(response);
            _contractsRepository.Save();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Route("api/LoadPartnersFile")]
        [HttpPost]
        public HttpResponseMessage PostPartnerFile(string filePath)
        {
            var response = _manager.ReadPartnersFromFile(filePath);

            _partnersRepository.Add(response);
            _partnersRepository.Save();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
