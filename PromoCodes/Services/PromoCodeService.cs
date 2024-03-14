using AutoMapper;
using PromoCodes.Exceptions;
using PromoCodes.Models;
using PromoCodes.Requests;
using PromoCodes.UnitOfWork;
using PromoCodes.ViewModels;

namespace PromoCodes.Services;

public class PromoCodeService : IPromoCodeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PromoCodeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PromoCodeViewModel> GetValidatedByCodeValueAsync(string code)
    {
        var result = await _unitOfWork.PromoCodes.GetValidatedByCodeValueAsync(code);

        if (result == null)
        {
            throw new NotFoundException();
        }

        // each code download increase CurrentViewCount
        result.CurrentViewCount++;
        await _unitOfWork.Commit();

        return _mapper.Map<PromoCodeViewModel>(result);
    }

    public async Task<PromoCodeViewModel> CreateAsync(PromoCodeCreateRequest request)
    {
        if (await _unitOfWork.PromoCodes.GetByCodeValueAsync(request.Code) != null)
        {
            throw new AlreadyExistsException();
        }

        await _unitOfWork.PromoCodes.CreateAsync(
            new PromoCode()
            {
                Name = request.Name,
                Code = request.Code,
                AvailableViewCount = request.ViewCountLeft,
                CurrentViewCount = 0,
                IsActive = request.IsActive,
            });
        await _unitOfWork.Commit();
        var code = await _unitOfWork.PromoCodes.GetByCodeValueAsync(request.Code);

        return _mapper.Map<PromoCodeViewModel>(code);
    }

    public async Task PartialUpdateAsync(Guid id, PromoCodePartialUpdateRequest request)
    {
        var code = await _unitOfWork.PromoCodes.GetByIdAsync(id);

        if (code == null)
        {
            throw new NotFoundException();
        }

        if (!string.IsNullOrEmpty(request.Name) && request.Name != code.Name)
        {
            await _unitOfWork.PromoCodeChanges.CreateAsync(new PromoCodeChangeHistory()
            {
                Date = new DateTime(),
                Column = nameof(code.Name),
                PreviousValue = code.Name,
                NewValue = request.Name,
                PromoCode = code
            });
            code.Name = request.Name;
        }

        if (request.IsActive != null && request.IsActive != code.IsActive)
        {
            await _unitOfWork.PromoCodeChanges.CreateAsync(new PromoCodeChangeHistory()
            {
                Date = new DateTime(),
                Column = nameof(code.IsActive),
                PreviousValue = code.IsActive.ToString(),
                NewValue = request.IsActive.ToString(),
                PromoCode = code
            });
            code.IsActive = (bool) request.IsActive!;
        }

        await _unitOfWork.Commit();
    }

    public async Task DeleteAsync(Guid id)
    {
        var promoCode = await _unitOfWork.PromoCodes.GetByIdAsync(id);
        if (promoCode == null)
        {
            throw new NotFoundException();
        }

        await _unitOfWork.PromoCodes.DeleteAsync(promoCode.Id);
        await _unitOfWork.Commit();
    }
}