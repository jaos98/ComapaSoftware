namespace ComapaSoftware.Controlador
{
    internal class ControladorBombas
    {
        private string idPlantas;
        private string idBombas;
        private string idEstacion;
        private int posicion;
        private string marca;
        private string modelo;
        private string tipo;
        private string hp;
        private string voltaje;
        private string diametro;
        private string lps;
        private string carga;
        private string rpm;
        private string estatus;
        private string fpm;
        private string observaciones;
        public ControladorBombas()
        {

        }
        public ControladorBombas(string idEstacion,int posicion, string marca
            , string modelo, string tipo, string hp, string voltaje, string diametro,
            string lps, string carga, string rpm,string estatus, string fpm,string observaciones)
        {
            this.idEstacion = idEstacion;
            this.posicion = posicion;
            this.marca = marca;
            this.modelo = modelo;
            this.tipo = tipo;
            this.hp = hp;
            this.voltaje = voltaje;
            this.diametro = diametro;
            this.lps = lps;
            this.carga = carga;
            this.rpm = rpm;
            this.estatus = estatus;
            this.fpm = fpm;
            this.observaciones = observaciones;
        }
        public string IdBombas
        {
            get { return idBombas; }
            set { idBombas = value; }
        }
        public string IdEstacion
        {
            get { return idEstacion; }
            set { idEstacion = value; }
        }
        public int Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }
        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public string Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        public string Voltaje
        {
            get { return voltaje; }
            set { voltaje = value; }
        }
        public string Diametro
        {
            get { return diametro; }
            set { diametro = value; }
        }
        public string Lps
        {
            get { return lps; }
            set { lps = value; }
        }
        public string Carga
        {
            get { return carga; }
            set { carga = value; }
        }
        public string Rpm
        {
            get { return rpm; }
            set { rpm = value; }
        }
        public string Estatus
        {
            get { return estatus; }
            set { estatus = value; }
        }
        public string Fpm
        {
            get { return fpm; }
            set { fpm = value; }
        }
        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }
    }
}
