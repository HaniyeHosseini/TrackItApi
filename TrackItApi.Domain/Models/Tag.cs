namespace TrackItApi.Domain.Models
{
    public class Tag : BaseModel
    {
        public string Title { get; set; }

        public Tag(string title)
        {
            Title = title;
        }
    }
}
