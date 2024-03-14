using PromoCodes.Models;

namespace PromoCodes.Repositories;

public interface IPromoCodeChangeHistoryRepository
{
    Task CreateAsync(PromoCodeChangeHistory change);
}