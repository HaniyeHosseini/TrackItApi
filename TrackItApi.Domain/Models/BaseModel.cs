﻿namespace TrackItApi.Domain.Models
{
    public class BaseModel
    {
        public long ID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }

        public BaseModel()
        {
            CreationDate = DateTime.Now;
        }
    }
}
