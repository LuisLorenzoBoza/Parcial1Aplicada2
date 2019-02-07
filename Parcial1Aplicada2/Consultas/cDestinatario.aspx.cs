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
    public partial class cDestinatario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        Expression<Func<Destinatario, bool>> filtro = x => true;

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Destinatario> rep = new RepositorioBase<Destinatario>();
            int dato = 0;
            switch (DropDownListFiltro.SelectedIndex)
            {
                case 0://Todo
                    filtro = x => true;
                    break;

                case 1://DestinatarioID
                    dato = int.Parse(TextBoxBuscar.Text);
                    filtro = (x => x.DestinatarioID == dato);
                    break;

                case 2://Fecha
                    filtro = (x => x.Fecha.Equals(TextBoxBuscar.Text));
                    break;

                case 3://Nombre
                    filtro = (x => x.Nombre.Contains(TextBoxBuscar.Text));
                    break;

                case 4://Cantidad de Cartas
                    int cantidad = int.Parse(TextBoxBuscar.Text);
                    filtro = (x => x.CantidadCartas == cantidad);
                    break;
            }
            DestinatarioGridView.DataSource = rep.GetList(filtro);
            DestinatarioGridView.DataBind();
        }

        protected void DestinatarioGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            RepositorioBase<Destinatario> rb = new RepositorioBase<Destinatario>();
            DestinatarioGridView.DataSource = rb.GetList(filtro);
            //DestinatarioGridView.PageIndex = e.NewPageIndex;
            DestinatarioGridView.DataBind();
        }
    }
}