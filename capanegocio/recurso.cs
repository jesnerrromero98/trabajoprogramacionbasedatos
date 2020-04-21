using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaentidades;
using capadato;

namespace capanegocio
{
    public class logisticanegociorecursos 
    {
        accesodatosrecursos rec = new accesodatosrecursos();
        public int insertarrecursos(recursos re)
        {
            return rec.insertarrecursos(re);
        }
        public List<recursos> listarrecursos()
        {
            return rec.Listarrecursos();
        }
        public int eliminarrecursos(int idrecursos)
        {
            return rec.eliminarrecursos(idrecursos);
        }
        public int editarrecursos(recursos re)
        {
            return rec.editarrecursos(re);
        }
        public List<recursos> buscarrecursos(string dato)
        {
            return rec.buscarrecursos(dato);
        }
    }
}
