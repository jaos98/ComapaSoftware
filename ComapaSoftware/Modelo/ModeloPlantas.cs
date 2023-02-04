namespace ComapaSoftware.Controlador
{
    internal class ModeloPlantas
    {
        private string idPlanta;
        private string numMedidor;
        private string numServicio;
        private string tipoPlantas;
        private string estatus;
        private string descFunciones;
        private string subestacionKva;
        private string colonia;
        private string sector;
        private string latitud;
        private string longitud;
        private string elevacion;
        private string servicio;
        private string domicilio;


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
        public string NumServicio
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
        public string SubestacionKva
        {
            get { return subestacionKva; }
            set { subestacionKva = value; }
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
        public string Domicilio
        {
            get { return domicilio; }
            set { domicilio = value; }
        }

        public ModeloPlantas(string IdPlanta)
        {
            idPlanta = IdPlanta;
        }
        public ModeloPlantas(string idPlanta, string numMedidor, string numServicio,
            string tipoPlantas, string estatus, string descFunciones, string subestacionKva, string colonia, string sector,
            string latitud, string longitud, string elevacion, string servicio, string domicilio)
        {
            this.idPlanta = idPlanta;
            this.numMedidor = numMedidor;
            this.numServicio = numServicio;
            this.tipoPlantas = tipoPlantas;
            this.estatus = estatus;
            this.descFunciones = descFunciones;
            this.subestacionKva = subestacionKva;
            this.colonia = colonia;
            this.sector = sector;
            this.latitud = latitud;
            this.longitud = longitud;
            this.elevacion = elevacion;
            this.servicio = servicio;
            this.domicilio = domicilio;

        }
        public ModeloPlantas()
        {

        }
    }
}
