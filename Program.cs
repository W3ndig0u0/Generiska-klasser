using System.Linq;
using System;
using System.Collections.Generic;

namespace Generiska_klasser
{
  class Program
  {
    static void Main(string[] args)
    {
      // !Innehåller alla kort, (Dictionary)
      Stack<Dictionary<string, char>> cardStack = new Stack<Dictionary<string, char>>();

      //! Har information om kortens färg o siffra, (alla listor)
      Dictionary<string, char> cardInfo = new Dictionary<string, char>();

      // !List ska innehålla alla möjliga färger och siffror som dictionary kan ha
      // ?spader (♠) (svart), hjärter (♥) (Röd), ruter (♦) (Röd) och klöver (♣) (Svart)
      List<char> symbolCard = new List<char>() { '♠', '♥', '♣', '♦' };
      List<char> nrCard = new List<char>() { 'A', '2', '3', '4', '5', '6', '7', '8', '9', 'S', 'J', 'Q', 'K' };

      int amountSymbol = symbolCard.Count;

      // !Ska gå igenom varje Sybomlcard och ska ge de 13 olika siffror, så att alla siffror kommer ha 4 olika symboler, som i en riktig kortlek

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

          // Console.WriteLine(cardInfo[cardStatsChar] + cardStatsChar);

          //   !Tar in cardInfo till kort högen
          cardStack.Push(cardInfo);
        }

      }
      string cardIndex = cardStack.Peek().Keys.First();
      int cardValue = cardInfo[cardIndex];



      Console.WriteLine(cardValue);
      Console.WriteLine(cardValue);

      string aiPoints = "0";
      string playerPoints = "0";
      // Random random = new Random();

      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("Nu kommer varje spelare dra 2 kort");
      // aiPoints += random.Next(1, 14);
      // playerPoints += random.Next(1, 14);

      string cardChoises = "";

      // Console.WriteLine($"Din poäng: {playerPoints}");
      // Console.WriteLine($"Datorns poäng: {aiPoints}");
      // Console.WriteLine();
      // Console.WriteLine($"Svara med j (Ja) eller n (nej)");
      // Console.WriteLine("Vill du ha ett till kort? (j/n)");

    }
  }
}
