using CodingChallenge.Data.Interfaces;

namespace CodingChallenge.Data.Dtos
{
    public class TrapecioRectangulo : Forma, IFormas
    {
        private decimal LongitudBaseMenor;
        private decimal LongitudBaseMayor;
        private decimal LongitudLadoOblicuo;

        public TrapecioRectangulo(decimal longitudLadoRecto, decimal longitudBaseMenor, decimal longitudBaseMayor, decimal longitudLadoOblicuo)
        {
            LongitudLado = longitudLadoRecto;
            Nombre = (GetType().Name);
            LongitudBaseMenor = longitudBaseMenor;
            LongitudBaseMayor = longitudBaseMayor;
            LongitudLadoOblicuo = longitudLadoOblicuo;
        }
        public decimal GetPerimetro()
        {
            return LongitudLado + LongitudBaseMenor + LongitudBaseMayor + LongitudLadoOblicuo;
        }

        public decimal GetArea()
        {
            return LongitudLado * ((LongitudBaseMayor + LongitudBaseMenor) / 2);
        }
    }
}
