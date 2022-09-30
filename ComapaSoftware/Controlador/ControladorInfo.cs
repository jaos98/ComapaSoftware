using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComapaSoftware.Controlador
{
    internal class ControladorInfo
    {
        private string idPlanta;
        private string numMedidor;
        private int numServicio;
        private string tipoPlantas;
        private string estatus;
        private string descFunciones;
        private string colonia;
        private string sector;
        private string latitud;
        private string longitud;
        private string elevacion;
        private string servicio;

     

        public string IdPlanta
        {
            get { return idPlanta; }
            set { idPlanta = value; }
        }
        public string NumMedidor
        {
            get { return numMedidor; }
            set { numMedidor = value; }
        }
        public int NumServicio
        {
            get { return numServicio; }
            set { numServicio = value; }
        }
        public string TipoPlantas
        {
            get { return tipoPlantas; }
            set { tipoPlantas = value; }
        }
        public string Estatus
        {
            get { return estatus; }
            set { estatus = value; }
        }
        public string DescFunciones
        {
            get { return descFunciones; }
            set { descFunciones = value; }
        }
        public string Colonia
        {
            get { return colonia; }
            set { colonia = value; }
        }
        public string Sector
        {
            get { return sector; }
            set { sector = value; }
        }
        public string Latitud
        {
            get { return latitud; }
            set { latitud = value; }
        }
        public string Longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }
        public string Elevacion
        {
            get { return elevacion; }
            set { elevacion = value; }
        }
        public string Servicio
        {
            get { return servicio; }
            set { servicio = value; }
        }



    }
}
