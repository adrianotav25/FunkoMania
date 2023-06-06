﻿using FunkoMania.Application.Interfaces;
using FunkoMania.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FunkoMania.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/client")]
    public class ClientController : Controller
    {
        private readonly IClientAppService _clientAppService;

        public ClientController(IClientAppService clientAppService)
        {
            _clientAppService = clientAppService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _clientAppService.SearchAsync(a => true);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientViewModel>> Get(Guid id)
        {
            var result = await _clientAppService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] ClientViewModel model)
        {
            var result = await _clientAppService.AddAsync(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ClientViewModel model)
        {
            return Ok(_clientAppService.Update(model));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _clientAppService.Remove(id);
            return Ok();
        }

        
    }
}
