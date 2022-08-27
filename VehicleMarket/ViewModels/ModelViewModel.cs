using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using VehicleMarket.Models;

namespace VehicleMarket.ViewModels
{
    public class ModelViewModel
    {
        [ValidateNever]
        public Model Model { get; set; }
        [ValidateNever]
        public IEnumerable<Make> Makes { get; set; }
        //public IEnumerable<SelectListItem> MakesList(IEnumerable<Make> Items)
        //{
        //    List<SelectListItem> MakeList = new List<SelectListItem>();
        //    SelectListItem selectListItem = new SelectListItem
        //    {
        //        Text = "------ Select ------",
        //        Value = ""
        //    };
        //    MakeList.Add(selectListItem);
        //    foreach (Make make in Items ?? Enumerable.Empty<Make>())
        //    {
        //        selectListItem = new SelectListItem
        //        {
        //            Text = make.Name.ToString(),
        //            Value = make.Id.ToString()
        //        };
        //        MakeList.Add(selectListItem);
        //    }
        //    return MakeList;
        //}
    }
}
