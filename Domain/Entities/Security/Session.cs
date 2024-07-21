using Domain.Entities.Base;

namespace Domain.Entities.Security;

public class Session: IEntityBase<Guid>
{
    public Guid Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = new ();
    public bool Active { get; set; }
}
