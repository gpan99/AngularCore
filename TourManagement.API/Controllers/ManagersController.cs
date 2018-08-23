using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManagement.API.Dtos;
using TourManagement.API.Helpers;
using TourManagement.API.Services;

namespace TourManagement.API.Controllers
{
    [Route("api/managers")]
    public class ManagersController : Controller
    {
        private readonly ITourManagementRepository _tourManagementRepository;

        public ManagersController(ITourManagementRepository tourManagementRepository)
        {
            _tourManagementRepository = tourManagementRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetManagers()
        {
            var managersFromRepo = await _tourManagementRepository.GetManagers();

            var managers = Mapper.Map<IEnumerable<Manager>>(managersFromRepo);

            return Ok(managers);
        }
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var managersFromRepo = _tourManagementRepository.GetManager(id);
            var manager = Mapper.Map<Manager>(managersFromRepo);

            return Ok(manager);
        }

        // POST api/<controller>
        [HttpPost]
        //[RequestHeaderMatchesMediaType("Content-Type",
        //    new[] { "application/json",
        //    "application/vnd.marvin.managercreation+json" })]
        public void Post([FromBody]Manager manager)
        {
            if (manager == null)
                return;
            var man = Mapper.Map<Entities.Manager>(manager);

            _tourManagementRepository.CreateManager(man);
        }

        // PUT api/<controller>/5
        [HttpPut("{managerId}")]
        public void Put(Guid managerId, [FromBody]Manager manager)
        {
            var man = Mapper.Map<Entities.Manager>(manager);
            _tourManagementRepository.UpdateManager(man);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
           _tourManagementRepository.DeleteManager(id);
        
            return;
        }
    }
}
