using System.ComponentModel.DataAnnotations.Schema;

namespace PromoCodes.Models;

public class PromoCode : Entity
{
    public string Name { get; set; }
    public string Code { get; set; }
    public int AvailableViewCount { get; set; }
    public int CurrentViewCount { get; set; }
    public bool IsActive { get; set; }
    public List<PromoCodeChangeHistory> ChangeHistory { get; set; }
}