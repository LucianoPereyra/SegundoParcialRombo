using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcialRombo.Entidades
{
    public class Rombo
    {

        public int DiagonalMayor { get; set; }
        public int DiagonalMenor { get; set; }
        public Contorno Contorno { get; set; }
        public double Lado { get; set; }

        public Rombo() { }

        public Rombo(int diagonalMenor, int diagonalMayor, Contorno contorno)
        {
            DiagonalMayor = diagonalMayor;
            DiagonalMenor = diagonalMenor;
            Lado = ObtenerLado();
        }

        public double ObtenerLado()
        {

            return Math.Sqrt(Math.Pow(DiagonalMayor / 2, 2) + Math.Pow(DiagonalMenor / 2, 2));

        }

        public double ObtenerPerimetro()
        {

            return 4 * Lado;

        }

        public double ObtenerArea()
        {

            return (DiagonalMayor * DiagonalMenor) / 2;

        }

    }
}
