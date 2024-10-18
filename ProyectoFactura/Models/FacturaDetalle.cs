using System;
using System.Collections.Generic;

namespace ProyectoFactura.Models;

public partial class FacturaDetalle
{
    public int DetalleId { get; set; }

    public int FacturaId { get; set; }

    public string CodigoProducto { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal PrecioUnitario { get; set; }

    public int Cantidad { get; set; }


    public virtual FacturaCabecera Factura { get; set; } = null!;
    private const decimal IGVRate = 0.18m;

    public decimal CalcularSubtotal()
    {
        return PrecioUnitario * Cantidad;
    }

    public decimal CalcularIGV()
    {
        return CalcularSubtotal() * IGVRate;
    }

    public decimal CalcularTotalConIGV()
    {
        return CalcularSubtotal() + CalcularIGV();
    }
}
