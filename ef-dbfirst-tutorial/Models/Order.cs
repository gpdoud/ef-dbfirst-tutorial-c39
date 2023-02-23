using System;
using System.Collections.Generic;

namespace ef_dbfirst_tutorial.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public DateTime Date { get; set; }

    public string? Description { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderLine> OrderLines { get; } = new List<OrderLine>(); 

    public override string ToString() {
        var message = $"ORDER: Id:{Id}, CustId:{CustomerId}, Date:{Date}, Desc:{Description}, " +
            $"Customer Name:{Customer.Name}";
        foreach(var ol in OrderLines) {
            message  += $"\nORDERLINE: Id:{ol.Id} | Product:{ol.Product} | Price:{ol.Price} | Quantity:{ol.Quantity}";
        }
        return message;
    }
}
