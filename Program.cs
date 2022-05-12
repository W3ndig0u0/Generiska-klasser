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

      Console.WriteLine(cardStack.Peek().Keys.First());
      Console.WriteLine(cardStack.Peek().Values);

    }
  }
}
