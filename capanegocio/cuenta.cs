using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaentidades;
using capadato;

namespace capanegocio
{
    public class logicanegociocuenta
    {
        accesodatocuenta cu = new accesodatocuenta();
        public int insertarcuentas(cuentas cue)
        {
            return cu.insertarcuentas(cue);
        }
        public List<cuentas> listarcuentas()
        {
            return cu.Listarcuentas();
        }
        public int eliminarcuentas(int idcuentas)
        {
            return cu.eliminarcuenta(idcuentas);
        }
        public int editarcuenta(cuentas cue)
        {
            return cu.editarcuenta(cue);
        }
        public List<cuentas> buscarcuenta(string dato)
        {
            return cu.buscarcuentas(dato);
        }
    }
}
