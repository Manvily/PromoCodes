using PromoCodes.EntityFramework;
using PromoCodes.Models;

namespace PromoCodes.Repositories;

public class PromoCodeChangeHistoryRepository : IPromoCodeChangeHistoryRepository
{
    private readonly SqlLiteContext _context;

    public PromoCodeChangeHistoryRepository(SqlLiteContext context)
    {
        _context = context;
    }
    
    public async Task CreateAsync(PromoCodeChangeHistory change)
    {
        await _context.PromoCodeChangeHistory.AddAsync(change);
    }
}