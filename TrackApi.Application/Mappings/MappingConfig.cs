using Mapster;
using TrackApi.Application.DTOs.Goal;
using TrackApi.Application.DTOs.Plan;
using TrackApi.Application.Goals.Contracts;
using TrackApi.Infrastructure.Repositories.Goals;
using TrackItApi.Common;
using TrackItApi.Domain.Models;
namespace TrackApi.Application.Mappings;

public class MappingConfig
{

    public static void RegisterMappings()
    {
        TypeAdapterConfig<Plan, OutputPlanDto>.NewConfig();
        TypeAdapterConfig<Plan, InputCreationPlanDto>.NewConfig();
        TypeAdapterConfig<Plan, InputUpdatePlanDto>.NewConfig();

        TypeAdapterConfig<Goal, OutputGoalDto>.NewConfig();
        TypeAdapterConfig<Goal, InputCreationGoalDto>.NewConfig();
        TypeAdapterConfig<Goal, InputUpdateGoalDto>.NewConfig();

    }
}
