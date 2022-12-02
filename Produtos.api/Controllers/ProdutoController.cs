using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Produtos.Api.Business.Entities;
using Produtos.Api.Business.Repositories;
using Produtos.Api.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Produtos.Api.Controllers
{
    [Authorize]
    [Route("/api/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEmpresaRepository _empresaRepository;

        public ProdutoController(IProdutoRepository produtoRepository,
                                 IEmpresaRepository empresaRepository)
        {
            _produtoRepository = produtoRepository;
            _empresaRepository = empresaRepository;
        }

        /// <summary>
        /// Este serviço permite obter todos os produtos
        /// </summary>
        /// <returns>Retorna status ok e dados dos produtos</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter os produtos")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> Get()
        {
            var produtos = _produtoRepository.Obter()
                .Select(s => new ProdutoViewModel()
                {
                    Nome = s.Nome,
                    Valor = s.Valor,
                    Empresa = s.EmpresaId
                });

            return Ok(produtos);
        }

        /// <summary>
        /// Este serviço permite cadastrar produtos.
        /// </summary>
        /// <param name="produtoViewModel"></param>
        /// <returns>Retorna status 201 e dados do produto/returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar um produto")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Post(ProdutoViewModel produtoViewModel)
        {
            var empresa = _empresaRepository.ObterEmpresa(produtoViewModel.Empresa);
            if (empresa == null)
            {
                return BadRequest("Empresa inválida.");
            }

            Produto produto = new Produto();
            produto.Nome = produtoViewModel.Nome;
            produto.Valor = produtoViewModel.Valor;
            produto.EmpresaId = produtoViewModel.Empresa;

            _produtoRepository.Adicionar(produto);
            _produtoRepository.Commit();
            return Created("", produtoViewModel);
        }
    }
}
