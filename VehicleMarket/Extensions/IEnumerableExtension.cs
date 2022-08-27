using Microsoft.AspNetCore.Mvc.Rendering;

namespace VehicleMarket.Extensions
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> Items)
        {
            List<SelectListItem> List = new List<SelectListItem>();
            SelectListItem SelectListItem = new SelectListItem
            {
                Text = "------ Select ------",
                Value = ""
            };
            List.Add(SelectListItem);
            foreach (var Item in Items ?? Enumerable.Empty<T>())
            {
                SelectListItem = new SelectListItem
                {
                    Text = Item.GetPropertyValue("Name"),
                    Value = Item.GetPropertyValue("Id"),
                };
                List.Add(SelectListItem);
            }
            return List;
        }
    }
}
