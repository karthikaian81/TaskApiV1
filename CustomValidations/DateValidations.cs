using System.ComponentModel.DataAnnotations;

namespace TaskApiV1.CustomValidations
{
    public class FutureDateValidations :ValidationAttribute
    {
        public string DateCustomErrorMessage { get; set; } = string.Empty;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime objdate = DateTime.MinValue;
            DateTime.TryParse(value.ToString(),out objdate);
            if (objdate != DateTime.MinValue && objdate < DateTime.Now)
                return ValidationResult.Success;
            DateCustomErrorMessage = string.IsNullOrEmpty(DateCustomErrorMessage) ? "Date should not be future date": DateCustomErrorMessage;

            return new ValidationResult(ErrorMessage = $"Invalid Date {(objdate == DateTime.MinValue.Date? value : objdate)}  {DateCustomErrorMessage}");
        }
    }

    public class DateRangeValidations : ValidationAttribute
    {
        public string DateMaxDate = string.Empty,DateMinDate = string.Empty,DateCustomErrorMessage = string.Empty;

        public int? RangeMaxDate=null, RangeMinDate=null;

        private DateTime? Maxdate = null,Mindate = null;

        private DateTime Maxoutdate = DateTime.MinValue, Minoutdate = DateTime.MinValue;

        private string ConversionErrorMessage=string.Empty;

        public DateRangeValidations(string MinDate,string MaxDate)
        {
            if(MinDate != null && MaxDate != null)
            {
                Mindate = CustomConvertdate(MinDate);
                Maxdate = CustomConvertdate(MaxDate);
            }
        }

        public DateRangeValidations()
        {
            bool _Ismaxdte = string.IsNullOrEmpty(DateMaxDate),_Ismindte = string.IsNullOrEmpty(DateMinDate);
            
            if (_Ismaxdte || _Ismindte)
            {
                Maxdate = _Ismaxdte ? DateTime.Now : CustomConvertdate(DateMaxDate);
                Mindate = _Ismindte ? DateTime.Now : CustomConvertdate(DateMinDate);
            }
            else if(RangeMaxDate.HasValue || RangeMinDate.HasValue)
            {
                Maxdate = DateTime.Now.AddDays(RangeMaxDate.GetValueOrDefault());
                Mindate = DateTime.Now.AddDays(-(RangeMinDate.GetValueOrDefault()));
            }
        }

        DateTime? CustomConvertdate(string DateValue)
        {
            try
            {
                if (!string.IsNullOrEmpty(DateValue))
                 return   Convert.ToDateTime(DateValue);
            }
            catch (FormatException ex) 
            {
                return DateTime.MinValue;
            }
            return null;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime objdate = DateTime.MinValue;
            DateTime.TryParse(value.ToString(), out objdate);
            if (objdate != DateTime.MinValue && Mindate != DateTime.MinValue && Maxdate != DateTime.MinValue && Mindate is not null && Maxdate is not null && objdate < Maxdate && objdate >Mindate)
                return ValidationResult.Success;
            DateCustomErrorMessage = string.IsNullOrEmpty(DateCustomErrorMessage) ? $"Date should between {Mindate.GetValueOrDefault().Date } and {Maxdate.GetValueOrDefault().Date} date" : DateCustomErrorMessage;
            return new ValidationResult(ErrorMessage = $"Invalid Date {(objdate == DateTime.MinValue.Date ? value : objdate)} \n {DateCustomErrorMessage}");
        }
    }
}
