using Microsoft.AspNetCore.Mvc;
using Moq;
using web_app_domain;
using web_app_repository;

namespace Test
{
    public class UsuarioRepositoryTest
    {
        [Fact]
        public async Task ListarUsuarios()
        {
            //Arrange
            var usuarios = new List<Usuario>() {
                new Usuario()
                {
                    Email = "gabriel@gmail.com",
                    Id = 1,
                    Nome = "Gabriel Valls"
                },
                 new Usuario()
                {
                    Email = "ellen@gmail.com",
                    Id = 2,
                    Nome = "Ellen"
                },
                 new Usuario()
                {
                    Email = "gustavo@gmail.com",
                    Id = 3,
                    Nome = "Gustavo Rosa"
                },
            };

            var userRepositoryMock = new Mock<IUsuarioRepository>();
            userRepositoryMock.Setup(u => u.ListarUsuarios()).ReturnsAsync(usuarios);
            var userRepository = userRepositoryMock.Object;

            //Act
            var result = await userRepository.ListarUsuarios();

            //Assert
            Assert.Equal(usuarios, result );
        }

        [Fact]
        public async Task SalvarUsuario()
        {
            //Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                Email = "gabriel@fiap.com",
                Nome = "Bil Valls"
            };

            var userRepositoryMock = new Mock<IUsuarioRepository>();
            userRepositoryMock.Setup(u => u.SalvarUsuario(It.IsAny<Usuario>())).Returns(Task.CompletedTask);
            var userRepository = userRepositoryMock.Object;

            //Act
            await userRepository.SalvarUsuario(usuario);

            //Assert
            userRepositoryMock.Verify(u => u.SalvarUsuario(It.IsAny<Usuario>()), Times.Once());
            
        }
    }
}
