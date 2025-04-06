using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItApi.Common
{
    public static class ValidatorMessage
    {
        public const string InternalInvalidData = "مقدار وارد شده معتبر نیست";
        public const string Required = "این فیلد نباید خالی باشد.";
        public const string InvalidPlanType = "نوع پلن وارد شده معتبر نیست.";
        public const string InvalidDate = "تاریخ وارد شده معتبر نیست.";
        public const string MaxLengthExceeded = "تعداد کاراکترهای وارد شده بیش از حد مجاز است.";
        public const string MinLengthNotMet = "تعداد کاراکترهای وارد شده کمتر از حد مجاز است.";
        public const string InvalidEmailFormat = "فرمت ایمیل وارد شده معتبر نیست.";
        public const string InvalidPhoneNumber = "شماره تلفن وارد شده معتبر نیست.";
        public const string DuplicateEntry = "این مقدار قبلاً ثبت شده است.";
        public const string UnauthorizedAccess = "شما مجوز دسترسی به این بخش را ندارید.";
        public const string OperationFailed = "عملیات انجام نشد. لطفاً مجدداً تلاش کنید.";
    }
}
