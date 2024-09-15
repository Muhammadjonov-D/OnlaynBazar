using OnlaynBazar.Domain.Entities.Orders;

namespace OnlaynBazar.WebApi.Models.WareHouses;

public class WareHouseUpdateModel
{
    public long OrderId { get; set; }
    public DateTime Date { get; set; }
}
