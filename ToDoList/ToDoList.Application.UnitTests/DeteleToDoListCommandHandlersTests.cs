using AutoMapper;
using Domain.Repositories;
using NSubstitute;
using Application.Use_Cases.Commands;
using Application.Use_Cases.CommandHandlers;
using FluentAssertions;

namespace ToDoListManager.Application.UnitTests
{
    public class DeleteToDoListCommandHandlersTests
    {
        private readonly IToDoListRepository repository;
        private readonly IMapper mapper;

        public DeleteToDoListCommandHandlersTests()
        {
            repository = Substitute.For<IToDoListRepository>();
            mapper = Substitute.For<IMapper>();
        }

        [Fact]
        public async Task Given_DeleteToDoListCommandHandler_When_HandleIsCalled_Then_SuccessShouldBeReturned()
        {
            // Arrange
            var listId = Guid.NewGuid();
            var toDoList = new Domain.Entities.ToDoList { Id = listId };
            repository.GetByIdAsync(listId).Returns(toDoList);
            repository.DeleteAsync(listId).Returns(Task.CompletedTask);

            var command = new DeleteToDoListCommand { Id = listId };

            // Act
            var handler = new DeleteToDoListCommandHandler(repository);
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            await repository.Received(1).DeleteAsync(listId);
            result.Should().BeTrue();
        }

        [Fact]
        public async Task Given_DeleteToDoListCommandHandler_When_ToDoListDoesNotExist_Then_FailureShouldBeReturned()
        {
            // Arrange
            var listId = Guid.NewGuid();
            repository.GetByIdAsync(listId).Returns(Task.FromResult<Domain.Entities.ToDoList>(null));

            var command = new DeleteToDoListCommand { Id = listId };

            // Act
            var handler = new DeleteToDoListCommandHandler(repository);
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            await repository.DidNotReceive().DeleteAsync(listId);
            result.Should().BeFalse();
        }
    }
}
