﻿using System.Linq;
using System;
using System.Collections.Generic;

namespace Generiska_klasser
{
  class Program
  {

    static void Main(string[] args)
    {

      // !Innehåller alla kort, (Dictionary)
      Queue<Dictionary<string, char>> cardQueue = new Queue<Dictionary<string, char>>();

      //! Har information om kortens färg o siffra, (alla listor)
      Dictionary<string, char> cardInfo = new Dictionary<string, char>();

      // !List ska innehålla alla möjliga färger och siffror som dictionary kan ha
      // ?spader (♠) (svart), hjärter (♥) (Röd), ruter (♦) (Röd) och klöver (♣) (Svart)
      List<char> symbolCard = new List<char>() { '♠', '♥', '♣', '♦' };
      List<char> nrCard = new List<char>() { 'A', '2', '3', '4', '5', '6', '7', '8', '9', 'I', 'J', 'Q', 'K' };


      string menuChoisesString = "";

      Console.WriteLine("Välj ett alternativ!");
      Console.WriteLine("1. Starta spel");
      Console.WriteLine("2. Spelets regler");
      Console.WriteLine("3. Avsluta programmet");
      menuChoisesString = Console.ReadLine();
      Menu(symbolCard, nrCard, cardInfo, cardQueue, menuChoisesString);

    }

    static void Menu(List<char> symbolCard, List<char> nrCard, Dictionary<string, char> cardInfo, Queue<Dictionary<string, char>> cardQueue, string menuChoisesString)
    {
      Console.ReadLine();

      switch (menuChoisesString)
      {
        case "1":
          // !Ska gå igenom varje Sybomlcard och ska ge de 13 olika siffror, så att alla siffror kommer ha 4 olika symboler, som i en riktig kortlek
          LoopingThoughtCard(symbolCard, nrCard, cardInfo, cardQueue);

          // !Startar spelet
          CardGame(symbolCard, nrCard, cardInfo, cardQueue);
          Console.Clear();
          break;

        case "2":
          // !Instruktioner
          Console.WriteLine("Ditt mål är att tvinga din motståndare att få mer än 21 poäng.");
          Console.WriteLine("Du får poäng genom att dra kort, varje kort har mellan 1-13 poäng.");
          Console.WriteLine("Om du får mer än 21 poäng har du förlorat.");
          Console.WriteLine("Både du och din motståndare får två kort i början. Därefter får du");
          Console.WriteLine("dra fler kort tills du är nöjd eller får över 21.");
          Console.WriteLine("När du är färdig drar datorn kort till den har");
          Console.WriteLine("mer poäng än dig eller över 21 poäng.");
          break;

        case "3":
          Environment.Exit(0);
          break;

        default:
          Console.WriteLine("Error!");
          Console.WriteLine("Du har inte valt någon av alternativen");
          break;
      }

    }


    static void CardGame(List<char> symbolCard, List<char> nrCard, Dictionary<string, char> cardInfo, Queue<Dictionary<string, char>> cardQueue)
    {
      // !Båda får två kort
      DrawRandomCard(symbolCard, nrCard, cardQueue);
      int aiPoints = CardValue(DrawRandomCard(symbolCard, nrCard, cardQueue));
      int playerPoints = CardValue(DrawRandomCard(symbolCard, nrCard, cardQueue));

      Console.WriteLine("Nu kommer alla dra ett kort");

      string cardChoises = "";

      while (cardChoises != "n" && playerPoints <= 21 && aiPoints <= 21)
      {
        Console.WriteLine($"Din poäng: {playerPoints}");
        Console.WriteLine($"Datorns poäng: {aiPoints}");
        Console.WriteLine();
        Console.WriteLine($"Svara med j (Ja) eller n (nej)");
        Console.WriteLine("Vill du ha ett till kort? (j/n)");

        cardChoises = Console.ReadLine();

        switch (cardChoises)
        {
          case "j":
            int newPoint = CardValue(DrawRandomCard(symbolCard, nrCard, cardQueue));
            playerPoints += newPoint;
            Console.WriteLine();
            Console.WriteLine($"Ditt nya kort är värt {newPoint} poäng");
            Console.WriteLine($"Din totala poäng är nu:  {playerPoints}");

            Console.WriteLine();
            int aiNewPoints = CardValue(DrawRandomCard(symbolCard, nrCard, cardQueue));
            aiPoints += aiNewPoints;
            Console.WriteLine($"Din Motståndare kort är värt {aiNewPoints}");
            Console.WriteLine($"Din Motståndare totala poäng är nu:  {aiPoints}");
            break;

          case "n":
            break;

          default:
            Console.WriteLine();
            Console.WriteLine("Error!");
            Console.WriteLine("Du har inte valt någon av alternativen (j) eller (n)");
            break;
        }
      }
    }

    static void LoopingThoughtCard(List<char> symbolCard, List<char> nrCard, Dictionary<string, char> cardInfo, Queue<Dictionary<string, char>> cardQueue)
    {
      int amountSymbol = symbolCard.Count;

      for (int y = 0; y < nrCard.Count; y++)
      {
        for (int i = 0; i < symbolCard.Count; i++)
        {
          //   !Det finns bara 4 olika symboler
          if (i >= amountSymbol)
          {
            return;
          }
          // !Gör int till string
          string cardStatsChar = symbolCard[i].ToString() + nrCard[y].ToString();
          cardInfo.Add(cardStatsChar, nrCard[y]);

          //   !Tar in cardInfo till kort högen
          cardQueue.Enqueue(cardInfo);
        }

      }
    }

    static int CardValue(char cv)
    {
      int intValue = 0;
      switch (cv)
      {
        case '1':
          Console.WriteLine(1);
          return intValue = 1;

        case '2':
          Console.WriteLine(2);
          return intValue = 2;

        case '3':
          Console.WriteLine(3);
          return intValue = 3;

        case '4':
          Console.WriteLine(4);
          return intValue = 4;

        case '5':
          Console.WriteLine(5);
          return intValue = 5;

        case '6':
          Console.WriteLine(6);
          return intValue = 6;

        case '7':
          Console.WriteLine(7);
          return intValue = 7;

        case '8':
          Console.WriteLine(8);
          return intValue = 8;

        case '9':
          Console.WriteLine(9);
          return intValue = 9;

        case 'I':
          Console.WriteLine(10);
          return intValue = 10;

        case 'J':
          Console.WriteLine(11);
          return intValue = 11;

        case 'Q':
          Console.WriteLine(12);
          return intValue = 12;

        case 'K':
          Console.WriteLine(13);
          return intValue = 13;
        default:
          Console.WriteLine("Error: Felaktigt värde");
          return intValue;
      }
    }

    static char DrawRandomCard(List<char> symbolCard, List<char> nrCard, Queue<Dictionary<string, char>> cardQueue)
    {
      Random randomNumber = new Random();

      int nrCardIndex = randomNumber.Next(nrCard.Count);
      int symbolCardIndex = randomNumber.Next(symbolCard.Count);

      // !Tar en random kort
      string cardStatsCharString = symbolCard[symbolCardIndex].ToString() + nrCard[nrCardIndex].ToString();

      randomNumber.Next(cardQueue.Count);

      char returnChar = cardQueue.Peek()[cardStatsCharString];
      Console.WriteLine(cardQueue.Peek()[cardStatsCharString]);

      cardQueue.Dequeue();

      return returnChar;
    }
  }
}
