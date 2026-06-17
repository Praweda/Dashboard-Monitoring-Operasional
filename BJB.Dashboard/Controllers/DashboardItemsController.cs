using BJB.Dashboard.Library.Message.Response;
using BJB.Dashboard.Model.Entity;
using BJB.Dashboard.Service.Services.DashboardItem;
using Microsoft.AspNetCore.Mvc;

namespace BJB.Dashboard.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DashboardItemsController : ControllerBase
{
    private readonly IDashboardItemService _service;
    private readonly ILogger<DashboardItemsController> _logger;

    public DashboardItemsController(
        IDashboardItemService service,
        ILogger<DashboardItemsController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet("get")]
    public async Task<IActionResult> Get()
    {
        var result = await _service.GetAll();
        return Ok(SuccessResponse("Get all data successfully", result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetById(id);
        if (result is null)
        {
            return NotFound(FailedResponse("Data not found", StatusCodes.Status404NotFound));
        }

        return Ok(SuccessResponse("Get data successfully", result));
    }

    [HttpGet("status/{status}")]
    public async Task<IActionResult> GetByStatus(string status)
    {
        var result = await _service.RetrieveByStatus(status);
        return Ok(SuccessResponse("Get data by status successfully", result));
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] DashboardItemEntity entity)
    {
        await _service.Create(entity);
        return Ok(SuccessResponse("Create successfully", entity));
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] DashboardItemEntity entity)
    {
        var existing = await _service.GetById(entity.Id);
        if (existing is null)
        {
            return NotFound(FailedResponse("Data not found", StatusCodes.Status404NotFound));
        }

        entity.UpdatedAt = DateTime.UtcNow;
        await _service.Update(entity);

        return Ok(SuccessResponse("Update successfully", entity));
    }

    [HttpPost("delete/{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var existing = await _service.GetById(id);
        if (existing is null)
        {
            return NotFound(FailedResponse("Data not found", StatusCodes.Status404NotFound));
        }

        await _service.DeleteById(id);
        return Ok(SuccessResponse("Delete successfully", null));
    }

    private static ResponseEntity SuccessResponse(string message, object? result)
    {
        return new ResponseEntity
        {
            success = true,
            code = "00",
            message = message,
            result = result
        };
    }

    private static ResponseEntity FailedResponse(string message, int statusCode)
    {
        return new ResponseEntity
        {
            success = false,
            code = "99",
            message = message,
        };
    }
}
