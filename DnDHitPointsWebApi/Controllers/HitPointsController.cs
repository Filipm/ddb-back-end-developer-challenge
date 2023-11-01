using DnDHitPointsServices.Dtos;
using DnDHitPointsServices;
using Microsoft.AspNetCore.Mvc;
using DnDHitPointsWebApi.Requests;
using DnDHitPointsWebApi.Authorization;
using DnDHitPointsServices.Entities;

namespace DnDHitPointsWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class HitPointsController : ControllerBase
    {
        private readonly ILogger<HitPointsController> _logger;
        private readonly IHitPointsService _hitPointsService;

        public HitPointsController(ILogger<HitPointsController> logger, IHitPointsService hitPointsService)
        {
            _logger = logger;
            _hitPointsService = hitPointsService;
        }

        [HttpPost(Name = "PostHeal")]
        public HitPoints Heal(HealRequest request)
        {
            _logger.LogDebug("Request Heal");

            return _hitPointsService.Heal(request.name, request.amount);
        }


        [HttpPost(Name = "PostDealDemage")]
        public HitPoints DealDamage(DealDamageRequest request)
        {
            _logger.LogDebug("Request DealDamage");
            
            DamageTypes damageType;
            if (!Enum.TryParse<DamageTypes>(request.damageType, out damageType))
            {
                throw new InvalidDamageTypeException($"{request.damageType} is invalid damage Type");
            }

            return _hitPointsService.DealDamage(request.name,
                request.amount,
                Enum.Parse<DamageTypes>(request.damageType));
        }

        [HttpPost(Name = "PostAddTemporaryHitPoints")]
        public HitPoints AddTemporaryHitPoints(AddTemporaryHitPointsRequest request)
        {
            _logger.LogDebug("Request AddTemporaryHitPoints");

            return _hitPointsService.AddTemporaryHitPoints(request.name, request.amount);
        }
    }
}
