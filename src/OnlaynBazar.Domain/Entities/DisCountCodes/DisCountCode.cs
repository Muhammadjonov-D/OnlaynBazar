using OnlaynBazar.Domain.Commons;

namespace OnlaynBazar.Domain.Entities.DisCountCodes;

public class DisCountCode : Auditable
{
    public long Code { get; set; }
    public DateTime ExpiryDate { get; set; }
    public bool IsActive { get; set; }
    public long Usagelimit { get; set; }
    public decimal MinPurchaseAmount { get; set; }
}
