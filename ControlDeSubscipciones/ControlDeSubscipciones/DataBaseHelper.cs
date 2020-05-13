using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControlDeSubscipciones
{
    [Table("dbo.Suscriptor")]
    public class Suscriptor
    {
        [ExplicitKey]
        public string IdSuscriptor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }



    }



    [Table("dbo.Suscripcion")]
    public class Suscripcion
    {
        [ExplicitKey]
        public string IdAsociacion { get; set; }
        public string IdSuscriptor { get; set; }
        public string FechaAlta { get; set; }
        public string FechaFin { get; set; }
        public string Motivo { get; set; }

    }



    public class DbInstance
    {


        private SqlConnection database;

        public DbInstance()
        {
            var connetionString = "Server=localhost;Database=SubscipcionesDB;Trusted_Connection=True;";
            database = new SqlConnection(connetionString);
            database.Open();

        }




        public bool Insert<T>(T Object) where T : class
        {
            if (database.Insert<T>(Object) > 0)
            {
                return true;
            }
            else
            {
                return true;
            }
        }


        public List<T> GetAll<T>() where T : class
        {

            var objects = database.GetAll<T>();


            foreach (var item in objects)
            {

                var Properties = typeof(T).GetProperties().Where(x => x.PropertyType == typeof(String)).ToList();
                foreach (var Prop in Properties)
                {
                    try
                    {
                        String Value = ((String)Prop.GetValue(item));
                        if(Value == null)
                        {
                            continue;
                        }

                        int Position = ((String)Prop.GetValue(item)).IndexOf(" ");
                        var NewValue = Value.Substring(0, Position);


                        Prop.SetValue(item, NewValue);

                    }
                    catch
                    {

                    }

             
                }

            }

            return objects.ToList(); ;
        }



        public bool Update<T>(T Object) where T : class
        {
            return (database.Update<T>(Object));

        }



    }





}