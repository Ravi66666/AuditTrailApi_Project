using Microsoft.AspNetCore.Mvc;
using AuditTrailApi.Models;
using AuditTrailApi.Services;

namespace AuditTrailApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuditController : ControllerBase
{
    private readonly AuditService _auditService;

    public AuditController(AuditService auditService)
    {
        _auditService = auditService;
    }

    //Example 1
    [HttpPost]
    [Route("compare")]
    public IActionResult Post([FromBody] AuditRequest request)
    {
        try
        {
            var result = _auditService.CompareObjectsWithDic(request.Before, request.After, request.UserId, request.EntityName, request.Action);
            if (result.ResultIsOk)
                return Ok(result);
            else
                return BadRequest(result);
        }
        catch (Exception ex)
        {
            // Log error
            return BadRequest(ex);
        }
    }

    //Example 2
    [HttpPost]
    [Route("compareclassobject")]
    public IActionResult Post([FromBody] AuditRequestByClassObject request)
    {
        try
        {
            var result = _auditService.CompareWihClassObjects(request.BeforeInfo, request.AfterInfo, request.UserId, request.EntityName, request.Action);
            if (result.ResultIsOk)
                return Ok(result);
            else
                return BadRequest(result);
        }
        catch (Exception ex)
        {
            // Log error
            return BadRequest(ex);
        }
    }
}