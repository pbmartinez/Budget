using Application.Dtos;
using Application.IAppServices;
using Microsoft.AspNetCore.Components;

namespace WebApi.Controllers
{
    [Route("api/budget")]
    public class BudgetController : ApiBaseController<BudgetDto, Guid>
    {
        public BudgetController(IBudgetAppService appService) : base(appService)
        {
        }
    }
}
