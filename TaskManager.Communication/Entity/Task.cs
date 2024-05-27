using TaskManager.Communication.Enums;

namespace TaskManager.Communication.Entity;

public class Task : DataStoreDefaultProps
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public EPriorityTask Priority { get; set; }
    public DateTime LimiteDateTime { get; set; }
    public EStatusTask Status { get; set; }
}
