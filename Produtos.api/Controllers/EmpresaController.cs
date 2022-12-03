using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Produtos.Api.Business.Entities;
using Produtos.Api.Business.Repositories;
using Produtos.Api.Models;

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
        [HttpGet("listar")]
        public async Task<IActionResult> Get()
        {
            var empresas = _empresaRepository.Obter()
                .Select(s => new EmpresaViewModel()
                {
                    Nome = s.Nome,
                    CNPJ = s.CNPJ,
                    DataAbertura = s.DataAbertura,
                    NaturezaJuridica = s.NaturezaJuridica,
                    Situacao = s.Situacao
                });

            return Ok(empresas);
        }

        /// <summary>
        /// Este serviço permite cadastrar empresas.
        /// </summary>
        /// <param name="empresaViewModel"></param>
        /// <returns>Retorna status 201 e dados da empresa/returns>
        [HttpPost("cadastrar")]
        public async Task<IActionResult> Post(EmpresaViewModel empresaViewModel)
        {
            Empresa empresa = new Empresa();
            empresa.Nome = empresaViewModel.Nome;
            empresa.CNPJ = empresaViewModel.CNPJ;
            empresa.DataAbertura = empresaViewModel.DataAbertura;
            empresa.NaturezaJuridica = empresaViewModel.NaturezaJuridica;
            empresa.Situacao = empresaViewModel.Situacao;

            _empresaRepository.Adicionar(empresa);
            _empresaRepository.Commit();
            return Created("", empresaViewModel);
        }
    }
}
