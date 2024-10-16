
using Moq;
using web_app_domain;
using web_app_repository;

namespace Test
{
    public class ProdutoRepositoryTest
    {
        [Fact]
        public async Task ListarProdutos()
        {
            //Arrange
            var produtos = new List<Produtos>() {
                new Produtos()
                {
                    Id = 1,
                    Nome = "Feijão",
                    Preco = 20,
                    Quant_estoque = 5,
                    Data_criacao = DateTime.Now
                },
                 new Produtos()
                {
                    Id = 4,
                    Nome = "Macarrão",
                    Preco = 20,
                    Quant_estoque = 5,
                    Data_criacao = DateTime.Now
                },
                 new Produtos()
                {
                    Id = 5,
                    Nome = "Açucar",
                    Preco = 20,
                    Quant_estoque = 5,
                    Data_criacao = DateTime.Now
                },
            };

            var userRepositoryMock = new Mock<IProdutoRepository>();
            userRepositoryMock.Setup(u => u.ListarProdutos()).ReturnsAsync(produtos);
            var userRepository = userRepositoryMock.Object;

            //Act
            var result = await userRepository.ListarProdutos();

            //Assert
            Assert.Equal(produtos, result);
        }

        [Fact]
        public async Task SalvarProduto()
        {
            //Arrange
            var produto = new Produtos()
            {
                Id = 10,
                Nome = "Feijão Preto",
                Preco = 20,
                Quant_estoque = 5,
                Data_criacao = DateTime.Now
            };

            var userRepositoryMock = new Mock<IProdutoRepository>();
            userRepositoryMock.Setup(u => u.SalvarProdutos(It.IsAny<Produtos>())).Returns(Task.CompletedTask);
            var userRepository = userRepositoryMock.Object;

            //Act
            await userRepository.SalvarProdutos(produto);

            //Assert
            userRepositoryMock.Verify(u => u.SalvarProdutos(It.IsAny<Produtos>()), Times.Once());

        }
    }
}
