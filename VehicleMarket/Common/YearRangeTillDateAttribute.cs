using System.ComponentModel.DataAnnotations;

namespace VehicleMarket.Common
{
    public class YearRangeTillDateAttribute : RangeAttribute
    {
        public YearRangeTillDateAttribute(int StartYear) : base(StartYear, DateTime.Now.Year)
        {
        }
    }
}
