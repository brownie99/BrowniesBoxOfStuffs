using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Enums;
using static Terraria.ModLoader.ModContent;

namespace BrowniesBoxOfStuffs.Projectiles
{
    class GhostToast : ModProjectile
    {
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			drawOffsetX = -5;
			drawOriginOffsetY = -5;
			projectile.scale = 1f;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 300;
			projectile.velocity = new Vector2(0f, 0.3f);
		}

		public override void AI()
		{
			projectile.ai[0] += 1f;
			if (projectile.ai[0] >= 5f)
			{
				projectile.ai[0] = 5f;
				projectile.velocity.Y = projectile.velocity.Y + 0.5f;
				if (projectile.velocity.Y > 16f)
				{
					projectile.velocity.Y = 16f;
				}
			}
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
			Lighting.AddLight(projectile.position, 0.2f, 0.5f, 0.8f);
			int dust1 = Dust.NewDust(projectile.position, 40, 40, 229, 0f, 0f, 0, default(Color), 1.3f);

		}


		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			int dust1 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 0, default(Color), 1.3f);
			int dust2 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 0, default(Color), 1.3f);
			int dust3 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 0, default(Color), 1.3f);
			int dust4 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 0, default(Color), 1.3f);
			int dust5 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 0, default(Color), 1.3f);
			int dust6 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 0, default(Color), 1.3f);
			int dust7 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 0, default(Color), 1.3f);
			int dust8 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 0, default(Color), 1.3f);
			projectile.Kill();

			return false;
		}


		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.75f;
		}
	}
}
