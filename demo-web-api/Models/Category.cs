using System;
using System.Collections.Generic;

namespace demo_web_api.Models;

public partial class Category
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Restaurant> Restaurant { get; set; } = new List<Restaurant>();
}
