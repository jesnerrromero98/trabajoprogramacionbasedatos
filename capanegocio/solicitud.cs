using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaentidades;
using capadato;

namespace capanegocio
{
    public class logicanegociosolicitud
    {
        accesodatosolicitud sol = new accesodatosolicitud();
        public int insertarsolicitud(solicitud so)
        {
            return sol.insertarsolicitud(so);
        }
        public List<solicitud> listarsolicitud()
        {
            return sol.Listarsolicitud();
        }
        public int eliminarsolicitud(int idsolicitud)
        {
            return sol.eliminarsolicitud(idsolicitud);
        }
        public int editarsolicitud(solicitud so)
        {
            return sol.editarsolicitud(so);
        }
        public List<solicitud> buscarsolicitud(string dato)
        {
            return sol.buscarsolicitud(dato);
        }
    }
}
