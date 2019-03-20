using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WS_GENASYS.ClienteDemo
{
    public partial class frmConsultaClienteAUT : Form
    {
        List<int> numbers = new List<int>();
        int cont = 0;
     
        public frmConsultaClienteAUT()
        {
            InitializeComponent();
        
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
            

                SqlConnection cn = new SqlConnection("Database=SABS_OPTATIVOS;Server=10.80.196.213,1438;Integrated Security=false;uid=usr_sabs;pwd=S@f3P@$$w0rd");
                SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 2000 TDOC.TX_COD_EQUIV,LTRIM(RTRIM(TIT.TX_NUM_DOC)) FROM CPE INNER JOIN TIT ON CPE.CO_TIT = TIT.CO_TIT INNER JOIN TDOC ON TDOC.TI_DOC = TIT.TI_DOC ", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                string tipDoc = "";
                string NroDoc = "";

                lblhraInicio.Text = DateTime.Now.ToString();

                foreach (DataRow dtRow in dt.Rows)
                {
                    tipDoc = dtRow[0].ToString();
                    NroDoc = "22222222";
                    consultar(tipDoc, NroDoc);
                }
                lblHraFin.Text = DateTime.Now.ToString();
                

                MessageBox.Show("Ejecución Completada!");
              
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


        private void consultar(string tiDoc, string nroDoc)
        {
           
            

            /*Datos del Cliente*/
            DatosPersonalesServiceProxy.BasicHttpBinding_IDatosPersonalesService proxy = new WS_GENASYS.ClienteDemo.DatosPersonalesServiceProxy.BasicHttpBinding_IDatosPersonalesService();
            proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            DatosPersonalesServiceProxy.DatosPersonalesRequest request = new WS_GENASYS.ClienteDemo.DatosPersonalesServiceProxy.DatosPersonalesRequest();

            /*Capturando Nro Operacion*/
            int newint = getRandomValue(99999999);
            numbers.Add(newint);
            string NroOperacion = newint.ToString();

            
            /*Consultando cliente*/
            string valNumero = string.Format("{0, " + 12 + "}", nroDoc.ToString());
            request.IDC = string.Concat(valNumero, tiDoc.ToString(), "   ");
            request.NroOperacion = NroOperacion;
            request.CodFuncionario = "000000";
            
            /*Obteniendo datos del cliente WS*/
            DatosPersonalesServiceProxy.DatosPersonalesResponse response = proxy.ConsultarDatos(request);


            if (response.Cliente != null && response.Cliente.apellido_paterno != null)
            {
                
                this.lbxLista.Items.Add(response.Cliente.apellido_paterno + " " + response.Cliente.apellido_materno + " " + response.Cliente.nombres);
                cont += 1;
                
            }

            lblcantidad.Text = cont.ToString();
            
        }
    }
}
