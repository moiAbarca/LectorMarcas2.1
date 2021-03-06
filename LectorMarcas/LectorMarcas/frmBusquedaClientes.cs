﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

using LectorMarcas.DBClass;
using LectorMarcas.PRGClass;

namespace LectorMarcas
{
    public partial class frmBusquedaClientes : Form
    {
        public frmBusquedaClientes()
        {
            InitializeComponent();
        }

        public int RutAux;
        public string DvSeleccionado;

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            AsignaDatos();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            List<Enrolados> oCli = new List<Enrolados>();
            clsEnrolados cli = new clsEnrolados();

            lstClientes.View = View.Details;
            lstClientes.Items.Clear();

            foreach( Enrolados o in cli.Get(txtCliente.Text) )
            {
                // Cargar el ListView
                ListViewItem item = new ListViewItem( o.IdEnroll.ToString() );

                String Nombre = String.Format("{0} {1} {2}", o.Nombre);
 
                item.SubItems.Add(Nombre);
                lstClientes.Items.Add(item);
            }
        }

        private void lstClientes_DoubleClick(object sender, EventArgs e)
        {
            AsignaDatos();
        }

        private void AsignaDatos()
        {
            String Rut;

            if (tabControl1.SelectedTab == tabPage1) // Nombre o RazonSocial
            {
                if (lstClientes.SelectedItems.Count == 1)
                {
                    Rut = lstClientes.SelectedItems[0].Text;
                    RutAux = Convert.ToInt32(Rut.Substring(0, Rut.IndexOf("-")));
                    DvSeleccionado = Rut.Substring(Rut.IndexOf("-") + 1);
                    this.DialogResult = DialogResult.OK;
                }
            }

            /* Se eliminó el tab2    
            else if (tabControl1.SelectedTab == tabPage2) // Direccion
            {
                if (lstDirClientes.SelectedItems.Count == 1)
                {
                    Rut = lstDirClientes.SelectedItems[0].Text;
                    RutAux = Convert.ToInt32(Rut.Substring(0, Rut.IndexOf("-")));
                    DvSeleccionado = Rut.Substring(Rut.IndexOf("-") + 1);
                    this.DialogResult = DialogResult.OK;
                }
            }
            */

        }
            

        private void frmBusquedaClientes_Load(object sender, EventArgs e)
        {
            List<Enrolados> oCli = new List<Enrolados>();
            clsEnrolados cli = new clsEnrolados();

            lstClientes.View = View.Details;
            lstClientes.Items.Clear();

            /* Se eliminó el tab2 que contenía esta información
            lstDirClientes.View = View.Details;
            lstDirClientes.Items.Clear();
             */

            foreach (Enrolados o in cli.Get(0))
            {
                // Cargar el ListView
                ListViewItem item = new ListViewItem(o.IdEnroll.ToString() + "-" + o.Dv);
                String Nombre = String.Format("{0} {1} ", o.Rut, o.Nombre);
                
                /*
                if (o.Personalidadjuridica == "S")
                {
                    Nombre = o.Razonsocial;
                }
                item.SubItems.Add(Nombre);
                 */

                lstClientes.Items.Add( item );
                //lstDirClientes.Items.Add( (ListViewItem)item.Clone() );
                
            }
            tabControl1.SelectTab("tabPage1");
            tabControl1.SelectedIndex = 0;
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            List<Enrolados> oCli = new List<Enrolados>();
            clsEnrolados cli = new clsEnrolados();

            //lstDirClientes.View = View.Details;
            //lstDirClientes.Items.Clear();

            /*Las columnas de búsqueda sólo incluye rut y nombre
            foreach (Clientes o in cli.GetDir(txtDireccion.Text))
            {
                // Cargar el ListView
                ListViewItem item = new ListViewItem(o.Idcliente.ToString() + "-" + o.Dv);
                String Nombre = String.Format("{0} {1} {2}", o.Nombres, o.Apellidopaterno, o.Apellidomaterno);
                if (o.Personalidadjuridica == "S")
                {
                    Nombre = o.Razonsocial;
                }
                item.SubItems.Add(Nombre);
                lstDirClientes.Items.Add(item);
            }
             */
        }

        private void frmBusquedaClientes_Activated(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Nombre")
                txtCliente.Focus();
            //else
              //  txtDireccion.Focus();
        }

    }
}
