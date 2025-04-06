using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItApi.Common
{
    public static class ExceptionMessages
    {
        public static string InternalServerError = "مشکلی در سمت سرور پیش آمده ، لطفا بعدا اقدام فرمایید.";
        public static string DuplicateRecordMessage = ".رکورد وارد شده تکراری می باشد";
        public static string RecordNotFoundMessage = ".رکوردی با این اطلاعات یافت نشد";
    }
}
