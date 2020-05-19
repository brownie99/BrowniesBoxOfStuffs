using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BrowniesBoxOfStuffs.Projectiles
{
	public class Toast : ModProjectile
	{
		public override void SetDefaults() {
			projectile.width = 30;
			projectile.height = 30;
			drawOffsetX = -5;
			drawOriginOffsetY = -5;
			projectile.scale = 1f;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 300;
            projectile.velocity = new Vector2(0f,0.3f);
		}

        public override void AI()
        {
			projectile.ai[0] += 1f;
			if (projectile.ai[0] >= 5f)
			{
				projectile.ai[0] = 5f;
				projectile.velocity.Y = projectile.velocity.Y + 0.5f;
				if (projectile.velocity.Y > 16f) // This check implements "terminal velocity". We don't want the projectile to keep getting faster and faster. Past 16f this projectile will travel through blocks, so this check is useful.
				{
					projectile.velocity.Y = 16f;
				}
			}
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2; // projectile sprite faces up
			
		}

		public override bool OnTileCollide(Vector2 oldVelocity) {
			int dust1 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 0, default(Color), 1.3f);
			int dust2 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 0, default(Color), 1.3f);
			int dust3 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 0, default(Color), 1.3f);
			int dust4 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 0, default(Color), 1.3f);
			int dust5 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 0, default(Color), 1.3f);
			int dust6 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 0, default(Color), 1.3f);
			int dust7 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 0, default(Color), 1.3f);
			int dust8 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 0, default(Color), 1.3f);
			projectile.Kill();

			//else {
			//	projectile.ai[0] += 0.1f;
			//	if (projectile.velocity.X != oldVelocity.X) {
			//		projectile.velocity.X = -oldVelocity.X;
			//	}
			//	if (projectile.velocity.Y != oldVelocity.Y) {
			//		projectile.velocity.Y = -oldVelocity.Y;
			//	}
			//	projectile.velocity *= 0.75f;
			//	Main.PlaySound(SoundID.Item10, projectile.position);
				
			//}
			return false;
		}


		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.75f;
		}
	}
}