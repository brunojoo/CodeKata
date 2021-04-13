using System.Collections.Generic;
using System.Linq;
using PokerHands;

namespace PokerHands
{
    public class PokerCalculator
    {
        private readonly ICollection<Player> _players;

        public PokerCalculator(string hands)
        {
            _players = new List<Player>();

            var splitted = hands.Split(' ');

            for (var i = 0; i < splitted.Length; i += 6)
            {
                _players.Add(new Player
                {
                    Name = splitted.Skip(i).Take(1).First().TrimEnd(':'),
                    Hand = new CardHand(splitted.Skip(i + 1).Take(5).ToList())
                });
            }
        }

        public string CalculateWinner()
        {
            var orderedPlayers = _players.OrderByDescending(e => e.Hand);
            var winners = GetWinners(orderedPlayers).ToList();
            return winners.Count > 1 ? "Draw" : winners.First().Name;
        }

        private IEnumerable<Player> GetWinners(IEnumerable<Player> orderedPlayers)
        {
            var firstPlayer = orderedPlayers.First();

            return orderedPlayers.Where(e => e.Hand == firstPlayer.Hand);
        }
    }
}

class Player
{
    public CardHand Hand { get; set; }
    public string Name { get; set; }
}