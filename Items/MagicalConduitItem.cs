using System.Collections.Generic;
using Arcana.Enums.DeliveryMechanism;
using Arcana.Reference;
using Arcana.Spells;
using Arcana.Spells.DeliveryMechanisms;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using WebmilioCommons.Items.Standard;
using Projectile = Arcana.Spells.DeliveryMechanisms.Projectile;

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

        public MagicalConduitItem() : this("Magical Conduit", "This is a test conduit.", _referenceItem)
        {
        }

        public MagicalConduitItem(string displayName, string tooltip, Entity terrariaItemUsedAsConduit) : base(displayName, tooltip, terrariaItemUsedAsConduit.width, terrariaItemUsedAsConduit.height, 0, 0, -12, 1)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.useTime = 3;
            item.useAnimation = GetReferenceItem().useAnimation;
            item.useStyle = GetReferenceItem().useStyle;
            item.noMelee = true;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
        }

        public override string Texture => $"Terraria/Item_{REFERENCE_ITEM_ID}";

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
            DeliveryMechanism deliveryMechanism = new DeliveryMechanism()
            {
                Corporeal = Corporeal.Corporeal,
                CascadeDelay = 2,
                CascadeMechanisms = new List<DeliveryMechanism>(),
                Effects = new List<ArcaneEffect>()
                {
                    DebugPrefab.BasicFireDamage
                },
                CollisionBehavior = CollisionBehavior.None,
                Target = Target.Enemy,
                Gravity = Gravity.NoGravity,
                Seeking = Seeking.None,
                ChargeTime = 0,
                CollisionLimit = 1,
                Cooldown = 5,
                Count = 1,
                EffectDelay = 0,
                IsRootMechanism = true,
                MechanismTypeType = DeliveryMechanismTypeLoader.Instance.GetGeneric<Projectile>(),
                Repeat = 0,
                RepeatDelay = 0,
                Scale = 1.0F,
                Speed = 60.0F,
                Spread = 15.0F,
                DominantDustType = 6
            };
            Vector2 velocity = (Main.MouseWorld - player.Center);
            velocity.Normalize();
            ArcaneEvent arcaneEvent = new ArcaneEvent(deliveryMechanism, player.Center, velocity);
            ArcanaWorld world = ModContent.GetInstance<ArcanaWorld>();
            world.AddArcaneEvent(arcaneEvent);
            return base.UseItem(player);
        }
    }
}
