using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComapaSoftware.Controlador
{
    internal class ControladorInfo
    {
        private string idPlantas,capEquipos, operacionMinima, equiposInstalados, tipo, garantOperacion
           , gastoPromedio, gastoInstalado, servicio, observaciones;



        public string IdPlantas
        {
            get{ return idPlantas; }
            set { idPlantas = value; }
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


    }
}
