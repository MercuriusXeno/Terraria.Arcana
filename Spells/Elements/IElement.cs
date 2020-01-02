using Arcana.Commons;
using WebmilioCommons.Managers;

namespace Arcana.Spells.Elements
{
    public interface IElement : IHasUnlocalizedName
    {
        string GetSmallDustName();
    }
}
