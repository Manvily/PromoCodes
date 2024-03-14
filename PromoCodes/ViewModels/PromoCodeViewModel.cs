namespace PromoCodes.ViewModels;

public class PromoCodeViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public int ViewCountLeft { get; set; }
    public bool IsActive { get; set; }
}