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
                ASPUserDataContent.Visible = false;
                //Code when initial loading 
            }
            else
            {
                // code when post back 
            }


        }



        #region Frames

        public enum Frames
        {
            RegisterSuscripcion,
            SearchUser,
            RegisterNewUser,
            UserModify,
        }


        public static Frames ActualFrame;




        public void FrameUserFoundSearch(Suscriptor User)
        {
            ASPModificarButton.Visible = true;
            ASPUserDataContent.Visible = true;
            ActualFrame = Frames.SearchUser;
            SuscriptorSelecionado = User;
            CleanFrames();
            ASPMainUserLabel.Text = "Datos del Usuario";
            ReadOnlyFrame(true);
            DisplayUser(User);



        }


        public void RegisterSearch()
        {
            ActualFrame = Frames.RegisterSuscripcion;
            var IDDocument = ASPNumeroDeDocumento.Text;
            var TipoDocumento = ASPTipoDeDocumento.Text;

            var Suscriptores = InstanciaDB.GetAll<Suscriptor>();
            var MatchSub = Suscriptores.Where(x => x.TipoDocumento == TipoDocumento && x.NumeroDocumento == IDDocument).SingleOrDefault();


            if (MatchSub == null)
            {
                ASPUserDataContent.Visible = true;
                CleanFrames();
                ASPMainUserLabel.Text = "El suscriptor no existe , registre un nuevo Suscriptor";
                ReadOnlyFrame(false);
                return;
            }
            else
            {

                var Suscripciones = InstanciaDB.GetAll<Suscripcion>();

                var Suscripcion = Suscripciones.Where(x => x.IdSuscriptor == MatchSub.IdSuscriptor).SingleOrDefault();

                if (Suscripcion == null)
                {
                    ASPUserDataContent.Visible = true;


                    CleanFrames();
                    ASPMainUserLabel.Text = "Datos del Usuario";
                    ReadOnlyFrame(true);
                    DisplayUser(MatchSub);
                    ASPModificarButton.Visible = true;
                    DataSuscriptionPANEL.Visible = true;
                    ASPFechaActual.Text = DateTime.Now.Date.ToString();
                    ASPFechaFin.Text = DateTime.Now.AddMonths(1).Date.ToString();
                    SuscriptorSelecionado = MatchSub;
                }
                else
                {
                    Alert("Este Usuario ya tiene una suscripcion");
                    CloseFrames();
                }



            }
        }



        public void FrameDarDeAlta()
        {

            var IDDocument = ASPNumeroDeDocumento.Text;
            var TipoDocumento = ASPTipoDeDocumento.Text;

            var Suscriptores = InstanciaDB.GetAll<Suscriptor>();
            var MatchSub = Suscriptores.Where(x => x.TipoDocumento == TipoDocumento && x.NumeroDocumento == IDDocument).SingleOrDefault();

            if (MatchSub == null)
            {
                ASPModificarButton.Visible = false;
                ASPUserDataContent.Visible = true;
                ActualFrame = Frames.RegisterNewUser;
                CleanFrames();
                ASPMainUserLabel.Text = "Registre un nuevo Suscriptor";
                ReadOnlyFrame(false);
            }
            else
            {
                Alert("Ya existe este suscriptor");
                CleanFrames();
            }


    
        }













        public void ModificarUsuario()
        {
            ASPUserDataContent.Visible = true;
            ActualFrame = Frames.UserModify;
          
            ASPMainUserLabel.Text = "Modifique los datos de interes";
            ReadOnlyFrame(false);
        }






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



        protected void ModificarButton_Click(object sender, EventArgs e)
        {


            ModificarUsuario();


        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            FrameDarDeAlta();
        }



        protected void SearchButton_Click(object sender, EventArgs e)
        {
            RegisterSearch();
        }



        public void CloseFrames()
        {
            CleanFrames();
            ASPUserDataContent.Visible = false;

            DataSuscriptionPANEL.Visible = false;

            ASPUserDataContent.Visible = false;

            ASPModificarButton.Visible = false;


        }


        protected void SearchButton2_Click(object sender, EventArgs e)
        {
            var IDDocument = ASPNumeroDeDocumento.Text;
            var TipoDocumento = ASPTipoDeDocumento.Text;

            var Suscriptores = InstanciaDB.GetAll<Suscriptor>();
            var MatchSub = Suscriptores.Where(x => x.TipoDocumento == TipoDocumento && x.NumeroDocumento == IDDocument).SingleOrDefault();


            if (MatchSub != null)
            {
                FrameUserFoundSearch(MatchSub);
            }
            else
            {
                Alert("No existe el suscriptor");
                CloseFrames();
            }



        }


        protected void AcceptarButton_Click(object sender, EventArgs e)
        {

            switch (ActualFrame)
            {
                case Frames.RegisterNewUser:

                    bool Inserted = RegisterNewSuscriptor();


                    break;
                case Frames.RegisterSuscripcion:

                    Suscripcion Sc = new Suscripcion();


                    Sc.FechaAlta = ASPFechaActual.Text;
                    Sc.FechaFin = ASPFechaFin.Text;

                    Sc.IdAsociacion = Guid.NewGuid().ToString();

                    Sc.IdSuscriptor = SuscriptorSelecionado.IdSuscriptor;
                    Sc.Motivo = "";

                    InstanciaDB.Insert<Suscripcion>(Sc);
                    break;


                case Frames.SearchUser:




                    break;
                case Frames.UserModify:

             
           
                    SuscriptorSelecionado.Apellido = ASPApellido.Text;
                    SuscriptorSelecionado.Nombre = ASPNombre.Text;
                    SuscriptorSelecionado.Email = ASPEmail.Text;
                    SuscriptorSelecionado.Direccion = ASPDireccion.Text;
                    SuscriptorSelecionado.Telefono = ASPTelefono.Text;
                    SuscriptorSelecionado.NombreUsuario = ASPUsuario.Text;
                    SuscriptorSelecionado.Password = ASPContraseña.Text;

                    InstanciaDB.Update(SuscriptorSelecionado);



                    break;

                default:
                    break;
            }



            CloseFrames();
        }





        #endregion

        protected void CancelarButton_Click(object sender, EventArgs e)
        {
       
            CloseFrames();
        }
    }
}