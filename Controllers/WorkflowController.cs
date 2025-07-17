using Microsoft.AspNetCore.Mvc;
using WorkflowEngineApi.Models;
using WorkflowEngineApi.Services;

namespace WorkflowEngineApi.Controllers;

[ApiController]
public class WorkflowController : ControllerBase
{
    private readonly IWorkflowEngine _engine;

    public WorkflowController(IWorkflowEngine engine)
    {
        _engine = engine;
    }

    [HttpPost("/workflows")]
    public IActionResult CreateDefinition([FromBody] WorkflowDefinition def)
    {
        try
        {
            var created = _engine.CreateDefinition(def);
            return Created($"/workflows/{created.Id}", created);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("/workflows/{id}")]
    public IActionResult GetDefinition(string id)
    {
        try
        {
            var def = _engine.GetDefinition(id);
            return Ok(def);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("/workflows/{definitionId}/instances")]
    public IActionResult StartInstance(string definitionId)
    {
        try
        {
            var inst = _engine.StartInstance(definitionId);
            return Created($"/instances/{inst.Id}", inst);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("/instances/{id}")]
    public IActionResult GetInstance(string id)
    {
        try
        {
            var inst = _engine.GetInstance(id);
            return Ok(inst);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("/instances/{instanceId}/actions/{actionId}")]
    public IActionResult ExecuteAction(string instanceId, string actionId)
    {
        try
        {
            var inst = _engine.ExecuteAction(instanceId, actionId);
            return Ok(inst);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
