using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Goals.Dtos;
using TrackApi.Application.Plans.Dtos;
using TrackItApi.Domain.Models;
namespace TrackApi.Application.Mappings;

public class MappingConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<Plan, PlanViewDto>.NewConfig()
       .Map(dest => dest.Goals, src => src.Goals);

        TypeAdapterConfig<Goal, GoalViewDto>.NewConfig();
    }
}
