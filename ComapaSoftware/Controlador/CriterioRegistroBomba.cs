using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComapaSoftware.Controlador
{

    internal class CriterioRegistroBomba
    {

        private string idPlantas;
        private string slug;
        private string servicio;
        public string IdPlantas
        {
            get { return idPlantas; }
            set { idPlantas = value; }
        }
        public string Slug
        {
            get { return slug; }
            set { slug = value; }
        }
        public string Servicio
        {
            get { return servicio; }
            set { servicio = value; }
        }
        public CriterioRegistroBomba(string idPlantas, string slug, string servicio)
        {
            this.idPlantas = idPlantas;
            this.slug = slug;
            this.servicio = servicio;
            //Console.WriteLine(idPlantas + slug + servicio + "hasta aqui recibe la info");
        }
        public CriterioRegistroBomba()
        {
            
        }

    }
    
}
   
