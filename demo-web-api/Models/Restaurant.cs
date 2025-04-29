using System;
using System.Collections.Generic;

namespace demo_web_api.Models;

public partial class Restaurant
{
    public int Id { get; set; }

    public string RestaurantName { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}
