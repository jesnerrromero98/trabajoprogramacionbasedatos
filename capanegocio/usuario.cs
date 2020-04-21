using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capadato;
using capaentidades;

namespace capanegocio
{
    public class logicanegociousuario
    {
        accesodatosusuarios usu = new accesodatosusuarios();
        public int insertarusuario(usuarios us)
        {
            return usu.insertarusuarios(us);
        }
        public List<usuarios> listarusuario()
        {
            return usu.Listarusuarios();
        }
        public int eliminarusuario(int idusuario)
        {
            return usu.eliminarusuario (idusuario);
        }
        public int editarusuario(usuarios us)
        {
            return usu.editarusuarios(us);
        }
        public List<usuarios> buscarusuario(string dato)
        {
            return usu.buscarusuarios(dato);
        }
    }
}
