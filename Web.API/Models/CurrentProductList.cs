﻿using System;
using System.Collections.Generic;

namespace Web.API.Models;

public partial class CurrentProductList
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}
