using Arcana.Reference;
using Arcana.Spells;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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

        public MagicalConduitItem() : this(Constants.Items.MAGICAL_CONDUIT, Constants.ItemDescriptions.MAGICAL_CONDUIT, _referenceItem)
        {
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

        public override string Texture => $"{Constants.TERRARIA_ITEM_PREFIX}{REFERENCE_ITEM_ID}";

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
    }
}
