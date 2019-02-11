using CodingChallenge.Data.Interfaces;
using System;

namespace CodingChallenge.Data.Dtos
{
    public class TrianguloEquilatero : Forma, IFormas
    {
        public TrianguloEquilatero(decimal longitudLado)
        {
            LongitudLado = longitudLado;
            Nombre = (GetType().Name);
        }

        public decimal GetPerimetro()
        {
            return LongitudLado * 3;
        }

        public decimal GetArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * LongitudLado * LongitudLado;
        }

    }
}
