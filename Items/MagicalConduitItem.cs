using System.Collections.Generic;
using System.Linq;
using Arcana.Reference;
using Arcana.Spells;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using WebmilioCommons.Items.Standard;

namespace Arcana.Items
{
    public class MagicalConduitItem : StandardItem
    {
        private const int WHATEVER = ItemID.MagnetSphere;
        private const int REFERENCE_ITEM_ID = ItemID.DeathSickle;

        private static readonly Item _referenceItem = GetReferenceItem();
        private static Item GetReferenceItem()
        {
            Item refItem = new Item();
            refItem.netDefaults(REFERENCE_ITEM_ID);
            return refItem;
        }

        /// <summary>
        ///     The delivery mechanism(s) this conduit fires when used, determines what the conduit does.
        /// </summary>
        private List<DeliveryMechanism> RootMechanisms;

        public MagicalConduitItem() : this(Constants.Items.MAGICAL_CONDUIT, Constants.ItemDescriptions.MAGICAL_CONDUIT, _referenceItem)
        {
            RootMechanisms = new List<DeliveryMechanism>();
        }

        public MagicalConduitItem(string displayName, string tooltip, Entity terrariaItemUsedAsConduit) : base(displayName, tooltip, terrariaItemUsedAsConduit.width, terrariaItemUsedAsConduit.height, 0, 0, -12, 1)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.useTime = 1;
            item.useAnimation = GetReferenceItem().useAnimation;
            item.useStyle = GetReferenceItem().useStyle;
            item.noMelee = true;
            item.UseSound = SoundID.Item20;
            item.autoReuse = false;
        }

        public override void HoldItem(Player player)
        {
            player.itemRotation = 0f;
            player.itemLocation.Y = player.Center.Y;
            player.itemLocation.X = player.Center.X - 18 * player.direction;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(ArcanaMod.Instance);
            recipe.AddIngredient(ItemID.DirtBlock);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        

        public override bool CanUseItem(Player player)
        {
            return true;
        }

        public override bool UseItem(Player player)
        {
            DeliveryMechanism deliveryMechanism = DebugPrefab.BasicFireProjectile;
            Vector2 bearing = (Main.MouseWorld - player.Center);
            bearing.Normalize();
            ArcaneEvent arcaneEvent = new ArcaneEvent(deliveryMechanism, player.Center, bearing);
            ArcanaWorld world = ModContent.GetInstance<ArcanaWorld>();
            world.AddArcaneEvent(arcaneEvent);
            return base.UseItem(player);
        }

        public override string Texture => $"{Constants.TERRARIA_ITEM_PREFIX}{REFERENCE_ITEM_ID}";

        public override TagCompound Save()
        {
            TagCompound saveData = new TagCompound {{"rootMechanisms", RootMechanisms}};
            return saveData;
        }

        public override void Load(TagCompound tag)
        {
            this.RootMechanisms = tag.GetList<DeliveryMechanism>("rootMechanisms").ToList();

        }
    }
}
