﻿using Produtos.Api.Models;

namespace Produtos.Api.Configurations
{
    public interface IAutenticacaoService
    {
        string GerarToken(UsuarioViewModel usuarioViewModel);
    }
}
