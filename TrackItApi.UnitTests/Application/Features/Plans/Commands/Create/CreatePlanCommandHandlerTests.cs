using Moq;
using TrackApi.Application.Contracts.Commands;
using TrackApi.Application.Features.Plans.Commands.Create;
using TrackApi.Application.Features.Plans.Services;
using TrackApi.Application.Features.Plans.Dtos;
using TrackItApi.Domain.Models;
using FluentAssertions;
using TrackApi.Application.Exceptions;
namespace TrackItApi.UnitTests.Application.Features.Plans.Commands.Create
{
    public class CreatePlanCommandHandlerTests
    {
        private readonly Mock<IPlanCommandRepository> _planCommandRepositoryMock;
        private readonly Mock<IPlanValidationService> _planValidationServiceMock;
        private readonly CreatePlanCommandHandler _handler;

        public CreatePlanCommandHandlerTests()
        {
            _planCommandRepositoryMock = new Mock<IPlanCommandRepository>();
            _planValidationServiceMock = new Mock<IPlanValidationService>();
            _handler = new CreatePlanCommandHandler(_planCommandRepositoryMock.Object, _planValidationServiceMock.Object);
        }
        [Fact]
        public async Task Handle_ShouldReturnOutputPlanDto_WhenPlanIsValid()
        {
            //Arrange
            var startDate = DateTime.UtcNow;
            var endDate= DateTime.UtcNow.AddDays(1);
            var command = new CreatePlanCommand(new InputCreationPlanDto
            {
                PlanType = Domain.Enums.PlanType.Daily,
                StartDate = startDate,    
                EndDate = endDate,
                Description ="TestPlan" ,
                ParentPlanId=null
            });
            _planValidationServiceMock.Setup(x=> x.IsPlanDuplicate(command)).ReturnsAsync(false);
            _planCommandRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Plan>())).Returns(Task.CompletedTask);

            //Act
            var result =await _handler.Handle(command,CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.PlanType.Should().Be(command.InputCreationPlanDto.PlanType);
            result.StartDate.Should().Be(startDate);
            result.EndDate.Should().Be(endDate);
            result.Description.Should().Be(command.InputCreationPlanDto.Description);

            _planValidationServiceMock.Verify(x=> x.IsPlanDuplicate(command), Times.Once());
            _planCommandRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Plan>()), Times.Once());
        }

        [Fact]
        public async Task Handle_ShouldThrowDuplicateException_WhenPlanIsDuplicate()
        {
            //Arrange
            var startDate = DateTime.UtcNow;
            var endDate = DateTime.UtcNow.AddDays(1);
            var command = new CreatePlanCommand(new InputCreationPlanDto
            {
                PlanType = Domain.Enums.PlanType.Daily,
                StartDate = startDate,
                EndDate = endDate,
                Description = "TestPlan",
                ParentPlanId = null
            });
            _planValidationServiceMock.Setup(x => x.IsPlanDuplicate(command)).ReturnsAsync(true);
            //Act
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<DuplicateException>();

            _planValidationServiceMock.Verify(x => x.IsPlanDuplicate(command), Times.Once());
            _planCommandRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Plan>()), Times.Never);
        }
    }
}
