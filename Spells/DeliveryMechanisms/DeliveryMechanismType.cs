﻿using System;
using Arcana.Reference;
using Terraria.ModLoader.IO;

namespace Arcana.Spells.DeliveryMechanisms
{
    public abstract class DeliveryMechanismType : IDeliveryMechanismType, TagSerializable
    {
        protected DeliveryMechanismType(string name)
        {
            UnlocalizedName = name;
        }


        public abstract void HandleDrawing(ArcaneEvent arcaneEvent);

        public abstract void Process(ArcaneEvent arcaneEvent);

        public string UnlocalizedName { get; }
        public TagCompound SerializeData()
        {
            return new TagCompound() { [Constants.NbtNames.Common.UNLOCALIZED_NAME] = UnlocalizedName };
        }

        public static readonly Func<TagCompound, DeliveryMechanismType> DESERIALIZER = Load;

        public static DeliveryMechanismType Load(TagCompound tag)
        {
            return DeliveryMechanismTypeLoader.Instance.GetGeneric(
                tag.GetString(Constants.NbtNames.Common.UNLOCALIZED_NAME));
        }
    }
}