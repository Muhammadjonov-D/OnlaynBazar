using OnlaynBazar.Domain.Commons;
using OnlaynBazar.Domain.Entities.Orders;

namespace OnlaynBazar.Domain.Entities.WareHouses;

public class WareHouse : Auditable
{
    public long OrderId { get; set; }
    public Order Order { get; set; }    
    public DateTime Date { get; set; }
}
