using MeuRPG;

//Abertura do jogo
Menu menu = new Menu();
menu.Abertura();

//Criando o vilão do jogo com stats já predefinidos
BossFinal boss = new BossFinal();

//criando os personagens do jogo
Console.WriteLine("Quantos jogadores irão jogar?");
int numJogadores = int.Parse(Console.ReadLine() ?? "1");
List<Jogador> herois = new List<Jogador>();

for (int i = 0; i < numJogadores; i++)
{
    Console.WriteLine($"\nDigite o nome do jogador:\n");
    string heroiNome = Console.ReadLine() ?? "Herói";

    Console.WriteLine($"\nEscolha a sua classe:\n⚔️ Guerreiro\n🧙 Mago\n🏹 Arqueiro\n");
    string classeEscolhida = Console.ReadLine() ?? "Guerreiro";

    Console.WriteLine($"\nE qual a sua raça?\n🧔 Humano 👩\n🧝 Elfo 🧝\n🪓 Anão 🪓\n");
    Console.WriteLine("Caso escolha a classe humano você terá atributos padrões, sem pontos fortes ou fracos.");
    Console.WriteLine("Caso escolha elfo, você terá um bônus de 100 pontos em todos os atributos.");
    Console.WriteLine("Caso escolha anão, você terá um bônus de 100 pontos de vida, 150 pontos de ataque e defesa, mas não terá bônus de magia.");
    string racaHeroi = Console.ReadLine() ?? "Humano";

    herois.Add(new Jogador(heroiNome, classeEscolhida, racaHeroi));
}

foreach (var heroi in herois)
{
    Console.WriteLine($"\nJogador: {heroi.Nome}\nClasse: {heroi.Classe}\nVida: {heroi.Vida}\nAtaque: {heroi.Ataque}\nDefesa: {heroi.Defesa}\nMagia: {heroi.Magia}\n");
}

Menu encontro = new Menu();
encontro.EncontroBoss();


Menu sortear = new Menu();
bool sorteioInicial = sortear.sorteio();

while(boss.Vida > 0 && herois.Any(h => h.Vida > 0))
{
    if (sorteioInicial)
    {
        foreach (var heroi in herois) { if (heroi.Vida > 0) { heroi.atacar(boss); } }
        
        
            if (boss.Vida > 0) { boss.atacar(herois); }
    }
    else
    {
        boss.atacar(herois);
        foreach (var heroi in herois) { if (heroi.Vida > 0) { heroi.atacar(boss); } }
    }        
}



if (boss.Vida <= 0)
{
    Console.WriteLine($"\nParabéns, heróis! Vocês derrotaram {boss.Nome} e salvaram a região!\n");
}
else if (herois.All(h => h.Vida <= 0))
{
    Console.WriteLine("\n💀 GAME OVER... O Boss Lyniac aniquilou o grupo.");
}

Console.WriteLine("\nObrigado por jogar MeuRPG!\nEspero que tenha se divertido nessa aventura épica!\n");
Console.WriteLine("\nPressione Enter para encerrar o jogo...");
Console.ReadLine();