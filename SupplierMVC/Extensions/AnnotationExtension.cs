using System.ComponentModel.DataAnnotations;

namespace BikeShop.Extensions
{
    public class YearRange : RangeAttribute
    {
        public YearRange(int StartYear) : base(StartYear, DateTime.Today.Year)
        {

        }
    }
}
