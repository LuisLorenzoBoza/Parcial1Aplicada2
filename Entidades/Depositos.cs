using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Depositos
    {
        [Key]
        public int DepositosId { get; set; }
        public int CuentaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; }
        public int Cartas { get; set; }
        public virtual CuentasDeCartas Carta { get; set; }

        public Depositos(int depositosId, int emisorId,DateTime fecha,  string concepto, int cartas)
        {
            DepositosId = depositosId;
            CuentaId = emisorId;
            Fecha = fecha;
            Concepto = concepto;
            Cartas = cartas;
        }

        public Depositos()
        {
            DepositosId = 0;
            CuentaId = 0;
            Fecha = DateTime.Now;
            Concepto = String.Empty;
            Cartas = 0;
        }
    }
}
