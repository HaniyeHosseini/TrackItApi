using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Plans.Contracts;
using TrackApi.Application.Plans.Dtos;
using TrackApi.Infrastructure.Repositories.Plans;

namespace TrackApi.Application.Plans.Implements
{
    public class PlanValidationService : IPlanValidationService
    {
        private readonly IPlanRepository _planRepository;

        public PlanValidationService(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<bool> IsPlanDuplicate(CreationPlanDto plan)
        {
            return await _planRepository.IsAnyExist(x => x.PlanType == plan.PlanType 
                                                      && x.StartDate == plan.StartDate
                                                      && x.EndDate == plan.EndDate);
        }

        public async Task<bool> IsPlanDuplicate(UpdatePlanDto plan)
        {
            return await _planRepository.IsAnyExist(x => x.PlanType == plan.PlanType 
                                                      && x.StartDate == plan.StartDate 
                                                      && x.EndDate == plan.EndDate 
                                                      && x.Id != plan.Id);
        }
    }
}
