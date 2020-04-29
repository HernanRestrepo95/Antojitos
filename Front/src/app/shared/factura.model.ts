import { FacturaDetalle } from "./factura_detalle.model";

export class Factura {
  IdFactura: number;
  IdCliente: number;
  FechaVenta: string;
  ValorTotal: number;
  TEST_FACTURA_DETALLE: FacturaDetalle[];
}