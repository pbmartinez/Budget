using Application.Dtos;
using Application.IAppServices;
using Microsoft.AspNetCore.Components;

namespace WebApi.Controllers
{
    [Route("api/expense")]
    public class ExpenseController : ApiBaseController<ExpenseDto, Guid>
    {
        public ExpenseController(IExpenseAppService appService) : base(appService)
        {
        }
    }
}
