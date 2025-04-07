using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.DTOs.Plan;
using TrackApi.Infrastructure.Repositories.Plans;

namespace TrackApi.Application.Services.Plans
{
    public class PlanValidationService : IPlanValidationService
    {
        private readonly IPlanRepository _planRepository;

        public PlanValidationService(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<bool> IsPlanDuplicate(InputCreationPlanDto plan)
        {
            return await _planRepository.IsAnyExist(x => x.PlanType == plan.PlanType
                                                      && x.StartDate.Date == plan.StartDate.Date
                                                      && x.EndDate.Date == plan.EndDate.Date);
        }

        public async Task<bool> IsPlanDuplicate(InputUpdatePlanDto plan)
        {
            return await _planRepository.IsAnyExist(x => x.PlanType == plan.PlanType
                                                      && x.StartDate.Date == plan.StartDate.Date
                                                      && x.EndDate.Date == plan.EndDate.Date
                                                      && x.Id != plan.Id);
        }
    }
}
