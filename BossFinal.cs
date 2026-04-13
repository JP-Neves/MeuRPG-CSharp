namespace MeuRPG
{
    public class BossFinal
    {
        public string Nome { get; set; }
        public int Vida { get; set; }
        public int Ataque { get; set; } 
        public int Defesa { get; set; }
        public int Magia { get; set; }

        public Dado DadoBoss { get; set; } = new Dado(20);

        public BossFinal()
        {
            Nome = "Lyniac";
            Vida = 1000;
            Ataque = 450;
            Defesa = 150;
            Magia = 250;
        }

        public void atacar (List<Jogador> herois)
        {

            int resultadoDadoBoss = DadoBoss.Rolar();
            // 1. Sorteia o índice de 0 até o total de heróis (ex: 0 a 2)
            int indiceAlvo = DadoBoss.RolarMaximo(herois.Count);
            Jogador alvo = null;

            do
            {
                int indiceSorteado = DadoBoss.RolarMaximo(herois.Count);
                alvo = herois[indiceSorteado];
            } while (alvo.Vida <= 0); // Continua sorteando até encontrar um alvo vivo
            
            int bonusMagia = 0;
            if(DadoBoss.RolarMaximo(2)==1)
            {
                Console.WriteLine("O boss usou magia no ataque! O dano foi aumentado!");
                bonusMagia = (int)(Magia * 0.1);
            }
            if(resultadoDadoBoss ==20)
            {
                Console.WriteLine("CRÍTICO! O dano do ataque do boss foi aumentado!");
                bonusMagia += (int)(Ataque * 0.05);
            }
            else if (resultadoDadoBoss > 1)
            {
                Console.WriteLine("GOLPE BEM SUCEDIDO! O boss causou dano aos heróis!");
            }
            else 
            {
                Console.WriteLine($"{Nome} errou o ataque! Ele não causou dano aos heróis!");
                return;
            }

            int danoCausado = (Ataque + bonusMagia + resultadoDadoBoss);
            alvo.ReceberDano(danoCausado);
                      
            if (alvo.Vida <= 0)
            {
                Console.WriteLine($"\n☠️☠️☠️☠️☠️☠️☠️☠️☠️☠️\nDerrota! {alvo.Nome} foi derrotado!\n☠️☠️☠️☠️☠️☠️☠️☠️☠️☠️\n");
            }
        }
    }
}   

