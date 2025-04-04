using DependencyInjectionDemonstration.Core.Services;
using DependencyInjectionDemonstration.Core.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionDemonstration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuidController : ControllerBase
    {

        private readonly ILogger<GuidController> _logger;

        public GuidController(ILogger<GuidController> logger)
        {
            _logger = logger;
        }

        [HttpGet("FromScoped")]        
        public IActionResult FromScoped(
            [FromServices] IGuidServiceScoped guidService,
            [FromServices] IUseCaseDemoSoped useCaseDemoSoped)
        {
            List<string> result = [
                $"Service:        {guidService.GetGuid()}",
                $"UseCase Scoped: {useCaseDemoSoped.GetGuid()}"
                ];

            return Ok(result);
        }

        [HttpGet("FromTransient")]
        public IActionResult FromTransient(
            [FromServices] IGuidServiceTransient guidService,
            [FromServices] IUseCaseDemoTransient useCaseDemoTransient)
        {
            List<string> result = [
                $"Service:        {guidService.GetGuid()}",
                $"UseCase Scoped: {useCaseDemoTransient.GetGuid()}"
                ];

            return Ok(result);
        }
    }
}
