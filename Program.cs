using System;
internal class RPG
{
  private static string name, email, password;
  private static DateTime birthDate;
  private static string classUser = "";

  public static void Main()
  {
    Register();

    Login();

    ChoiceClass();

    ChooseAttributes();

  }

  private static void Register()
  {
    Console.WriteLine("---Cadastro---");

    Console.WriteLine("Digite seu nome: ");
    name = Console.ReadLine();

    DateTime now = DateTime.Now;

    bool dateValid = false;
    do
    {
      Console.WriteLine("Digite sua data de nascimento: ");
      try
      {
        birthDate = DateTime.Parse(Console.ReadLine());
        TimeSpan diff = now - birthDate;

        int year = diff.Days / 365;
        int month = diff.Days % 365 / 30;
        int days = diff.Days % 30;

        if (year > 18 || (year == 18 && month >= 0) || (year == 18 && month == 0 && days >= 0))
        {
          dateValid = true;
        }
        else
        {
          Console.WriteLine("Você precisa ser maior de 18 anos para jogar!");
          Environment.Exit(0);
        }

      }
      catch (Exception)
      {
        Console.WriteLine("Data inválida");
      }


    } while (!dateValid);

    Console.WriteLine("Digite seu email: ");
    email = Console.ReadLine();

    string passwordConfirmed;

    do
    {

      Console.WriteLine("Digite sua senha: ");
      password = Console.ReadLine();

      Console.WriteLine("Confirmar senha: ");
      passwordConfirmed = Console.ReadLine();

      if (passwordConfirmed != password)
      {
        Console.WriteLine("As senhas são diferentes!");
      }

    } while (passwordConfirmed != password | password.Length < 6);

    Console.WriteLine("---Cadastro concluído---");

  }

  private static void Login()
  {
    int tries = 0;

    string emailUser, passwordUser;
    bool success = false;

    Console.WriteLine("---Login---");

    while (tries < 3 && !success)
    {
      Console.WriteLine("Digite seu email:");
      emailUser = Console.ReadLine();

      Console.WriteLine("Digite sua senha:");
      passwordUser = Console.ReadLine();

      if (emailUser == email && password == passwordUser)
      {
        success = true;
        Console.WriteLine("Login efetuado com secesso");
      }
      else
      {
        tries++;
        Console.WriteLine("Email ou senha inválida");
        if (tries >= 3)
        {
          Console.WriteLine("Número de tentativas excedidas");
          Environment.Exit(0);
        }
      }
    }

  }

  private static void ChoiceClass()
  {

    string[] classNames = { "Paladino", "Atirador", "Guerreiro", "Bárbaro", "Arqueiro" };

    Console.WriteLine("Escolha sua classe para jogar:");

    for (int i = 0; i < classNames.Length; i++)
    {
      Console.WriteLine("{0}) {1}", i + 1, classNames[i]);
    }


    while (classUser == "")
    {
      try
      {
        int classUserId;
        classUserId = int.Parse(Console.ReadLine());
        classUser = classNames[classUserId - 1];

        Console.WriteLine("Classe escolhida {0}-{1}",classUserId, classUser);
      }
      catch (Exception)
      {
        Console.WriteLine("Opção inválida, selecione novamente:");
      }
    }

  }

  private static void ChooseAttributes()
  {
    Console.WriteLine("Selecione as características do seu personagem:");

  }
}
