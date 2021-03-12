using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrionTek.Data.Models;
using OrionTek.Interfaces.Services;

namespace OrionTek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionesController : ControllerBase
    {
        private readonly IDireccionServices _IDireccionServices;

        public DireccionesController(IDireccionServices IDireccionServices)
        {
            _IDireccionServices = IDireccionServices;
        }


        //Clientes por Empresa
        [HttpPost("ByCliente/{id}")]
        public async Task<IActionResult> GetClientsByEmpresa(int id)
        {
            var Direcciones = await _IDireccionServices.GetDireccionesByCliente(id);
            if (Direcciones.Count() == 0) return BadRequest("No hay direcciones asociado con este cliente");


            return Ok(Direcciones);
        }

        // GET: api/Direcciones
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Direcciones = await _IDireccionServices.GetAll();
            return Ok(Direcciones);
        }

        // GET: api/Direcciones/5
        [HttpGet("{id}")]
        public async Task<IActionResult> DireccionById(int id)
        {
            var Direccion = await _IDireccionServices.Get(id);
            if (Direccion == null) return BadRequest("Direccion no existe");
            return Ok(Direccion);
        }

        // POST: api/Direcciones
        [HttpPost]
        public async Task<IActionResult> AddDireccion(Direccion Direccion)
        {
            if (Direccion == null) return BadRequest("Envio una direccion vacio o imcompleto");
             _IDireccionServices.Add(Direccion);
            
            return Ok();
        }

        // PUT: api/Direcciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDireccion(int id, Direccion Direccion)
        {
            if (Direccion == null) return BadRequest("Envio una direccion vacio o imcompleto");

            var DireccionDB = await _IDireccionServices.Get(id);
            if (DireccionDB == null) return BadRequest("Direccion no existe");

             _IDireccionServices.Update(DireccionDB, Direccion);

            return Ok();

           
        }

        // DELETE: api/Direcciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDireccion(int id)
        {
            var DireccionById = await _IDireccionServices.Get(id);
            if (DireccionById == null) return BadRequest("Direccion no existe");

             _IDireccionServices.Delete(DireccionById);

            return Ok();

        }

  
    }
}
