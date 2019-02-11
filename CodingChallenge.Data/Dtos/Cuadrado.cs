using CodingChallenge.Data.Interfaces;
using System;

namespace CodingChallenge.Data.Dtos
{
    public class Cuadrado : Forma, IFormas
    {
        public Cuadrado(decimal longitudLado)
        {
            LongitudLado = longitudLado;
            Nombre = (GetType().Name);
        }

        public decimal GetPerimetro()
        {
            return LongitudLado * 4;
        }

        public decimal GetArea()
        {
            return (decimal)Math.Pow((double)LongitudLado, 2);
        }
    }
}
