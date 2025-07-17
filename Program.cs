using WorkflowEngineApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IWorkflowEngine, WorkflowEngine>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
