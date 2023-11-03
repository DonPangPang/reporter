using Reporter.Entities.Base;

namespace Reporter.Entities;

public class Work : EntityBase
{
    public string Content { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public ICollection<Group> Groups { get; set; } = new List<Group>();
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();

    public WorkStatus Status { get; set; } = WorkStatus.Working;
}

public enum WorkStatus
{
    Working,
    Finished
}

public class Tag : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public ICollection<Work> Works { get; set; } = new List<Work>();
}

public class Group : EntityBase
{
    public string Name { get; set; } = string.Empty;

    public ICollection<Work> Works { get; set; } = new List<Work>();
}