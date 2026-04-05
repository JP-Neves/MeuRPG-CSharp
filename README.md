
📑 Documentação Técnica: Sistema de Combate MeuRPG
1. Visão Geral
Este projeto é uma aplicação de console desenvolvida em C# (.NET 10) que simula a estrutura inicial de um jogo de RPG de mesa. O foco principal da implementação foi a aplicação de Programação Orientada a Objetos (POO) para criar um sistema modular, escalável e de fácil manutenção.
2. Arquitetura de Classes
2.1. Classe Dado (Núcleo de Aleatoriedade)
A classe Dado é o motor de sorte do sistema. Ela utiliza o conceito de Encapsulamento para proteger a lógica de geração de números.
Campos Privados: _random e _quantidadeFaces. O uso do _ identifica que são membros internos da classe.
Método Rolar(int bonus): Implementa a lógica de limite exclusivo do C# (Next(min, max+1)) e permite a adição de modificadores externos, essencial para cálculos de atributos de RPG.
2.2. Classe Jogador (Entidade Dinâmica)
Representa os heróis criados pelo usuário.
Propriedades Automáticas: Utiliza { get; set; } para permitir leitura e escrita controlada de atributos como Vida, Ataque e Defesa.
Composição: Cada objeto Jogador possui sua própria instância de Dado. Isso garante que o estado de "sorte" de um jogador seja independente dos outros.
Construtor: Recebe parâmetros dinâmicos (nome, classe) no momento da execução, permitindo a criação de múltiplos heróis em tempo de execução.
2.3. Classe BossFinal (Entidade Estática)
Representa o antagonista principal do cenário.
Valores Predefinidos: Ao contrário do jogador, seus atributos são fixados no construtor, servindo como um "obstáculo de desafio" com valores de dificuldade estáticos (1000 HP).
2.4. Classe Menu (Orquestração e Interface)
Responsável pela Abstração da interface de usuário e regras de fluxo.
Método sorteio(): É o "juiz" do jogo. Retorna um tipo Booleano (bool).
Lógica de Desempate: Implementa um laço while que garante que o programa só prossiga quando houver um vencedor claro na iniciativa.
Retorno de Estado: O uso de return true/false permite que o programa principal tome decisões lógicas baseadas no resultado da interface.
3. Fluxo de Execução (Main)
O arquivo principal coordena a interação entre as classes seguindo este fluxo:
Inicialização: Instanciação da interface de Menu e do BossFinal.
Fábrica de Heróis: Coleta de dados do console e armazenamento em uma List<Jogador>.
Validação de Nulos: Uso do operador ?? para garantir a integridade dos dados inseridos pelo usuário.
Disputa de Iniciativa: Chamada do método de sorteio e captura do resultado em uma variável de controle de fluxo.
4. Conceitos de POO Aplicados
Abstração: Detalhes complexos (como o sorteio de dados e mensagens de texto) foram escondidos dentro de métodos simples.
Encapsulamento: Uso de modificadores public e private para proteger dados sensíveis.
Instanciação: Criação de múltiplos objetos a partir de um único molde (Classe).
Associação/Composição: Um objeto (Jogador) contém outro objeto (Dado).
5. Próximas Implementações Sugeridas
Especialização de Classes: Implementar lógica no construtor de Jogador para que a string Classe altere os status base (ex: Mago recebe +50 de Ataque).
Ciclo de Turnos: Implementar um loop while no Main que alterne a variável de controle de turno até que a vida de uma das entidades chegue a zero