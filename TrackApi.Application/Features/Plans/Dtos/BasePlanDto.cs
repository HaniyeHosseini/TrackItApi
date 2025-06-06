using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using TrackItApi.Common;
using TrackItApi.Domain.Enums;

namespace TrackApi.Application.Features.Plans.Dtos;
public class BasePlanDto
{
    public PlanType PlanType { get; set; }
    [JsonConverter(typeof(PersianDateJsonConverter))]
    public DateTime StartDate { get; set; }
    [JsonConverter(typeof(PersianDateJsonConverter))]
    public DateTime EndDate { get; set; }
    public long? ParentPlanId { get; set; }
    public string? Description { get; set; }
}
