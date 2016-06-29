using System.Drawing;
using System.Collections;

public class CardSellerScript : NpcScript
{
	public override void Load()
	{
		SetRace(10002);
		SetName("Card Seller");
		SetFace(skinColor: 20, eyeColor: 27);
		SetLocation(14, 38103, 39567, 195);

		EquipItem(Pocket.Face, 4900, 0xF88B4A);
		EquipItem(Pocket.Hair, 4154, 0x4D4B53);
		//EquipItem(Pocket.Robe, 95044, 0x00000000, 0x00FFFFFF, 0x00000000);
		EquipItem(Pocket.Shoe, 17012, 0x00000000, 0x00000000, 0x00000000);

		AddPhrase("Get your character cards, hot fresh character cards.");
		AddPhrase("You look like someone interested in a bargain.");
	}

	protected override async Task Talk()
	{
		Msg("What can I do for you?");
		OpenShop("CardSellerShop");
	}
}

public class CardSellerShop : NpcShopScript
{
	public override void Setup()
	{
        Add("Character Cards", 92042, 1, 0); // Human
		Add("Character Cards", 92058, 1, 0); // Elf
		Add("Character Cards", 92072, 1, 0); // Giant
	}
}
