using PromoCodes.Models;
using PromoCodes.Requests;
using PromoCodes.ViewModels;

namespace PromoCodes.Services;

public interface IPromoCodeService
{
    Task<PromoCodeViewModel> GetValidatedByCodeValueAsync(string code);
    Task<PromoCodeViewModel> CreateAsync(PromoCodeCreateRequest request);
    Task PartialUpdateAsync(Guid id, PromoCodePartialUpdateRequest request);
    Task DeleteAsync(Guid id);
}