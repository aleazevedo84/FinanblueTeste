using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Produtos.Api.Business.Entities;
using Produtos.Api.Business.Repositories;
using Produtos.Api.Models;

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
        [HttpGet("listar")]
        public async Task<IActionResult> Get()
        {
            var produtos = _produtoRepository.Obter()
                .Select(s => new ProdutoViewModel()
                {
                    Nome = s.Nome,
                    Valor = s.Valor,
                    Empresa = s.EmpresaId,
                    Situacao = s.Situacao
                });

            return Ok(produtos);
        }

        /// <summary>
        /// Este serviço permite cadastrar produtos.
        /// </summary>
        /// <param name="produtoViewModel"></param>
        /// <returns>Retorna status 201 e dados do produto/returns>
        [HttpPost("cadastrar")]
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
            produto.Situacao = produtoViewModel.Situacao;

            _produtoRepository.Adicionar(produto);
            return Created("", produtoViewModel);
        }
    }
}
