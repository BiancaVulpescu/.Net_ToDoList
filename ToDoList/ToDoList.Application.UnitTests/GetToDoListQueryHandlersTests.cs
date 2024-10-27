using AutoMapper;
using Domain.Repositories;
using Domain.Entities;
using NSubstitute;
using Application.Use_Cases.Queries;
using Application.Use_Cases.QueryHandlers;
using FluentAssertions;
using Application.DTOs;
using Application.Use_Cases.Commands;
using Application.Use_Cases.CommandHandlers;

namespace ToDoListManager.Application.UnitTests
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
            List<ToDoList> lists = GenerateToDoLists();
            repository.GetAllAsync().Returns(lists);
            var query = new GetToDoListQuery();
            GenerateToDoListsDto(lists);
            //Act
            var handler = new GetToDoListQueryHandler(repository, mapper);
            var result = handler.Handle(query, CancellationToken.None);
            //Assert
            result.Should().NotBeNull();
            Assert.Equal(2, result.Result.Count);
        }
        [Fact]
        public void Given_GetToDoListQueryHandler_When_HandleIsCalled_Then_ShouldMapPropertiesCorrectly()
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
            for (int i = 0; i < lists.Count; i++)
            {
                Assert.Equal(lists[i].Id, result.Result[i].Id);
                Assert.Equal(lists[i].Description, result.Result[i].Description);
                Assert.Equal(lists[i].IsDone, result.Result[i].IsDone);
                Assert.Equal(lists[i].DueDate, result.Result[i].DueDate);
            }
        }

        private void GenerateToDoListsDto(List<ToDoList> lists)
        {
            mapper.Map<List<ToDoListDto>>(lists).Returns(new List<ToDoListDto> {
                new ToDoListDto {
                    Id = new Guid("11111111-1111-1111-1111-111111111111"),
                    Description = "Description 1",
                    IsDone = false,
                    DueDate = DateTime.Now.AddDays(1)
                },
                new ToDoListDto {
                    Id = new Guid("22222222-2222-2222-2222-222222222222"),
                    Description = "Description 2",
                    IsDone = true,
                    DueDate = DateTime.Now.AddDays(2)
                }
            });
        }

        private List<ToDoList> GenerateToDoLists()
        {
           return new List<Domain.Entities.ToDoList> {
                new Domain.Entities.ToDoList {
                    Id = new Guid("11111111-1111-1111-1111-111111111111"),
                    Description = "Description 1",
                    IsDone = false,
                    DueDate = DateTime.Now.AddDays(1)
                },
                new Domain.Entities.ToDoList {
                    Id = new Guid("22222222-2222-2222-2222-222222222222"),
                    Description = "Description 2",
                    IsDone = true,
                    DueDate = DateTime.Now.AddDays(2)
                }
            };
        }
        private void GenerateSingleToDoListDto(List<ToDoList> lists)
        {
            mapper.Map<List<ToDoListDto>>(lists).Returns(new List<ToDoListDto> {
                new ToDoListDto {
                    Id = Guid.NewGuid(),
                    Description = "OldDescription",
                    IsDone = false,
                    DueDate = DateTime.Now
                },
            });
        }
        private List<ToDoList> GenerateSingleToDoList()
        {
            return new List<ToDoList> {
                new ToDoList {
                    Id = Guid.NewGuid(),
                    Description = "OldDescription",
                    IsDone = false,
                    DueDate = DateTime.Now
                },
            };
        }

        [Fact]
        public void Given_UpdateCommandHandler_When_HandleIsCalled_Then_AToDoListShouldBeUpdated()
        {
            //Arrange
            List<ToDoList> tdls = GenerateSingleToDoList();
            repository.GetByIdAsync(tdls[0].Id).Returns(tdls[0]);
            ToDoList toBeUpdated = tdls[0];
            var command = new UpdateToDoListCommand
            {
                Id = toBeUpdated.Id,
                Description = "UpdatedDescription",
                IsDone = toBeUpdated.IsDone,
                DueDate = toBeUpdated.DueDate,
            };
            GenerateToDoListsDto(tdls);
            //Act
            var handler = new UpdateToDoListCommandHandler(repository, mapper);
            var result = handler.Handle(command, CancellationToken.None);
            //Assert
            result.Should().NotBeNull();
        }
    }
}
