using WorkflowEngineApi.Models;

namespace WorkflowEngineApi.Services;

public interface IWorkflowEngine
{
    WorkflowDefinition CreateDefinition(WorkflowDefinition definition);
    WorkflowDefinition GetDefinition(string id);
    WorkflowInstance StartInstance(string definitionId);
    WorkflowInstance GetInstance(string id);
    WorkflowInstance ExecuteAction(string instanceId, string actionId);
}
