using System;
using System.Net;

class Program
{
  static void Main()
  {
    while (true)
    {
      Console.WriteLine("Escolha um nível de dificuldade: ");
      Console.WriteLine("(1 - Fácil   2 - Médio   3 - Difícil) ");

      int difficultyLevel = Convert.ToInt16(Console.ReadLine());
      (int, int) playerChoice = SetDifficulty(difficultyLevel);
      int difficulty = playerChoice.Item1;
      int tries = playerChoice.Item2;
      int secretNumber = GenerateRandomNumber(difficulty);

      Console.WriteLine("Tente adivinhar o meu número secreto huahuahuah: ");
      string response = GetPlayerGuess(tries, secretNumber);
      Console.WriteLine(response);

      Console.WriteLine("\nJogar Novamente? (s/n)");
      char playAgain = Convert.ToChar(Console.ReadLine());
      if (playAgain == 's')
      {
        continue;
      }
      else
      {
        break;
      }
    }
  }

  static int GenerateRandomNumber(int difficulty)
  {
    Random random = new Random();
    int number = random.Next(1, difficulty);
    return number;
  }

  static (int, int) SetDifficulty(int chosenDifficulty)
  {
    int difficulty;
    int tries;
    switch (chosenDifficulty)
    {
      case 1:
        difficulty = 51;
        tries = 3;
        break;
      case 2:
        difficulty = 101;
        tries = 5;
        break;
      case 3:
        difficulty = 501;
        tries = 10;
        break;
      default:
        difficulty = 51;
        tries = 3;
        break;
    }
    return (difficulty, tries);
  }

  static string GetPlayerGuess(int tries, int secretNumber)
  {
    string response = $"O número era: {secretNumber}";
    while (tries > 0)
    {
      Console.WriteLine($"Tentativas restantes: {tries} ");
      int guessedNumber = Convert.ToInt32(Console.ReadLine());
      if (guessedNumber == secretNumber)
      {
        return $"Parabéns, você acertou! O número era {secretNumber}";
      }
      else if (guessedNumber > secretNumber)
      {
        Console.WriteLine("Xiii... o número secreto é menor");
        tries -= 1;
      }
      else if (guessedNumber < secretNumber)
      {
        Console.WriteLine("Xiii... o número secreto é maior");
        tries -= 1;
      }
    }
    return response;
  }
}