using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrionTek.Data.Models;
using OrionTek.Interfaces.Services;

namespace OrionTek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaServices _IEmpresaServices;

        public EmpresasController(IEmpresaServices IEmpresaServices)
        {
            _IEmpresaServices = IEmpresaServices;
        }

        // GET: api/Empresas
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Empresas = await _IEmpresaServices.GetAll();
            return Ok(Empresas);
        }

        // GET: api/Empresas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> EmpresaById(int id)
        {
            var Empresa = await _IEmpresaServices.Get(id);
            if (Empresa == null) return BadRequest("Empresa no existe");
            return Ok(Empresa);
        }

        // POST: api/Empresas
        [HttpPost]
        public async Task<IActionResult> AddEmpresa(Empresa Empresa)
        {
            if (Empresa == null) return BadRequest("Envio una empresa vacio o imcompleto");
            _IEmpresaServices.Add(Empresa);
            
            return Ok();
        }

        // PUT: api/Empresas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmpresa(int id, Empresa Empresa)
        {
            if (Empresa == null) return BadRequest("Envio una empresa vacio o imcompleto");

            var EmpresaDB = await _IEmpresaServices.Get(id);
            if (EmpresaDB == null) return BadRequest("Empresa no existe");

             _IEmpresaServices.Update(EmpresaDB, Empresa);

            return Ok();

           
        }

        // DELETE: api/Empresas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresa(int id)
        {
            var EmpresaById = await _IEmpresaServices.Get(id);
            if (EmpresaById == null) return BadRequest("Empresa no existe");

             _IEmpresaServices.Delete(EmpresaById);

            return Ok();

        }

  
    }
}
