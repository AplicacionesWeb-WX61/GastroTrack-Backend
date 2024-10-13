using chefstock_platform.InventoryManagement.Domain.Model.Commands;

namespace chefstock_platform.InventoryManagement.Domain.Model.Aggregates;

public class Tasks
{
    public int TaskId { get; set; }
    
    public string? TaskName { get; set; }
    
    public string? TaskDescription { get; set; }
    
    public string? TaskDate { get; set; }
    
    public Tasks()
    {

    }
    public Tasks(int taskId, string taskName, string taskDescription, string taskDate)
    {
        TaskId = taskId;
        TaskName = taskName;
        TaskDescription = taskDescription;
        TaskDate = taskDate;
    }

    
    public Tasks(CreateTaskCommand command)
    {
        TaskName = command.TaskName;
        TaskDescription = command.TaskDescription; 
        TaskDate = command.TaskDate; 
    }

    // Método para actualizar el producto
    public void Update(UpdateTaskCommand command)
    {
        TaskId = command.TaskId;
        TaskName = command.TaskName;
        TaskDescription = command.TaskDescription; 
        TaskDate = command.TaskDate; 
    }
}