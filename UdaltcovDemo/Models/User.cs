using System;
using System.Collections.Generic;

namespace UdaltcovDemo.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Patronical { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role Role { get; set; } = null!;

    public string RoleName => RoleId == 1 ? "Администратор" : RoleId == 2 ? "Менеджер" : RoleId == 3 ? "Клиент" : null;
}
