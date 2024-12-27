using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItApi.Common
{
    public class OperationResult
    {
        public bool IsSucceded { get; set; }
        public string Message { get; set; } = "عملیات با خطا مواجه شد";
        public OperationResult()
        {
            IsSucceded = false;
        }
        public void Succed(string message = "عملیات با موفقیت انجام شد")
        {
            IsSucceded=true;
            Message = message;
        }
    }
}
