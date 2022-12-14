using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrionTek.Data;
using OrionTek.Data.Models;
using OrionTek.Interfaces.Services;

namespace OrionTek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteServices _IClienteServices;

        public ClientesController(IClienteServices IClienteServices)
        {
            _IClienteServices = IClienteServices;
        }


        //Clientes por Empresa
        [HttpPost("ByEmpresa/{id}")]
        public async Task<IActionResult> GetClientsByEmpresa(int id)
        {
            var Clientes = await _IClienteServices.GetClientesByEmpresa(id);
            if (Clientes.Count() == 0) return BadRequest("No hay clientes asociado con esta empresa");


            return Ok(Clientes);
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Clientes = await _IClienteServices.GetAll();
            return Ok(Clientes);
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> ClienteById(int id)
        {
            var Cliente = await _IClienteServices.Get(id);
            if (Cliente == null) return BadRequest("Cliente no existe");
            return Ok(Cliente);
        }

        // POST: api/Clientes
        [HttpPost]
        public async Task<IActionResult> AddCliente(Cliente cliente)
        {
            if (cliente == null) return BadRequest("Envio un cliente vacio o imcompleto");
             _IClienteServices.Add(cliente);
            
            return Ok();
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id,Cliente cliente)
        {
            if (cliente == null) return BadRequest("Envio un cliente vacio o imcompleto");

            var ClienteDB = await _IClienteServices.Get(id);
            if (ClienteDB == null) return BadRequest("Cliente no existe");

             _IClienteServices.Update(ClienteDB, cliente);

            return Ok();

           
        }


        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var ClienteById = await _IClienteServices.Get(id);
            if (ClienteById == null) return BadRequest("Cliente no existe");

             _IClienteServices.Delete(ClienteById);

            return Ok();

        }

      
    }
}
