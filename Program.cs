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
          cardInfo.Add(symbolCard[i] + nrCard[y], nrCard[y]);

          Console.WriteLine(cardInfo);

          //   !Tar in cardInfo till kort högen
          cardStack.Push(cardInfo);
        }
      }
      // cardinfo[Spader 1]
      //   cardInfo.Add("Strength", 20);

      //   cardStack.Push(cardInfo);


      //   cardStack.Push(42);
      //   cardStack.Push(665);

      // Precis som för queue, peekar "nästa värde". Det som ligger högst upp – 665.
      //   Console.WriteLine(cardStack.Peek());

      // Tar bort det som ligger högst upp i högen och returnerar det.
      // Så nu är bara 5 och 42 kvar i högen.
      //   int s = cardStack.Pop();
    }
  }
}
