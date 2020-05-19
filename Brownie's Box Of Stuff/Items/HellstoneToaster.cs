using BrowniesBoxOfStuffs.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
namespace BrowniesBoxOfStuffs.Items
{
    class HellstoneToaster : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("You burnt the toast!?");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 40;
			item.magic = true;
			item.mana = 12;
			item.width = 80;
			item.height = 80;
			item.scale = 0.5f;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 100;
			item.rare = 2;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ProjectileType<BurntToast>();
			item.shootSpeed = 16f;

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 12);
			recipe.AddIngredient(ItemID.Obsidian, 10);
			recipe.AddIngredient(mod, "Toaster");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
