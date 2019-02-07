using BL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial1Aplicada2.Consultas
{
    public partial class cCuentasDeCartas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        Expression<Func<CuentasDeCartas, bool>> filtro = x => true;

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<CuentasDeCartas> rep = new RepositorioBase<CuentasDeCartas>();
            int dato = 0;
            switch (DropDownListFiltro.SelectedIndex)
            {
                case 0://Todo
                    filtro = x => true;
                    break;

                case 1://CuentaId
                    dato = int.Parse(TextBoxBuscar.Text);
                    filtro = (x => x.CartaId == dato);
                    break;

                case 2://Fecha
                    filtro = (x => x.Fecha.Equals(TextBoxBuscar.Text));
                    break;

                case 3://Nombre
                    filtro = (x => x.Nombre.Contains(TextBoxBuscar.Text));
                    break;

                case 4://Cantidad de cartas
                    int balance = int.Parse(TextBoxBuscar.Text);
                    filtro = (x => x.Balance == balance);
                    break;
            }
            CuentaGridView.DataSource = rep.GetList(filtro);
            CuentaGridView.DataBind();
        }

        protected void CuentaGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            RepositorioBase<CuentasDeCartas> rb = new RepositorioBase<CuentasDeCartas>();
            CuentaGridView.DataSource = rb.GetList(filtro);
            CuentaGridView.PageIndex = e.NewPageIndex;
            CuentaGridView.DataBind();
        }

        protected void CuentaGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}