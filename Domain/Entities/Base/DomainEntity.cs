﻿namespace Domain.Entities.Base;

public class DomainEntity
{
    public DateTime CreatedOn { get; set; }
    //public DateTime CreatedUser { get; set; }
    public DateTime LastModifiedOn { get; set; }
    //public DateTime LastModifiedUser { get; set; }
    public int State { get; set; } = 1;
}
