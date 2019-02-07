using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CuentasDeCartas
    {
        [Key]
        public int CartaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public double Balance { get; set; }

        public CuentasDeCartas(int cuentaId, DateTime fecha, string nombre)
        {
            CartaId = cuentaId;
            Fecha = fecha;
            Nombre = nombre;
        }

        public CuentasDeCartas()
        {
            CartaId = 0;
            Fecha = DateTime.Now;
            Nombre = String.Empty;
            Balance = 0;
        }
    }
}
