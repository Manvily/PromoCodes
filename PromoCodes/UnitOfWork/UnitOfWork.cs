using PromoCodes.EntityFramework;
using PromoCodes.Repositories;

namespace PromoCodes.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly SqlLiteContext _context;
    public IPromoCodeRepository PromoCodes { get; }
    public IPromoCodeChangeHistoryRepository PromoCodeChanges { get; }

    public UnitOfWork(
        IPromoCodeRepository promoCodeRepository, 
        IPromoCodeChangeHistoryRepository promoCodeChangeHistoryRepository,
        SqlLiteContext context)
    {
        PromoCodes = promoCodeRepository;
        PromoCodeChanges = promoCodeChangeHistoryRepository;
        _context = context;
    }

    public async Task<bool> Commit()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task Dispose()
    {
        await _context.DisposeAsync();
    }
}