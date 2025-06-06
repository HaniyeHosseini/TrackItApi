using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Features.Plans.Commands;
using TrackApi.Infrastructure.Repositories.Plans.Queries;

namespace TrackApi.Application.Features.Plans.Services
{
    public interface IPlanValidationService
    {
        Task<bool> IsPlanDuplicate(CreatePlanCommand createPlanCommand);
        Task<bool> IsPlanDuplicate(UpdatePlanCommand updatePlanCommand);
    }
    public class PlanValidationService : IPlanValidationService
    {
        private readonly IPlanQueryRepository _planQueryRepository;

        public PlanValidationService(IPlanQueryRepository planQueryRepository)
        {
            _planQueryRepository = planQueryRepository;
        }

        public async Task<bool> IsPlanDuplicate(CreatePlanCommand createPlanCommand)
        {
            var inputPlan = createPlanCommand.InputCreationPlanDto;
            return await _planQueryRepository.IsAnyExist(x => x.PlanType == inputPlan.PlanType
                                                       && x.StartDate.Date == inputPlan.StartDate.Date
                                                       && x.EndDate.Date == inputPlan.EndDate.Date);
        }

        public async Task<bool> IsPlanDuplicate(UpdatePlanCommand updatePlanCommand)
        {
            var inputPlan = updatePlanCommand.InputUpdatePlanDto;
            return await _planQueryRepository.IsAnyExist(x => x.PlanType == inputPlan.PlanType
                                                       && x.StartDate.Date == inputPlan.StartDate.Date
                                                       && x.EndDate.Date == inputPlan.EndDate.Date && x.Id != inputPlan.Id);
        }
    }
}
