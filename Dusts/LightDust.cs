using Terraria;
using Terraria.ModLoader;

namespace Arcana.Dusts
{
    public class LightDust : ModDust
    {
        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            return false;
        }
    }
}