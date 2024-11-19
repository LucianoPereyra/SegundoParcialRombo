using SegundoParcialRombo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcialRombo.Datos
{
    public class RepositorioRombos
    {

        private List<Rombo> lista;
        public RepositorioRombos()
        {
            lista = new List<Rombo>();
        }

        public void Agregar(Rombo rombo)
        {

            if (Existe(rombo)) return;

            lista.Add(rombo);
        }

        public void Eliminar(Rombo rombo)
        {
            lista.Remove(rombo);
        }

        public bool Existe(Rombo rombo)
        {
            return lista.Any(a => a.DiagonalMayor == rombo.DiagonalMayor && a.DiagonalMenor == rombo.DiagonalMenor && a.Contorno == rombo.Contorno);
        }

        public int GetCantidad()
        {
            return lista.Count;
        }

        public List<Rombo> GetLista()
        {
            return lista;
        }

        public List<Rombo> OrdernarPorLado()
        {
            return lista.OrderBy(a => a.Lado).ToList();
        }

        public List<Rombo> OrdernarPorLadoDescendente()
        {
            return lista.OrderByDescending(a => a.Lado).ToList();
        }

    }
}
