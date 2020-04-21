using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaentidades;
using capadato;

namespace capanegocio
{
    public class logicanegociocomentarios
    {
        accesodatoscomentarios ac = new accesodatoscomentarios();
        public int insertarcomentarios(comentarios co)
        {
            return ac.insertarcomentarios(co);
        }
        public List<comentarios> listarcomentarios()
        {
            return ac.listarcomentarios();
        }
        public int eliminarcomentario (int idcoment)
        {
            return ac.eliminarcomentarios(idcoment);
        }
        public int editarcomentario (comentarios co)
        {
            return ac.editarcomentarios(co);
        }
        public List<comentarios> buscarcomentarios (string dato)
        {
            return ac.buscarcomentarios(dato);
        }
   
    }
}
