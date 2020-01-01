using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Arcana.Dusts
{
    public class BaseDust : ModDust
    {
        private static readonly Random _random = new Random();

        public static float GetVariance()
        {
            return (float) _random.NextDouble() - 0.5F;
        }

        // doesn't have a sprite, this is a templating mechanism for dust that makes them all behave.. the way they're meant to/reduce code copying.
        public override bool Autoload(ref string name, ref string texture)
        {
            // only allow auto loading on derived classes, not this class.
            return GetType().IsSubclassOf(typeof(BaseDust));
        }

        public override void OnSpawn(Dust dust)
        {
            dust.alpha = 50;
            // random variance to position
            dust.position += new Vector2(dust.position.X + GetVariance(), dust.position.Y + GetVariance());
        }

        public override bool Update(Dust dust)
        {
            // dust.position += dust.velocity;
            dust.alpha += 50;
            dust.rotation += 60F;
            if (dust.alpha >= 250)
            {
                dust.active = false;
            }
            
            return false;
        }
    }
}