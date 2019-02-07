using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RepositorioDepositos : RepositorioBase<Depositos>
    {
        public override bool Eliminar(int id)
        {
            var deposito = Buscar(id);
            CuentasDeCartas carta = deposito.Carta;

            carta.Balance -= deposito.Cartas;

            _contexto.Entry(carta).State = EntityState.Modified;
            _contexto.SaveChanges();

            return base.Eliminar(id);
        }

        public override bool Guardar(Depositos entity)
        {
            var cuenta = _contexto.Cuenta.Find(entity.CuentaId);
            cuenta.Balance += entity.Cartas;
            _contexto.Entry(cuenta).State = System.Data.Entity.EntityState.Modified;
            _contexto.SaveChanges();

            return base.Guardar(entity);
        }

        public override bool Modificar(Depositos entity)
        {
            var depositoAnterior = _contexto.Deposito.Include(x => x.CuentaId)
                            .Where(z => z.DepositosId == entity.DepositosId)
                            .AsNoTracking()
                            .FirstOrDefault();

            CuentasDeCartas cartas = depositoAnterior.Carta;
            cartas.Balance -= depositoAnterior.Cartas;

            cartas.Balance += entity.Cartas;
            _contexto.Entry(cartas).State = EntityState.Modified;
            _contexto.SaveChanges();

            return base.Modificar(entity);
        }

        public RepositorioDepositos() : base()
        {

        }

        public override Depositos Buscar(int id)
        {
            var d = _contexto.Deposito.Include(x => x.Carta)
                    .Where(z => z.DepositosId == id)
                    .FirstOrDefault();
            return d;
        }
    }
}
