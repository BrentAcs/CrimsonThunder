namespace Balance.Core.Models;

public class Influence
{
   public Dictionary<Player, int> _map = new();

   public Influence()
   {
      _map[Player.One] = 0;
      _map[Player.Two] = 0;
      _map[Player.Three] = 0;
      _map[Player.Four] = 0;
   }

   public int this[Player player] => GetAmount(player);

   public int GetAmount(Player player) => _map[player];
   public int SetAmount(Player player, int amount) => _map[player] = amount;
   public int AddAmount(Player player, int amount) => _map[player] += amount;
}
