using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using web_app_domain;
using web_app_performance.Controllers;
using web_app_repository;

namespace Test
{
    public class ProdutoControllerTest
    {
            private readonly Mock<IProdutoRepository> _userRepositoryMock;
            private readonly ProdutosController _controller;

            public ProdutoControllerTest()
            {
                _userRepositoryMock = new Mock<IProdutoRepository>();
                _controller = new ProdutosController(_userRepositoryMock.Object);
            }

            [Fact]
            public async Task Get_ListarProdutosOk()
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
            };
                _userRepositoryMock.Setup(r => r.ListarProdutos()).ReturnsAsync(produtos);

                //Action
                var result = await _controller.GetProdutos();

                //Asserts
                Assert.IsType<OkObjectResult>(result);
                var okResult = result as OkObjectResult;
                Assert.Equal(JsonConvert.SerializeObject(produtos), JsonConvert.SerializeObject(okResult.Value));

            }

            [Fact]
            public async Task Get_ListarRetornarNotFound()
            {
                _userRepositoryMock.Setup(u => u.ListarProdutos()).ReturnsAsync((IEnumerable<Produtos>)null);

                var result = await _controller.GetProdutos();

                Assert.IsType<NotFoundResult>(result);
            }
            
        [Fact]
        public async Task Post_SalvarProduto()
        {
            // Arrange
            var produto = new Produtos
            {
                Id = 2,
                Nome = "Arroz",
                Preco = 20,
                Quant_estoque = 5,
                Data_criacao = DateTime.Now
            };

            _userRepositoryMock.Setup(u => u.SalvarProdutos(It.IsAny<Produtos>())).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Post(produto);

            // Assert
            _userRepositoryMock.Verify(u => u.SalvarProdutos(It.IsAny<Produtos>()), Times.Once());
            Assert.IsType<OkObjectResult>(result); // Verifica se o resultado é do tipo OkObjectResult
        }
    }
}
