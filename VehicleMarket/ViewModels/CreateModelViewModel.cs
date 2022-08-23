using Microsoft.AspNetCore.Mvc.Rendering;
using VehicleMarket.Models;

namespace VehicleMarket.ViewModels
{
    public class CreateModelViewModel
    {
        public Model Model { get; set; }
        public IEnumerable<Make> Makes { get; set; }
        public IEnumerable<SelectListItem> MakesList(IEnumerable<Make> Items)
        {
            List<SelectListItem> MakeList = new List<SelectListItem>();
            foreach (Make make in Items)
            {
                SelectListItem selectListItem = new()
                {
                    Text = make.Name.ToString(),
                    Value = make.Id.ToString()
                };
                MakeList.Add(selectListItem);
            }
            return MakeList;
        }
    }
}
