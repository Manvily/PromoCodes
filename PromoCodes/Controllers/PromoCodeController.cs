using Microsoft.AspNetCore.Mvc;
using PromoCodes.Exceptions;
using PromoCodes.Requests;
using PromoCodes.Services;
using PromoCodes.ViewModels;

namespace PromoCodes.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PromoCodeController : ControllerBase
{
    private readonly IPromoCodeService _promoCodeService;

    public PromoCodeController(IPromoCodeService promoCodeService)
    {
        _promoCodeService = promoCodeService;
    }

    [HttpGet]
    [Route("{code}")]
    public async Task<ActionResult<PromoCodeViewModel>> Get(string code)
    {
        try
        {
            return await _promoCodeService.GetValidatedByCodeValueAsync(code);
        }
        catch (NotFoundException)
        {
            return NotFound("Code not found");
        }
        catch (Exception e)
        {
            return Problem(
                detail: e.StackTrace,
                title: e.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<PromoCodeViewModel>> Create(PromoCodeCreateRequest promoCode)
    {
        try
        {
            return await _promoCodeService.CreateAsync(promoCode);
        }
        catch (AlreadyExistsException)
        {
            return Conflict("Code already exists");
        }
        catch (Exception e)
        {
            return Problem(
                detail: e.StackTrace,
                title: e.Message);
        }
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<ActionResult> PartialUpdateAsync(Guid id, PromoCodePartialUpdateRequest promoCode)
    {
        try
        {
            await _promoCodeService.PartialUpdateAsync(id, promoCode);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound("Code not found");
        }
        catch (Exception e)
        {
            return Problem(
                detail: e.StackTrace,
                title: e.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        try
        {
            await _promoCodeService.DeleteAsync(id);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound("Code not found");
        }
        catch (Exception e)
        {
            return Problem(
                detail: e.StackTrace,
                title: e.Message);
        }
    }
}