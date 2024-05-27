namespace TaskManager.Communication.Responses;

public class ResponseGetTaskJson : Entity.Task
{

}

public class ResponseGetAllTaskJson
{
    public List<Entity.Task>? Tasks { get; set; }
}