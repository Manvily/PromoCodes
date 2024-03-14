namespace PromoCodes.Requests;

public class PromoCodePartialUpdateRequest
{
    public bool? IsActive { get; set; }
    public string? Name { get; set; }
}