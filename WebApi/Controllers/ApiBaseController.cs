using Application.Dtos;
using Application.IAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiBaseController<TEntityDto, TKey> : ControllerBase 
        where TEntityDto : DtoBase
    {
        protected readonly IAppService<TEntityDto, TKey> AppService;

        protected ApiBaseController(IAppService<TEntityDto, TKey> appService)
        {
            AppService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        [HttpGet]
        [HttpHead]
        public virtual async Task<IActionResult> Get(CancellationToken cancellationToken = default)
        {
            var items = await AppService.GetAllAsync(cancellationToken: cancellationToken);
            return Ok(items);
        }

        [HttpGet("{id}")]
        [HttpHead("{id}")]
        public virtual async Task<ActionResult<TEntityDto>> Get(TKey id, CancellationToken cancellationToken = default)
        {
            if (id == null)
                return BadRequest();
            var item = await AppService.GetAsync(id, cancellationToken: cancellationToken);

            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post(TEntityDto item, CancellationToken cancellationToken = default)
        {
            if (item.IsTransient())
                item.GenerateIdentity();
            var result = await AppService.AddAsync(item, cancellationToken);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(TKey id, TEntityDto item, CancellationToken cancellationToken = default)
        {
            if (id == null)
                return BadRequest();
            var itemTarget = await AppService.GetAsync(id, cancellationToken: cancellationToken);
            if (itemTarget == null)
                return NotFound();
            var result = await AppService.UpdateAsync(item, cancellationToken);
            return NoContent();
        }
        [HttpPatch("{id}")]
        public virtual async Task<IActionResult> Patch(TKey id, JsonPatchDocument<TEntityDto> patchDocument, CancellationToken cancellationToken = default)
        {
            if (id == null)
                return BadRequest();
            var item = await AppService.GetAsync(id, cancellationToken: cancellationToken);
            if (item == null)
                return NotFound();
            //TODO: Check client errors vs server error response
            patchDocument.ApplyTo(item);
            if (!TryValidateModel(item))
                return ValidationProblem(ModelState);
            var result = await AppService.UpdateAsync(item, cancellationToken);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(TKey id, CancellationToken cancellationToken = default)
        {
            if (id == null)
                return NotFound();
            var item = await AppService.GetAsync(id, cancellationToken: cancellationToken);
            if (item == null)
                return NotFound();
            var result = await AppService.RemoveAsync(id, cancellationToken);
            return NoContent();
        }

        public override ActionResult ValidationProblem([ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices.GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}
