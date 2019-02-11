namespace CodingChallenge.Data.Dtos
{
    public class Forma 
    {
        private string _Nombre;
        private decimal _LongitudLado;
        private decimal _Area;
        private decimal _Perimetro;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public decimal LongitudLado
        {
            get { return _LongitudLado; }
            set { _LongitudLado = value; }
        }

        public decimal Area
        {
            get { return _Area; }
            set { _Area = value; }
        }
        public decimal Perimetro
        {
            get { return _Perimetro; }
            set { _Perimetro = value; }
        }
    }
}
