﻿using OnlaynBazar.Domain.Commons;

namespace OnlaynBazar.Domain.Entities.Users;

public class Permission : Auditable
{
    public string Action { get; set; }
    public string Controller { get; set; }
}
