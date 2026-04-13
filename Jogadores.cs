namespace MeuRPG
{

    public class Jogador
    {
        public string Nome { get; set; } 
        public int Vida { get; set; } 
        public int Ataque { get; set; }
        public int Defesa { get; set; }
        public string Classe { get; set; }
        public string Raca { get; set; }
        public int Magia { get; set; }

        public Dado DadoJogador { get; set; } = new Dado(20);
    
        public Jogador (string heroiNome, string classeHeroi, string racaHeroi)
        {
            // Atributos base para o jogador, podem ser ajustados posteriormente
            Nome = heroiNome;
            Classe = classeHeroi;
            Raca = racaHeroi;

            
            switch (classeHeroi.ToLower())
            {
                case "guerreiro":
                    Vida = 700;
                    Ataque = 300;
                    Defesa = 300;
                    Magia = 50;
                    break;

                case "mago":
                    Vida = 550;
                    Ataque = 150;
                    Defesa = 150;
                    Magia = 400;
                    break;

                case "arqueiro":
                    Vida = 550;
                    Ataque = 250;
                    Defesa = 250;
                    Magia = 200;
                    break;

                default:
                Vida = 250;
                Ataque = 100;
                Defesa = 100;
                Magia = 100;
                break;
            }

            switch (racaHeroi.ToLower())
            {
                case "elfo":
                    Vida += 100;
                    Ataque += 100;
                    Defesa += 100;
                    Magia += 150;
                    break;
                
                case "anão":
                    Vida += 100;
                    Ataque += 150;
                    Defesa += 150;
                    break;
                
                case "humano":
                    break;

            }
        }

        public void atacar(BossFinal boss)
        {
            Console.WriteLine("Você quer colocar magia no seu golpe? (s/n)");
            string respostaMagia = Console.ReadLine() ?? "n";

            int resultadoDadoJogador = DadoJogador.Rolar();
            int bonusMagia = 0;
            if(respostaMagia.ToLower() == "s")
            {
                if(DadoJogador.RolarMaximo(2) == 1)
                {
                    Console.WriteLine("\n✨ ✨ ✨ ✨ ✨ ✨ ✨ ✨ ✨ ✨ ✨ ✨ ✨ ✨ ✨\nSua magia foi bem sucedida! Você tem um bônus de 50 pontos de ataque para este golpe!\n✨ ✨ ✨ ✨ ✨ ✨ ✨ ✨ ✨ ✨ ✨ ✨ ✨ ✨ ✨");
                    bonusMagia = (int)(Magia *0.2);
                }
                else
                {
                    Console.WriteLine("❌ Sua magia falhou! Você não tem bônus de ataque para este golpe. ❌");
                }
            }
            if(resultadoDadoJogador == 20)
            {
                Console.WriteLine("CRÍTICO! O dano do seu ataque foi aumentado!");
                bonusMagia += (int)(Ataque * 0.5);
            }
            else if(resultadoDadoJogador >= 17)
            {
                Console.WriteLine("Ataque poderoso! O dano do seu ataque foi aumentado!");
                bonusMagia += (int)(Ataque * 0.2);
            }
            else if(resultadoDadoJogador >= 5)
            {
                Console.WriteLine("Ataque normal! O dano do seu ataque é o esperado.");
            }
            else if(resultadoDadoJogador >= 2)
            {
                Console.WriteLine("Ataque fraco! O dano do seu ataque foi reduzido!");
                bonusMagia -= (int)(Ataque * 0.1);
            }
            else
            {
                Console.WriteLine("FALHA CRÍTICA! O dano do seu ataque foi reduzido!");
                bonusMagia -= (int)(Ataque * 0.5);
            }
            // O dano final seria:
            int danoCausado = (Ataque + bonusMagia + resultadoDadoJogador) - boss.Defesa;

             // Se a defesa do Boss for maior que o ataque, o dano não pode ser negativo (cura o boss)
            if (danoCausado < 0) danoCausado = 0;

            // Aplica o dano no Boss
            boss.Vida -= danoCausado;

            Console.WriteLine($"\n⚔️ ⚔️ ⚔️ ⚔️ ⚔️ ⚔️ ⚔️ ⚔️ ⚔️ ⚔️ ⚔️ ⚔️ ⚔️ ⚔️ ⚔️ ⚔️{Nome} causou {danoCausado} de dano em {boss.Nome}!\n⚔️ ⚔️ ⚔️ ⚔️ ⚔️ ⚔️ ⚔️ ⚔️ ⚔️ ⚔️ ⚔️ ⚔️ ⚔️ ⚔️ ⚔️ ⚔️");
            Console.WriteLine($"Vida restante de {boss.Nome}: {boss.Vida}");

            if (boss.Vida <= 0)
            {
                Console.WriteLine($"VITÓRIA! {boss.Nome} foi derrotado!");
            }
        }

            public void ReceberDano(int danoInimigo)
            {
                int bônusDefesaMagica = 0;

                Console.WriteLine($"\n{Nome}, o inimigo está atacando! Tentar escudo mágico? (s/n)");
                string resposta = Console.ReadLine()?.ToLower() ?? "n";

                if (resposta == "s")
                {
                    if (DadoJogador.RolarMaximo(2) == 1) // Sucesso na moeda
                    {
                        bônusDefesaMagica = (int)(Magia * 0.1);
                        Console.WriteLine($"\n🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️\nSUCESSO! Escudo ativado: +{bônusDefesaMagica} de defesa!\n🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️ 🛡️");
                    }
                    else
                    {
                        Console.WriteLine("❌ FALHA! O escudo não se formou a tempo! ❌");
                    }
                }

                // Cálculo final: Dano do Boss - (Sua Defesa Base + Bônus Mágico)
                int danoFinal = danoInimigo - (Defesa + bônusDefesaMagica);
                Vida -= danoFinal;

                if (danoFinal < 0) 
                {
                    danoFinal = 0;
                }   

                Console.WriteLine($"{Nome} recebeu {danoFinal} de dano! Vida atual: {Vida}");

            }

            
        }
    

}
