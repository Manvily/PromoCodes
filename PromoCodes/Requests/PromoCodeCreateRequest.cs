namespace PromoCodes.Requests;

public class PromoCodeCreateRequest
{
    public string Name { get; set; }
    public string Code { get; set; }
    public int ViewCountLeft { get; set; }
    public bool IsActive { get; set; }
}