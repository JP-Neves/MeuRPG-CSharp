namespace MeuRPG
{
    public class Menu
    {
        public void Abertura()
        {
            Console.WriteLine("Bem-vindo ao jogo! Neste RPG, você enfrentará desafios e batalhas épicas. Prepare-se para uma aventura inesquecível!");
            Console.WriteLine("Pressione Enter para começar...");
            Console.ReadLine();
        }

        public void EncontroBoss()
        {
            Console.WriteLine($"\nVocê encontra o boss da região!\n");
            Console.WriteLine("\n⚜️ ⚜️ ⚜️ ⚜️ ⚜️ ⚜️ ⚜️ ⚜️ ⚜️ ⚜️ ⚜️ ⚜️ ⚜️ ⚜️ ⚜️\nPressione Enter para iniciar a batalha...\n⚜️ ⚜️ ⚜️ ⚜️ ⚜️ ⚜️ ⚜️ ⚜️ ⚜️ ⚜️ ⚜️ ⚜️ ⚜️ ⚜️ ⚜️\n");
            Console.ReadLine();

            Console.WriteLine($"\nO boss é imponente e poderoso, mas você está determinado a derrotá-lo!\n");
            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();

        }

        public bool sorteio()
        {
            //Criando o dado para as ações do mestre.
            Dado dadoMestreAcao = new Dado(20);
            //Criando o dado para ação dos jogadores, se o ato de atacar vai ter bonus ou não, se o ataque vai ser crítico ou não, etc.
            Dado dadoJogadorAcao = new Dado(20);
            //Criando o dado para ação do boss, se o ato de atacar vai ter bonus ou não, se o ataque vai ser crítico ou não, etc.
            Dado dadoBossAcao = new Dado(20);

            Console.WriteLine("Vamos sortear quem começa a batalha, o jogador ou o boss. O número mais alto começa, em caso de empate, rola novamente.");
            Console.WriteLine("Pressione Enter para rolar os dados...");
            Console.ReadLine();

            //Sorteio do primeiro jogador a agir, primeiro o jogador rola o dado para ver quem começa, o número mais alto começa, em caso de empate, rola novamente.
            int heroiDado = dadoMestreAcao.Rolar();
            Console.WriteLine($"\nO número sorteado para o primeiro jogador é: {heroiDado}\n");
            //O Boss rola o dado
            int bossDado = dadoBossAcao.Rolar();
            Console.WriteLine($"\nO número sorteado para o boss é: {bossDado}\n");
            while (heroiDado == bossDado)
            {

                Console.WriteLine($"\nEmpate! Rolar novamente...\n");
                Console.ReadLine();
                heroiDado = dadoMestreAcao.Rolar();
                Console.WriteLine($"\nO número sorteado para o primeiro jogador é: {heroiDado}\n");
                bossDado = dadoBossAcao.Rolar();
                Console.WriteLine($"\nO número sorteado para o boss é: {bossDado}\n");
            }
            if (heroiDado > bossDado)
            {
                Console.WriteLine($"\nO jogador começa a batalha!\n");

                return true;
            }
            else
            {
                Console.WriteLine($"\nO boss começa a batalha!\n");
                
                return false;
            }

        }

    }
}
