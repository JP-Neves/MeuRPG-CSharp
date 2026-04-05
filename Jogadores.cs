namespace MeuRPG
{

    public class Jogador
    {
        public string Nome { get; set; } 
        public int Vida { get; set; } 
        public int Ataque { get; set; }
        public int Defesa { get; set; }
        public string Classe { get; set; }

        public Dado DadoJogador { get; set; } = new Dado(20);
    
        public Jogador (string heroiNome, string classeHeroi)
        {
            // Atributos base para o jogador, podem ser ajustados posteriormente
            Nome = heroiNome;
            Classe = classeHeroi;

            // Atributos base para o jogador, podem ser ajustados posteriormente
            Vida = 500;
            Ataque = 100;
            Defesa = 100;
       
        }

    }

}
