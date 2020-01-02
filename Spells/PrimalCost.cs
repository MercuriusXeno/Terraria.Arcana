using System;
using Arcana.Enums.DeliveryMechanism;
using Arcana.Reference;
using Arcana.Spells.Elements;
using Terraria.ModLoader.IO;

namespace Arcana.Spells
{
    /// <summary>
    ///     Class representing the primal cost(s) of a spell effect or the cost of crafting (they're completely alike in every respect, it's just an element and a value)
    /// </summary>
    public class PrimalCost : TagSerializable
    {

        public PrimalCost(Element element, float cost)
        {
            Element = element;
            Cost = cost;
        }


        public static PrimalCost Load(TagCompound tag)
        {
            return new PrimalCost(
                tag.Get<Element>(Constants.NbtNames.PrimalCost.ELEMENT),
                tag.GetFloat(Constants.NbtNames.PrimalCost.COST));
        }

        public TagCompound SerializeData()
        {
            return new TagCompound()
            {
                { Constants.NbtNames.PrimalCost.ELEMENT, Element },
                { Constants.NbtNames.PrimalCost.COST, Cost }
            };
        }

        public static readonly Func<TagCompound, PrimalCost> DESERIALIZER = Load;

        /// <summary>
        ///     The nearest greater-or-equal integral of the cost for the purposes of payment of a spell's cost casting or crafting.
        ///     Included for convenience.
        /// </summary>
        public int FlatCost => (int)Math.Ceiling(Cost);

        /// <summary>
        ///     Which element is the primal cost? "None" can be used to track the non-primal cost of a spell when it is cast (mana!)
        /// </summary>
        public Element Element { get; set; }

        /// <summary>
        ///     The cost in primals (or mana) of the effect or spell being crafted. Represented as a float for math purposes, but should be interacted with as a ceiling value
        ///     for the purposes of user interface. (FlatCost)
        /// </summary>
        public float Cost { get; set; }
    }
}