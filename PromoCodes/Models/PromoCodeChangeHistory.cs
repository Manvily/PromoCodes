namespace PromoCodes.Models;

public class PromoCodeChangeHistory
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Column { get; set; }
    public string PreviousValue { get; set; }
    public string NewValue { get; set; }
    public PromoCode PromoCode { get; set; }
}