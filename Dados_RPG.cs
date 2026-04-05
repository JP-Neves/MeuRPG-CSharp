namespace MeuRPG
{
    public class Dado
    {
        private Random _random;
        private int _quantidadeFaces;
        public Dado(int faces)
        {
            _random = new Random();
            
            _quantidadeFaces = faces;

        }

        public int Rolar(int bonus = 0)
        {
            return _random.Next(1, _quantidadeFaces + 1) + bonus;
        }

    }
}