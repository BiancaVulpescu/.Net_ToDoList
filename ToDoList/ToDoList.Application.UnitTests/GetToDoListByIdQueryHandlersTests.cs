using AutoMapper;
using Domain.Repositories;
using Domain.Entities;
using NSubstitute;
using Application.Use_Cases.Queries;
using Application.Use_Cases.QueryHandlers;
using FluentAssertions;
using System;
using Xunit;
using Application.DTOs;

namespace ToDoList.Application.UnitTests
{
    public class GetToDoListByIdQueryHandlersTests
    {
        private readonly IToDoListRepository repository;
        private readonly IMapper mapper;

        public GetToDoListByIdQueryHandlersTests()
        {
            repository = Substitute.For<IToDoListRepository>();
            mapper = Substitute.For<IMapper>();
        }

        [Fact]
        public async Task Given_GetToDoListByIdQueryHandler_When_HandleIsCalled_Then_TheCorrectToDoListShouldBeReturned()
        {
            // Arrange
            var list = GenerateToDoList();
            var listDto = new ToDoListDto
            {
                Id = list.Id,
                Description = list.Description,
                IsDone = list.IsDone,
                DueDate = list.DueDate
            };

            repository.GetByIdAsync(list.Id).Returns(list);
            mapper.Map<ToDoListDto>(list).Returns(listDto);

            var query = new GetToDoListByIdQuery { Id = list.Id };

            // Act
            var handler = new GetToDoListByIdQueryHandler(repository, mapper);
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(list.Id);
            result.Description.Should().Be("Description 1");
            result.IsDone.Should().BeFalse();
            result.DueDate.Should().BeCloseTo(DateTime.Now, precision: TimeSpan.FromMilliseconds(5000));
        }

        private Domain.Entities.ToDoList GenerateToDoList()
        {
            return new Domain.Entities.ToDoList
            {
                Id = Guid.NewGuid(),
                Description = "Description 1",
                IsDone = false,
                DueDate = DateTime.Now
            };
        }
    }
}
