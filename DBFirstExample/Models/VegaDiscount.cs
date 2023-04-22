using System;
using System.Collections.Generic;

namespace DBFirstExample.Models;

public partial class VegaDiscount
{
    public int Id { get; set; }

    public decimal VegaPrice { get; set; }

    public int? VegaObjectId { get; set; }

    public int? VegaBrand { get; set; }

    public int? VegaDiscountSize { get; set; }

    public virtual VegaBrand? VegaBrandNavigation { get; set; }

    public virtual VegaCategory? VegaObject { get; set; }
}
