﻿using web_app_domain;

namespace web_app_repository
{
    public interface IProdutoRepository
    {
   
         Task<IEnumerable<Produtos>> ListarProdutos();
         Task SalvarProdutos(Produtos produtos);
         Task AtualizarProdutos(Produtos produtos);
         Task RemoverProdutos(int id);

        
    }
}