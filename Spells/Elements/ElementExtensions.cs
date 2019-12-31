namespace Arcana.Spells.Elements
{
    public static class ElementExtensions
    {
        public static string GetDustName(this IElement element)
        {
            return $"{element.Name}Dust";
        }
    }
}