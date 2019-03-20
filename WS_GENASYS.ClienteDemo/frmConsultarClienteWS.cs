using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WS_GENASYS.ClienteDemo
{
    public partial class frmConsultarClienteWS : Form
    {
        List<int> numbers = new List<int>();

        public frmConsultarClienteWS()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar();
                consultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de Error");
            }

        }

        private int getRandomValue(int MaxValue)
        {
            Random r = new Random();
            int newint = 0;
            newint = r.Next(MaxValue);
            while (numbers.Contains(newint))
            {
                newint = r.Next(MaxValue);
            }
            return newint;
        }

        private void consultar()
        {
            DateTime dt1;
            DateTime dt2;
            DateTime fec_nac;

            dt1 = DateTime.Now;
            textBox4.Text = DateTime.Now.ToString();
            textBox5.Text = "";
            textBox6.Text = "";

            /*Datos del Cliente*/
            DatosPersonalesServiceProxy.BasicHttpBinding_IDatosPersonalesService proxy = new WS_GENASYS.ClienteDemo.DatosPersonalesServiceProxy.BasicHttpBinding_IDatosPersonalesService();
            proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            DatosPersonalesServiceProxy.DatosPersonalesRequest request = new WS_GENASYS.ClienteDemo.DatosPersonalesServiceProxy.DatosPersonalesRequest();

            /*Datos del Cliente*/
            DatosPersonalesServiceProxy.BasicHttpBinding_IDatosMediodePagoService proxyMP = new WS_GENASYS.ClienteDemo.DatosPersonalesServiceProxy.BasicHttpBinding_IDatosMediodePagoService();
            proxyMP.Credentials = System.Net.CredentialCache.DefaultCredentials;
            //DatosPersonalesServiceProxy.DatosPersonalesRequest requestMP = new WS_GENASYS.ClienteDemo.DatosPersonalesServiceProxy.DatosPersonalesRequest();

            /*CApturando Nro Operacion*/
            int newint = getRandomValue(99999999);
            numbers.Add(newint);            
            string NroOperacion = newint.ToString();

            string valNumero = string.Format("{0, " + 12 + "}", txtNum.Text);
            request.IDC = string.Concat(valNumero, txtTip.Text, "   ");
            request.NroOperacion = NroOperacion;
            request.CodFuncionario = "000000";
            
      


            DatosPersonalesServiceProxy.DatosPersonalesResponse response = proxy.ConsultarDatos(request);

            DatosPersonalesServiceProxy.DatosMedioPagoResponse responseMP = proxyMP.ConsultarMedioPago(request);
            
            if (response.Cliente != null && response.Cliente.apellido_paterno != null)
            {

                fec_nac = DateTime.Parse(response.Cliente.fecha_nacimiento.ToString());
                txtNomCli.Text = response.Cliente.apellido_paterno;
                txtApePat.Text = response.Cliente.apellido_materno;
                txtApeMat.Text = response.Cliente.nombres;
                txtFecNto.Text = fec_nac.ToString("dd/MM/yyyy");
                txtNacCli.Text = response.Cliente.nacionalidad;
                txtGenCli.Text = response.Cliente.genero;
                txtEstCiv.Text = response.Cliente.estado_civil;
                txtProfesion.Text = response.Cliente.profesion;
            }

            dataGridView1.DataSource = response.Direcciones;
            dataGridView2.DataSource = response.Errores;

            dataGridView3.DataSource = responseMP.MediodePagoData;

            dt2 = DateTime.Now;
            textBox5.Text = dt2.ToString();
            TimeSpan ts = dt2 - dt1;
            textBox6.Text = ts.TotalSeconds.ToString();
        }
        private void limpiar()
        {
            txtNomCli.Text = "";
            txtApePat.Text = "";
            txtApeMat.Text = "";

            txtFecNto.Text = "";
            txtNacCli.Text = "";
            txtGenCli.Text = "";
            txtEstCiv.Text = "";
            txtProfesion.Text = "";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTip_TextChanged(object sender, EventArgs e)
        {

        }
    }
}