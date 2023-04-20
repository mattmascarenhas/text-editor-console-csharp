Menu();

static void Menu()
{
  short option = 0;

  Console.Clear();
  Console.WriteLine("O que deseja fazer?");
  Console.WriteLine("1- Abrir arquivo");
  Console.WriteLine("2- Criar novo arquivo");
  Console.WriteLine("0- Sair");

  option = short.Parse(Console.ReadLine());

  switch (option)
  {
    case 0: System.Environment.Exit(0); break;
    case 1: OpenFile(); break;
    case 2: newtext(); break;
    default: Menu(); break;
  }

}

static void OpenFile()
{
  Console.Clear();
  Console.WriteLine("Qual o caminho do arquivo?");
  Console.WriteLine("--------------------------");
  string path = Console.ReadLine();

  using (var file = new StreamReader(path))
  {
    string text = file.ReadToEnd(); // ler o arquivo e salva na string
    Console.WriteLine(text);
  }

  Console.WriteLine("");
  Console.ReadLine();
  Menu();
}

static void newtext()
{
  string text = "";

  Console.Clear();
  Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
  Console.WriteLine("--------------------------");

  //enquanto a tecla digitada nao for o ESC, executa
  do
  {
    text += Console.ReadLine();
    text += Environment.NewLine;
  }
  while (Console.ReadKey().Key != ConsoleKey.Escape);

  Save(text);

}

static void Save(string text)
{
  Console.Clear();
  Console.WriteLine("Qual caminho para salvar o arquivo?");
  var path = Console.ReadLine();

  using (var file = new StreamWriter(path))
  {
    file.Write(text);
  }

  Console.WriteLine($"Arquivo {path} salvo com sucesso");
  Console.ReadLine();
  Menu();
}