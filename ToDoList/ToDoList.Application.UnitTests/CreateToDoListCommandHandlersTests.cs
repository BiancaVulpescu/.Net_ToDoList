using Application.Use_Cases.CommandHandlers;
using Application.Use_Cases.Commands;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using NSubstitute;
using System.ComponentModel.DataAnnotations;

namespace ToDoListManager.Application.UnitTests
{
    public class CreateToDoListCommandHandlersTests
    {
        private readonly IToDoListRepository repository;
        private readonly IMapper mapper;
        public CreateToDoListCommandHandlersTests()
        {
            repository = Substitute.For<IToDoListRepository>();
            mapper = Substitute.For<IMapper>();
        }
        [Fact]
        public void Given_CreateToDoListCommandHandler_When_DataIsValid_Then_HandleShouldReturn_TheCorrectGuidShouldBeReturned()
        {
            //Arrange
            var listId = Guid.NewGuid();
            var command = new CreateToDoListCommand();
            var list = new Domain.Entities.ToDoList { Id = listId };
            repository.AddAsync(list).Returns(Task.FromResult(listId));
            mapper.Map<Domain.Entities.ToDoList>(command).Returns(list);
            //Act
            var handler = new CreateToDoListCommandHandler(repository, mapper);
            var result = handler.Handle(command, CancellationToken.None);
            //Assert
            result.Should().NotBeNull();
            Assert.IsType<Guid>(result.Result);
            Assert.Equal(listId, result.Result);
        }
        [Fact]
        public void Given_CreateToDoListCommandHandler_When_DataIsInvalid_Then_HandleShould_ThrowValidationException()
        {
            // Arrange
            var command = new CreateToDoListCommand { Description = "" };
            var handler = new CreateToDoListCommandHandler(repository, mapper);

            // Act & Assert
            Assert.ThrowsAsync<ValidationException>(() => handler.Handle(command, CancellationToken.None));

        }



    }
}
