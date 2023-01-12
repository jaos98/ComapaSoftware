using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComapaSoftware.Controlador
{
    internal class ModeloInfo
    {
        private string idPlantas,idEstacion,nombre,capEquipos, operacionMinima, equiposInstalados, tipo, garantOperacion
           , gastoPromedio, gastoInstalado, servicio, observaciones;



        public string IdPlantas
        {
            get{ return idPlantas; }
            set { idPlantas = value; }
        }
        public string IdEstacion
        {
            get{ return idEstacion; }
            set { idEstacion = value; }
        }
        public string Nombre
        {
            get{ return nombre; }
            set { nombre = value; }
        }
        public string CapEquipos
        {
            get{ return capEquipos; }
            set { capEquipos = value; }
        }
        public string OperacionMinima
        {
            get { return operacionMinima; }
            set { operacionMinima = value; }
        }
        public string EquiposInstalados
        {
            get { return equiposInstalados; }
            set { equiposInstalados = value;}
        }
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public string GarantOperacion
        {
            get { return garantOperacion;}
            set { garantOperacion = value; }
        }
        public string GastoPromedio
        {
            get { return gastoPromedio;}
            set { gastoPromedio = value; }
        }
        public string GastoInstalado
        {
            get { return gastoInstalado;}
            set { gastoInstalado = value; }
        }
        public string Servicio
        {
            get { return servicio;}
            set { servicio = value; }
        }
        public string Observaciones
        {
            get { return observaciones;}
            set { observaciones = value; }
        }

        public ModeloInfo(string idPlantas, string idEstacion, string nombre,
            string capEquipos, string operacionMinima, string equiposInstalados,
            string tipo, string garantOperacion, string gastoPromedio,
            string gastoInstalado, string servicio, string observaciones)
        {
            this.idPlantas = idPlantas;
            this.idEstacion = idEstacion;
            this.nombre = nombre;
            this.capEquipos = capEquipos;
            this.operacionMinima = operacionMinima;
            this.equiposInstalados = equiposInstalados;
            this.tipo = tipo;
            this.garantOperacion = garantOperacion;
            this.gastoPromedio = gastoPromedio;
            this.gastoInstalado = gastoInstalado;
            this.servicio = servicio;
            this.observaciones = observaciones;
        }
        public ModeloInfo()
        {

        }
    }
}
