using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PromoCodes.EntityFramework;
using PromoCodes.Models;

namespace PromoCodes.Repositories;

public class PromoCodeRepository : IPromoCodeRepository
{
    private readonly SqlLiteContext _context;

    public PromoCodeRepository(SqlLiteContext context)
    {
        _context = context;
    }

    public async Task<PromoCode?> GetByIdAsync(Guid id)
    {
        return await _context.PromoCodes.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<PromoCode?> GetByCodeValueAsync(string code)
    {
        return await _context.PromoCodes.FirstOrDefaultAsync(c => c.Code == code);
    }

    public async Task<PromoCode?> GetValidatedByCodeValueAsync(string code)
    {
        return await _context.PromoCodes
            .Where(c => c.Code == code)
            .Where(x => x.IsActive)
            .Where(x => x.AvailableViewCount - x.CurrentViewCount > 0)
            .FirstOrDefaultAsync();
    }

    public async Task CreateAsync(PromoCode promoCode)
    {
        // TODO validate
        await _context.PromoCodes.AddAsync(promoCode);
    }

    public async Task DeleteAsync(Guid id)
    {
        var codeToRemove = await _context.PromoCodes.FirstOrDefaultAsync(code => code.Id == id);
        if (codeToRemove != null)
        {
            _context.PromoCodes.Remove(codeToRemove);
        }
    }
    
}