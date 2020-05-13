using ControlDeSubscipciones;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlDesuscipciones
{
    public partial class _Default : Page
    {

        public static DbInstance InstanciaDB;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                InstanciaDB = new DbInstance();
                CleanFrames();
                //Code when initial loading 
            }
            else
            {
                // code when post back 
            }


        }







        #region Frames

        public void FrameDarDeAlta()
        {
            ActualFrame = Frames.UserRegister;
            CleanFrames();
            ASPMainUserLabel.Text = "Registre un nuevo Suscriptor";
            ReadOnlyFrame(false);
        }




        public void FrameRegistrar()
        {
            ActualFrame = Frames.UserRegister;
            CleanFrames();
            ASPMainUserLabel.Text = "El suscriptor no existe , registre un nuevo Suscriptor";
            ReadOnlyFrame(false);
        }

        public void FrameUserFound(Suscriptor User)
        {
            ActualFrame = Frames.SuscriptionRegister;

            CleanFrames();
            ASPMainUserLabel.Text = "Datos del Usuario";
            ReadOnlyFrame(true);
            DisplayUser(User);
            DataSuscriptionPANEL.Visible = true;
            ASPFechaActual.Text = DateTime.Now.Date.ToString();
            ASPFechaFin.Text = DateTime.Now.AddMonths(1).Date.ToString();
            SuscriptorSelecionado = User;


        }

        public enum Frames
        {
            UserRegister,
            SuscriptionRegister,
        }


        public static Frames ActualFrame;


        public void ReadOnlyFrame(bool ReadOnly)
        {
            ASPApellido.ReadOnly = ReadOnly;
            ASPNombre.ReadOnly = ReadOnly;
            ASPEmail.ReadOnly = ReadOnly;
            ASPTelefono.ReadOnly = ReadOnly;
            ASPUsuario.ReadOnly = ReadOnly;
            ASPContraseña.ReadOnly = ReadOnly;

        }




        public void CleanFrames()
        {

            ASPMainUserLabel.Text = "";
            DataSuscriptionPANEL.Visible = false;

            ASPApellido.Text = "";
            ASPNombre.Text = "";
            ASPEmail.Text = "";
            ASPTelefono.Text = "";
            ASPUsuario.Text = "";
            ASPContraseña.Text = "";
            ASPDireccion.Text = "";

        }
        public void DisplayUser(Suscriptor User)
        {


            ASPApellido.Text = User.Apellido;
            ASPNombre.Text = User.Nombre;
            ASPEmail.Text = User.Email;
            ASPTelefono.Text = User.Telefono;
            ASPUsuario.Text = User.NombreUsuario;
            ASPContraseña.Text = User.Password;
            ASPDireccion.Text = User.Direccion;


        }



        #endregion



        #region Methods


        public void Alert(String Message)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + Message + "')", true);

        }


        public void Search()
        {
            var IDDocument = ASPNumeroDeDocumento.Text;
            var TipoDocumento = ASPTipoDeDocumento.Text;



            var Suscriptores = InstanciaDB.GetAll<Suscriptor>();


            var MatchSub = Suscriptores.Where(x => x.TipoDocumento == TipoDocumento && x.NumeroDocumento == IDDocument).SingleOrDefault();


            if (MatchSub == null)
            {
                // Alert("No existe el suscriptor");
                FrameRegistrar();
                return;
            }
            else
            {

                var Suscripciones = InstanciaDB.GetAll<Suscripcion>();

                var Suscripcion = Suscripciones.Where(x => x.IdSuscriptor == MatchSub.IdSuscriptor).SingleOrDefault();

                if(Suscripcion == null)
                {
                    FrameUserFound(MatchSub);
                }
                else
                {
                    Alert("Este Usuario ya tiene una suscripcion");
                }


               
            }






            // var Suscripciones = InstanciaDB.database.GetAll<Suscripcion>();

        }


        public static Suscriptor SuscriptorSelecionado;

        public bool RegisterNewSuscriptor()
        {
            Suscriptor NewUser = new Suscriptor();

            NewUser.IdSuscriptor = Guid.NewGuid().ToString();
            NewUser.Apellido = ASPApellido.Text;
            NewUser.Nombre = ASPNombre.Text;
            NewUser.Email = ASPEmail.Text;
            NewUser.Direccion = ASPDireccion.Text;
            NewUser.Telefono = ASPTelefono.Text;
            NewUser.NombreUsuario = ASPUsuario.Text;
            NewUser.Password = ASPContraseña.Text;

            NewUser.TipoDocumento = ASPTipoDeDocumento.Text;
            NewUser.NumeroDocumento = ASPNumeroDeDocumento.Text;



            bool Inserted = InstanciaDB.Insert<Suscriptor>(NewUser);
            return Inserted;


        }





        #endregion


        #region Callbacks



        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void ModificarButton_Click(object sender, EventArgs e)
        {

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {

        }

        protected void AcceptarButton_Click(object sender, EventArgs e)
        {

            switch (ActualFrame)
            {
                case Frames.UserRegister:

                    bool Inserted = RegisterNewSuscriptor();

                    if (Inserted)
                    {
                        Alert("Insert Success");
                    }

                    break;
                case Frames.SuscriptionRegister:

                    Suscripcion Sc = new Suscripcion();


                    Sc.FechaAlta = ASPFechaActual.Text;
                    Sc.FechaFin = ASPFechaFin.Text;

                    Sc.IdAsociacion = Guid.NewGuid().ToString();

                    Sc.IdSuscriptor = SuscriptorSelecionado.IdSuscriptor;
                    Sc.Motivo = "";

                    InstanciaDB.Insert<Suscripcion>(Sc);



                    break;
                default:
                    break;
            }



            SuscriptorSelecionado = null;
            CleanFrames();

        }





        #endregion


    }
}