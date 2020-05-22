using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Modules;
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
			//drawOffsetX = -5;
			projectile.scale = 1f;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 180;
			projectile.velocity = new Vector2(0f, 1.5f);
			projectile.tileCollide = false;
		}

		float acel = 1.2f;
		float maxSpeed = 5f;
		public override void AI()
		{
			float randVel = Main.rand.Next(5);
			projectile.ai[0] += 1f;
			if (projectile.ai[0] >= 10f)
			{
				projectile.ai[0] = 5f;
				//mPos = Main.mouseWorld;//get the mouses position in the world
				NPC targPos = FindNearest(projectile.position); //Find the thing I want to home in on -- use your target's position instead
				if (targPos != null && Math.Sqrt(Math.Abs(targPos.position.X - projectile.position.X) + Math.Abs(targPos.position.Y - projectile.position.Y)) < 20f) 
				{
					float toMouse = (float)Math.Atan2(targPos.position.Y - projectile.position.Y, targPos.position.X - projectile.position.X); //calculate a bearing to that thing


					if (Main.player[projectile.owner].gravDir == -1f) //if my player is upside down
						targPos.position.Y = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY;//reverse the vertical position of my mouse

					//accelerate towards my target
					projectile.velocity.X += (float)Math.Cos(toMouse) * acel * randVel; //acel is a float that controls how fast the projectile accelerates. randVel is a random modifier to the acceleration.
					projectile.velocity.Y += (float)Math.Sin(toMouse) * acel * randVel;

					if (Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y) > maxSpeed) //if going too fast
					{
						//Main.NewText("Max!");
						projectile.velocity *= 1 - (acel / maxSpeed); //slow down a little bit
					}
				}
				else
				{
					
					projectile.velocity.Y = projectile.velocity.Y + 1f;
					if (Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y) > maxSpeed + 2)
					{
						projectile.velocity*= 1 - (acel / (maxSpeed + 2));
					}
				}
			}
			
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
			Console.WriteLine("AI[0]: " + projectile.ai[0]);
			if (projectile.ai[1] == 0 && projectile.owner == Main.myPlayer)
			{
				Console.WriteLine("Adding projectile");
				projectile.ai[1] = 1;
				float tmpY = projectile.position.Y;
				float tmpX = projectile.position.X;
				Projectile.NewProjectile(projectile.position.X + projectile.width / 2, tmpY + 20f + projectile.height, Vector2.Normalize(new Vector2 (projectile.velocity.X + (2.5f * (projectile.velocity.X / Math.Abs(projectile.velocity.X))), projectile.velocity.Y)).X * (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y), Vector2.Normalize(new Vector2(projectile.velocity.X + (2.5f * (projectile.velocity.X / Math.Abs(projectile.velocity.X))), projectile.velocity.Y)).Y * (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y), projectile.type, projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 1f);
				Projectile.NewProjectile(projectile.position.X + projectile.width / 2, tmpY - 20f, Vector2.Normalize(new Vector2(projectile.velocity.X - (2.5f * (projectile.velocity.X/Math.Abs(projectile.velocity.X))), projectile.velocity.Y)).X * (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y), Vector2.Normalize(new Vector2(projectile.velocity.X - (2.5f * (projectile.velocity.X / Math.Abs(projectile.velocity.X))), projectile.velocity.Y)).Y * (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y), projectile.type, projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 1f);

			}
			Lighting.AddLight(projectile.position, 0.1f, 0.3f, 0.6f);
			if (projectile.ai[0] % 5 == 0)
			{
				int dust1 = Dust.NewDust(projectile.position, 40, 40, 229, 0f, 0f, 0, default(Color), 1.3f);
			}

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
			int dust1 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 100, default(Color), 1.3f);
			int dust2 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 100, default(Color), 1.3f);
			int dust3 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 100, default(Color), 1.3f);
			int dust4 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 100, default(Color), 1.3f);
			int dust5 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 100, default(Color), 1.3f);
			int dust6 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 100, default(Color), 1.3f);
			int dust7 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 100, default(Color), 1.3f);
			int dust8 = Dust.NewDust(projectile.position, 4, 4, 0, 0f, 0f, 100, default(Color), 1.3f);
		}

		public NPC FindNearest(Vector2 pos)
		{
			NPC nearest = null;
			float oldDist = 1001;
			float newDist = 1000;
			for (int i = 0; i < Terraria.Main.npc.Length - 1; i++) //Do once for each NPC in the world
			{
				if (Terraria.Main.npc[i].friendly == true)//Don't target town NPCs
					continue;
				if (Terraria.Main.npc[i].active == false)//Don't target dead NPCs
					continue;
				if (Terraria.Main.npc[i].damage == 0)//Don't target non-aggressive NPCs
					continue;
				if (nearest == null) //if no NPCs have made it past the previous few checks
					nearest = Terraria.Main.npc[i]; //become the nearest NPC
				else
				{
					oldDist = Vector2.Distance(pos, nearest.position);//Check the distance to the nearest NPC that's earlier in the loop
					newDist = Vector2.Distance(pos, Terraria.Main.npc[i].position);//Check the distance to the current NPC in the loop
					if (newDist < oldDist)//If closer than the previous NPC in the loop
						nearest = Terraria.Main.npc[i];//Become the nearest NPC
				}
			}
			return nearest; //return the npc that is nearest to the vector 'pos'
		}
	}

	

}
