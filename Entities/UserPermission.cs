﻿using System;
using System.Collections.Generic;

namespace Entities;

public partial class UserPermission
{
    public int UserPermissionId { get; set; }

    public int UserId { get; set; }

    public int PermissionId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Permission Permission { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
