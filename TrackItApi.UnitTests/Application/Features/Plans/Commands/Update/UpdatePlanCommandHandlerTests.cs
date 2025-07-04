using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Contracts.Commands;
using TrackApi.Application.Contracts.Queries;
using TrackApi.Application.Exceptions;
using TrackApi.Application.Features.Plans.Commands.Update;
using TrackApi.Application.Features.Plans.Services;
using TrackItApi.Domain.Models;

namespace TrackItApi.UnitTests.Application.Features.Plans.Commands.Update
{
    public class UpdatePlanCommandHandlerTests
    {
        private readonly Mock<IPlanQueryRepository> _planQueryRepositoryMock;
        private readonly Mock<IPlanCommandRepository> _planCommandRepositoryMock;
        private readonly Mock<IPlanValidationService> _planValidationServiceMock;
        private readonly UpdatePlanCommandHandler _handler;
        public UpdatePlanCommandHandlerTests()
        {
            _planQueryRepositoryMock = new Mock<IPlanQueryRepository>();
            _planCommandRepositoryMock = new Mock<IPlanCommandRepository>();
            _planValidationServiceMock = new Mock<IPlanValidationService>();
            _handler = new UpdatePlanCommandHandler(_planQueryRepositoryMock.Object, _planCommandRepositoryMock.Object, _planValidationServiceMock.Object);
        }
        [Fact]
        public async Task Handle_ShouldReturnOutputPlanDto_WhenPlanIsValid()
        {
            //Arrange
            var startDate = DateTime.UtcNow;
            var endDate = DateTime.UtcNow.AddDays(1);
            var inputUpdatePlan = new UpdatePlanCommand(new TrackApi.Application.Features.Plans.Dtos.InputUpdatePlanDto()
            {
                Id = 1,
                StartDate = startDate,
                EndDate = endDate,
                PlanType = Domain.Enums.PlanType.Daily,
                Description = "TestPlan",
                ParentPlanId = null
            });

            var existedPlan = new Plan(Domain.Enums.PlanType.Weekly, startDate, endDate.AddDays(7), null, "OldDescription");
            _planQueryRepositoryMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(existedPlan);
            _planValidationServiceMock.Setup(x => x.IsPlanDuplicate(It.IsAny<UpdatePlanCommand>())).ReturnsAsync(false);
            _planCommandRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<Plan>())).Returns(Task.CompletedTask);


            //Act
            var result = await _handler.Handle(inputUpdatePlan, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.StartDate.Should().Be(startDate);
            result.EndDate.Should().Be(endDate);
            result.PlanType.Should().Be(inputUpdatePlan.InputUpdatePlanDto.PlanType);
            result.Description.Should().Be(inputUpdatePlan.InputUpdatePlanDto.Description);
            result.ParentPlanId.Should().Be(inputUpdatePlan.InputUpdatePlanDto.ParentPlanId);
        }
        [Fact]
        public async Task Handle_ShouldThrowDuplicateException_WhenPlanIsDuplicate()
        {
            //Arrange
            var startDate = DateTime.UtcNow;
            var endDate = DateTime.UtcNow.AddDays(1);
            var inputUpdatePlan = new UpdatePlanCommand(new TrackApi.Application.Features.Plans.Dtos.InputUpdatePlanDto()
            {
                Id = 1,
                StartDate = startDate,
                EndDate = endDate,
                PlanType = Domain.Enums.PlanType.Daily,
                Description = "TestPlan",
                ParentPlanId = null
            });
            var existedPlan = new Plan(Domain.Enums.PlanType.Weekly, startDate, endDate.AddDays(7), null, "OldDescription");
            _planQueryRepositoryMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(existedPlan);
            _planValidationServiceMock.Setup(x => x.IsPlanDuplicate(It.IsAny<UpdatePlanCommand>())).ReturnsAsync(true);

            //Act
            Func<Task> act = async () => await _handler.Handle(inputUpdatePlan, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<DuplicateException>();
            _planValidationServiceMock.Verify(x => x.IsPlanDuplicate(inputUpdatePlan), Times.Once());
            _planCommandRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Plan>()), Times.Never);
        }
        [Fact]
        public async Task Handle_ShouldThrowNotFoundException_WhenPlanIsNotFound()
        {
            //Arrange
            var startDate = DateTime.UtcNow;
            var endDate = DateTime.UtcNow.AddDays(1);
            var inputUpdatePlan = new UpdatePlanCommand(new TrackApi.Application.Features.Plans.Dtos.InputUpdatePlanDto()
            {
                Id = 1,
                StartDate = startDate,
                EndDate = endDate,
                PlanType = Domain.Enums.PlanType.Daily,
                Description = "TestPlan",
                ParentPlanId = null
            });
            _planQueryRepositoryMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync((Plan?)null);

            //Act
            Func<Task> act = async () => await _handler.Handle(inputUpdatePlan, CancellationToken.None);

            //Assert
           await act.Should().ThrowAsync<RecordNotFoundException>();
            _planQueryRepositoryMock.Verify(x => x.GetByIdAsync(inputUpdatePlan.InputUpdatePlanDto.Id),Times.Once);
            _planValidationServiceMock.Verify(x=> x.IsPlanDuplicate(inputUpdatePlan),Times.Never);
            _planCommandRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Plan>()), Times.Never);
        }
    }
}
