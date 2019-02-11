using CodingChallenge.Data.Interfaces;
using System;

namespace CodingChallenge.Data.Dtos
{
    public class Circulo : Forma, IFormas
    {
        public Circulo(decimal longitudLado)
        {
            LongitudLado = longitudLado;
            Nombre = (GetType().Name);
        }
        public decimal GetPerimetro()
        {
            return (decimal)Math.PI * LongitudLado;
        }

        public decimal GetArea()
        {
            return (decimal)Math.PI * (LongitudLado / 2) * (LongitudLado / 2);
        }
    }
}
