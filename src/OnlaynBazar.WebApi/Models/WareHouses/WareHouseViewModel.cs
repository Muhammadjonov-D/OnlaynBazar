using OnlaynBazar.Domain.Entities.Orders;
using OnlaynBazar.WebApi.Models.Orders;

namespace OnlaynBazar.WebApi.Models.WareHouses;

public class WareHouseViewModel
{
    public long Id { get; set; }
    public OrderViewModel Order { get; set; }
    public DateTime Date { get; set; }
}
