using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Produtos.Api.Business.Entities;
using Produtos.Api.Business.Repositories;
using Produtos.Api.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Produtos.Api.Controllers
{
    [Authorize]
    [Route("/api/compra")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraRepository _compraRepository;
        private readonly IProdutoRepository _produtoRepository;

        public CompraController(ICompraRepository compraRepository,
                                IProdutoRepository produtoRepository)
        {
            _compraRepository = compraRepository;
            _produtoRepository = produtoRepository;
        }

        /// <summary>
        /// Este serviço permite obter todos as compras
        /// </summary>
        /// <returns>Retorna status ok e dados das compras</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter as compras")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> Get()
        {
            var compras = _compraRepository.Obter()
                .Select(s => new CompraViewModel()
                {
                    Produto = s.ProdutoId,
                    Quantidade = s.Quantidade
                });

            return Ok(compras);
        }

        /// <summary>
        /// Este serviço permite cadastrar compras.
        /// </summary>
        /// <param name="compraViewModel"></param>
        /// <returns>Retorna status 201 e dados da compra/returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar um produto")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Post(CompraViewModel compraViewModel)
        {
            var produto = _produtoRepository.ObterProduto(compraViewModel.Produto);
            if (produto == null)
            {
                return BadRequest("Produto inválido.");
            }

            Compra compra = new Compra();
            compra.ProdutoId = compraViewModel.Produto;
            compra.Quantidade = compraViewModel.Quantidade;

            _compraRepository.Adicionar(compra);
            _compraRepository.Commit();
            return Created("", compraViewModel);
        }
    }
}
