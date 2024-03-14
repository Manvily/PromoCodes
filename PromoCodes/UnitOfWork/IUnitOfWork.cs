using PromoCodes.Repositories;

namespace PromoCodes.UnitOfWork;

public interface IUnitOfWork
{
    IPromoCodeRepository PromoCodes { get; }
    IPromoCodeChangeHistoryRepository PromoCodeChanges { get; }
    Task<bool> Commit();
    Task Dispose();
}