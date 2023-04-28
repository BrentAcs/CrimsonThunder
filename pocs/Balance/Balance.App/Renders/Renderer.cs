using Balance.Core.Extensions;
using Balance.Core.Models;

namespace Balance.App.Renders;

public abstract class Renderer
{
   protected int PlayerCount => Enum.GetValues<Player>().OnboardOnly().Count();
}
