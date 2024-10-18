using System;
using System.Collections.Generic;

namespace ProyectoFactura.Models;

public partial class FacturaCabecera
{
    public int FacturaId { get; set; }

    public string NumeroFactura { get; set; } = null!;

    public string Ruc { get; set; } = null!;

    public string RazonSocial { get; set; } = null!;

    public DateTime FechaEmision { get; set; }

    public virtual ICollection<FacturaDetalle> FacturaDetalles { get; set; } = new List<FacturaDetalle>();
}
