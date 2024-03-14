using PromoCodes.Models;

namespace PromoCodes.Repositories;

public interface IPromoCodeRepository
{
    Task<PromoCode?> GetByIdAsync(Guid id);
    Task<PromoCode?> GetByCodeValueAsync(string code);
    Task<PromoCode?> GetValidatedByCodeValueAsync(string code);
    Task CreateAsync(PromoCode promoCode);
    Task DeleteAsync(Guid id);
}