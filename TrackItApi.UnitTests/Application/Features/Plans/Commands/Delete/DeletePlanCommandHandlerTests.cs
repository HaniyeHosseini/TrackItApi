using FluentAssertions;
using MediatR;
using Microsoft.VisualBasic.FileIO;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Contracts.Commands;
using TrackApi.Application.Contracts.Queries;
using TrackApi.Application.Exceptions;
using TrackApi.Application.Features.Plans.Commands.Delete;
using TrackItApi.Domain.Models;

namespace TrackItApi.UnitTests.Application.Features.Plans.Commands.Delete
{
    public class DeletePlanCommandHandlerTests
    {
        private readonly Mock<IPlanQueryRepository> _planQueryRepositoryMock;
        private readonly Mock<IPlanCommandRepository> _planCommandRepositoryMock;
        private readonly DeletePlanCommandHandler _handler;

        public DeletePlanCommandHandlerTests()
        {
            _planQueryRepositoryMock = new Mock<IPlanQueryRepository>();
            _planCommandRepositoryMock = new Mock<IPlanCommandRepository>();
            _handler = new DeletePlanCommandHandler(_planQueryRepositoryMock.Object, _planCommandRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnUnit_WhenPlanIsValid()
        {
            //Arrange
            var deletePlanCommand = new DeletePlanCommand(1);

            _planQueryRepositoryMock.Setup(x => x.GetByIdAsync(deletePlanCommand.Id)).ReturnsAsync(new Plan(Domain.Enums.PlanType.Daily, DateTime.UtcNow, DateTime.UtcNow.AddDays(1), null, null));
            _planCommandRepositoryMock.Setup(x => x.RemovePlanWithGoals(deletePlanCommand.Id)).Returns(Task.CompletedTask);

            //Act  
            var result = await _handler.Handle(deletePlanCommand, CancellationToken.None);

            //Assert
            Assert.Equal(Unit.Value, result);
            _planQueryRepositoryMock.Verify(x => x.GetByIdAsync(deletePlanCommand.Id), Times.Once);
            _planCommandRepositoryMock.Verify(x => x.RemovePlanWithGoals(deletePlanCommand.Id), Times.Once);
        }
        [Fact]
        public async Task Handle_ShouldThrowRecordNotFound_WhenPlanNotFound()
        {
            //Arrange
            var deletePlanCommand = new DeletePlanCommand(1);
            _planQueryRepositoryMock.Setup(x => x.GetByIdAsync(deletePlanCommand.Id)).ReturnsAsync((Plan?)null);

            //Act
            Func<Task> act = async () => await _handler.Handle(deletePlanCommand, CancellationToken.None);

            //Assert
            act.Should().ThrowAsync<RecordNotFoundException>();
            _planQueryRepositoryMock.Verify(x => x.GetByIdAsync(deletePlanCommand.Id), Times.Once);
            _planCommandRepositoryMock.Verify(x => x.RemovePlanWithGoals(deletePlanCommand.Id), Times.Never);
        }
    }
}
