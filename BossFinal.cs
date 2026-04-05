namespace MeuRPG
{
    public class BossFinal
    {
        public string Nome { get; set; }
        public int Vida { get; set; }
        public int Ataque { get; set; } 
        public int Defesa { get; set; }

        public Dado DadoBoss { get; set; } = new Dado(20);

        public BossFinal()
        {
            Nome = "Lyniac";
            Vida = 1000;
            Ataque = 150;
            Defesa = 150;
        }
    }
}