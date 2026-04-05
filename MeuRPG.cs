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

    Console.WriteLine($"\nEscolha a sua classe:\nGuerreiro\nMago\nArqueiro\n");
    string classeEscolhida = Console.ReadLine() ?? "Guardião";

    herois.Add(new Jogador(heroiNome, classeEscolhida));
}

foreach (var heroi in herois)
{
    Console.WriteLine($"\nJogador: {heroi.Nome}\nClasse: {heroi.Classe}\nVida: {heroi.Vida}\nAtaque: {heroi.Ataque}\nDefesa: {heroi.Defesa}");
}

Menu encontro = new Menu();
encontro.EncontroBoss();


Menu sortear = new Menu();
bool sorteioInicial = sortear.sorteio();
