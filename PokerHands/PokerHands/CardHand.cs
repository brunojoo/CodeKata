using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    public class CardHand : IComparable<CardHand>
    {
        private List<Card> _cards;

        public CardHand(IEnumerable<string> hand)
        {
            _cards = hand.Select(e => new Card(e)).ToList();
        }

        public static bool operator ==(CardHand a, CardHand b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(CardHand a, CardHand b)
        {
            return !a.Equals(b);
        }

        public override bool Equals(object? obj)
        {
            if (CompareTo(obj as CardHand) != 0) return false;
            var myBestHand = GetPokerHand();
            return myBestHand.Equals(_cards, (obj as CardHand)._cards);
        }

        public int CompareTo(CardHand opponent)
        {
            var myBestHand = GetPokerHand();
            var opponentBestHand = opponent.GetPokerHand();

            if (myBestHand.GetWeight() == opponentBestHand.GetWeight())
            {
                var opponentCardsOrdered = opponent._cards.OrderByDescending(c => c).ToList();
                var myCardsOrdered = _cards.OrderByDescending(c => c).ToList();

                for (int i = 0; i < _cards.Count; i++)
                {
                    if (!myCardsOrdered[i].Equals(opponentCardsOrdered[i]))
                        return myCardsOrdered[i].CompareTo(opponentCardsOrdered[i]);
                }

            }

            return myBestHand.CompareTo(opponentBestHand);
        }

        private PokerHand GetPokerHand()
        {
            return PokerHandFinder.Get(_cards);


            //
            //
            // var pair = GetPair();
            // if (pair != null) return new PokerHand(PokerHandsCombos.PAIR, pair);
            //
            // return new PokerHand(PokerHandsCombos.HIGHCARD, GetHighCard());
        }

        // private string GetPair()
        // {
        //     for (var i = 0; i < Hand.Count; i++)
        //     {
        //         var current = Hand[i].First();
        //         for (var j = i + 1; j < Hand.Count; j++)
        //             if (current == Hand[j].First())
        //                 return Hand[i];
        //     }
        //
        //     return null;
        // }
        //
        // private string GetHighCard()
        // {
        //     var bestCardIndex = -1;
        //     var bestCard = "";
        //     foreach (var card in Hand)
        //     {
        //         var position = PokerRules.CardOrder.IndexOf(card[0]);
        //         if (position <= bestCardIndex) continue;
        //         bestCardIndex = position;
        //         bestCard = card;
        //     }
        //
        //     return bestCard;
        // }
    }
}
