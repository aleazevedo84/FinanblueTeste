using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Produtos.Api.Business.Entities;
using Produtos.Api.Business.Repositories;
using Produtos.Api.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Produtos.Api.Controllers
{
    [Authorize]
    [Route("/api/empresa")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaController(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        /// <summary>
        /// Este serviço permite obter todas as empresas
        /// </summary>
        /// <returns>Retorna status ok e dados das empresas</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter as empresas")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> Get()
        {
            var empresas = _empresaRepository.Obter()
                .Select(s => new EmpresaViewModel()
                {
                    Nome = s.Nome,
                });

            return Ok(empresas);
        }

        /// <summary>
        /// Este serviço permite cadastrar empresas.
        /// </summary>
        /// <param name="empresaViewModel"></param>
        /// <returns>Retorna status 201 e dados da empresa/returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar uma empresa")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Post(EmpresaViewModel empresaViewModel)
        {
            Empresa empresa = new Empresa();
            empresa.Nome = empresaViewModel.Nome;

            _empresaRepository.Adicionar(empresa);
            _empresaRepository.Commit();
            return Created("", empresaViewModel);
        }
    }
}
