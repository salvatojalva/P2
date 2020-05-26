using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace P2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public enum MessageType { Success, Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDepartamento();
                loadCarreras();
                loadJornadas();
            }
            
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        public void loadDepartamento() {
            string q = "select * from departamento";
            SqlDataAdapter departamentos = new SqlDataAdapter(q, Connection.str);

            DataTable dt = new DataTable();
            departamentos.Fill(dt);
            Departamento.DataSource = dt;
            Departamento.DataBind();
            Departamento.DataTextField = "nombre_departamento";
            Departamento.DataValueField = "id_departamento";
            Departamento.DataBind();
        }

        public void loadJornadas()
        {
            string q = "select * from jornada";
            SqlDataAdapter jornadas = new SqlDataAdapter(q, Connection.str);

            DataTable dt = new DataTable();
            jornadas.Fill(dt);
            Jornada.DataSource = dt;
            Jornada.DataBind();
            Jornada.DataTextField = "nombre_jornada";
            Jornada.DataValueField = "id_jornada";
            Jornada.DataBind();
        }

        public void loadCarreras()
        {
            string q = "select * from getCarreras()";
            SqlDataAdapter carreras = new SqlDataAdapter(q, Connection.str);

            DataTable dt = new DataTable();
            carreras.Fill(dt);
            Carrera.DataSource = dt;
            Carrera.DataBind();
            Carrera.DataTextField = "nombre_carrera";
            Carrera.DataValueField = "id_carrera";
            Carrera.DataBind();
        }


        protected void Departamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string q = "select * from municipio where municipio.id_departamento = " + Departamento.SelectedItem.Value.ToString();
            SqlDataAdapter municipios = new SqlDataAdapter(q, Connection.str);
            
            DataTable dt = new DataTable();
            municipios.Fill(dt);
            Municipio.DataSource = dt;
            Municipio.DataBind();
            Municipio.DataTextField = "nombre_municipio";
            Municipio.DataValueField = "id_municipio";
            Municipio.DataBind();
        }

        protected void SaveInscripcion(object sender, EventArgs e)
        {
            using (SqlConnection q = new SqlConnection(Connection.str))
            {

                
                using (SqlCommand cmd = new SqlCommand("saveInscripcion", q))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@pnombre", SqlDbType.VarChar).Value = nombre_1.Text;
                        cmd.Parameters.Add("@snombre", SqlDbType.VarChar).Value = nombre_2.Text;
                        cmd.Parameters.Add("@papellido", SqlDbType.VarChar).Value = apellido_1.Text;
                        cmd.Parameters.Add("@sapellido", SqlDbType.VarChar).Value = apellido_2.Text;
                        cmd.Parameters.Add("@fecha_nacimiento", SqlDbType.VarChar).Value = Convert.ToDateTime(fecha_nacimiento.Text).ToString("yyyy-MM-dd");
                        cmd.Parameters.Add("@sexo", SqlDbType.VarChar).Value = Sexo.SelectedItem.Value.ToString();
                        cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = direccion.Text;
                        cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = telefono.Text;
                        cmd.Parameters.Add("@municipio", SqlDbType.VarChar).Value = Municipio.SelectedValue.ToString();
                        cmd.Parameters.Add("@jornada", SqlDbType.VarChar).Value = Jornada.SelectedValue.ToString();
                        cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = Carrera.SelectedValue.ToString();
                        cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = Password.Text;
                    

                        q.Open();
                    
                        cmd.ExecuteNonQuery();
                        nombre_1.Text = "";
                        nombre_2.Text = "";
                        apellido_1.Text = "";
                        apellido_2.Text = "";
                        fecha_nacimiento.Text = "";
                        direccion.Text = "";
                        telefono.Text = "";
                        Password.Text = "";
                        
                        loadDepartamento();
                        loadCarreras();
                        loadJornadas();

                        Sexo.SelectedIndex = -1;
                        Municipio.SelectedIndex = -1;
                        Jornada.SelectedIndex = -1;
                        Carrera.SelectedIndex = -1;


                        ShowMessage("Se ha generado la inscripcion de "+nombre_1.Text+' '+apellido_1.Text, MessageType.Success);
                    }
                    catch (Exception ex)
                    {
                        ShowMessage("Asegurese de llenar el formulario, todos los campos son requeridos", MessageType.Error);
                    }
                }
                

                
            }

            
        }

    }
}