namespace Arcana.Spells.Elements
{
    /// <summary>
    ///     Helper class used for aggregating the density of elements in a spell to determine the dominant element for visual purposes.
    /// </summary>
    public class ElementWeight
    {
        public ElementWeight(IElement element, float weight)
        {
            Element = element;
            Weight = weight;
        }

        public IElement Element { get; set; }

        public float Weight { get; set; }
    }
}