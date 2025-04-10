static void Menu()
{
    Console.Clear();
    Console.WriteLine("Bem vindo ao seu Editor de Textos! Digite o numéro referente a opção desejada.");
    Console.WriteLine("1 - Abrir");
    Console.WriteLine("2 - Editar");
    Console.WriteLine("0 - Sair");

    string option = Console.ReadLine();
    short optionNumber = 0;

    try
    {
        optionNumber = short.Parse(option);
    }
    catch
    {
        Console.Clear();
        for (int i = 5; i > 0; i--)
        {
            Console.WriteLine($"Parece que você não digitou um número! Tente novamente em {i} segundos!");
            Thread.Sleep(1000);
            Console.Clear();
        }
        Menu();
    }
    ;

    switch (optionNumber)
    {
        case 0: System.Environment.Exit(0); break;
        case 1: Open(); break;
        case 2: Edit(); break;
        default:
            Console.Clear();
            for (int i = 5; i > 0; i--)
            {
                Console.WriteLine($"Erro na opção digitada! Tente novamente em {i} segundos!");
                Thread.Sleep(1000);
                Console.Clear();
            }
            Menu();
            break;
    }
    ;

    static void Open()
    {
        Console.WriteLine("Abriu!");
    }
    ;

    static void Edit()
    {
        Console.Clear();
        Console.WriteLine("Digite o texto abaixo. (Digite ESC para sair)");

        string text = "";

        do
        {
            text += Console.ReadLine();
            text += Environment.NewLine;

        }
        while (Console.ReadKey().Key != ConsoleKey.Escape);

        Save(text);

    }
    ;

    static void Save(string text)
    {
        Console.Clear();
        Console.WriteLine("Qual o caminho em que você deseja salvar o arquivo?");

        string path = Console.ReadLine();

        using (var file = new StreamWriter(path))
        {
            file.Write(text);
        }

        Console.WriteLine($"Arquivo salvo com sucesso em {path}");
    }
}

Menu();
