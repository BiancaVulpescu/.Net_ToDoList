using AutoMapper;
using Domain.Repositories;
using Domain.Entities;
using NSubstitute;
using Application.Use_Cases.Queries;
using Application.Use_Cases.QueryHandlers;
using FluentAssertions;
using static System.Reflection.Metadata.BlobBuilder;
using Application.DTOs;

namespace ToDoList.Application.UnitTests
{
    public class GetToDoListQueryHandlersTests
    {
        private readonly IToDoListRepository repository;
        private readonly IMapper mapper;
        public GetToDoListQueryHandlersTests()
        {
            repository = Substitute.For<IToDoListRepository>();
            mapper = Substitute.For<IMapper>();
        }
        [Fact]
        public void Given_GetToDoListQueryHandler_When_HandleIsCalled_Then_AListOfToDoListsShouldBeReturned()
        {
            //Arrange
            List<Domain.Entities.ToDoList> lists = GenerateToDoLists();
            repository.GetAllAsync().Returns(lists);
            var query = new GetToDoListQuery();
            GenerateToDoListsDto(lists);
            //Act
            var handler = new GetToDoListQueryHandler(repository, mapper);
            var result = handler.Handle(query, CancellationToken.None);
            //Assert
            result.Should().NotBeNull();
            Assert.Equal(2, result.Result.Count);
            //Assert.Equal(lists[0].Id, result.Result[0].Id);
        }

        private void GenerateToDoListsDto(List<Domain.Entities.ToDoList> lists)
        {
            mapper.Map<List<ToDoListDto>>(lists).Returns(new List<ToDoListDto> {
                new ToDoListDto {
                    Id = Guid.NewGuid(),
                    Description = "Description 1",
                    IsDone = false,
                    DueDate = DateTime.Now
                },
                new ToDoListDto {
                    Id = Guid.NewGuid(),
                    Description = "Description 2",
                    IsDone = true,
                    DueDate = DateTime.Now
                }
            });
        }

        private List<Domain.Entities.ToDoList> GenerateToDoLists()
        {
           return new List<Domain.Entities.ToDoList> {
                new Domain.Entities.ToDoList {
                    Id = Guid.NewGuid(),
                    Description = "Description 1",
                    IsDone = false,
                    DueDate = DateTime.Now
                },
                new Domain.Entities.ToDoList {
                    Id = Guid.NewGuid(),
                    Description = "Description 2",
                    IsDone = true,
                    DueDate = DateTime.Now
                }
            };
        }
    }
}
