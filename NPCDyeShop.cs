using System.Drawing;
using System.Collections;

public class DyeSellerScript : NpcScript
{
	public override void Load()
	{
		SetRace(10001);
		SetName("Dye Seller");
		//SetFace(skinColor: 20, eyeType: 139, eyeColor: 28, mouthType: 2);

        //SetBody(height: 1.2f, weight: 0.8f);
        //SetFace(skinColor: 16, eyeType: 219, eyeColor: 31, mouthType: 70);
        //SetStand("chapter4/giant/female/anim/giant_female_c4_npc_tamon");
        //SetFace(skinColor: 20, eyeColor: 27);



        SetBody(height: 0f, weight: 0.8f);
        SetFace(skinColor: 20, eyeType: 139, eyeColor: 28, mouthType: 2);
        SetStand("chapter4/human/anim/social_motion/female_queen");
		SetLocation(14, 38003, 39567, 195);

		EquipItem(Pocket.Face, 3900, 0x00FBBC58, 0x00F79D2F, 0x00014E9C);
        EquipItem(Pocket.Head, 18391, 0x00FFffff, 0x00FFffff, 0x00FFffff);
        EquipItem(Pocket.Hair, 3137, 0x00211c39, 0x00211c39, 0x00211c39);
		EquipItem(Pocket.Armor, 80750, 0x00ffffff, 0x00000000, 0x00000000);
		EquipItem(Pocket.Shoe, 17390, 0x00000000, 0x00000000, 0x00000000);

		AddPhrase("Hey Kid, Wanna buy some dyes?..");
		AddPhrase("Reds, Blues, Purples, Greens, any color you need, we have it!");
	}

	protected override async Task Talk()
	{
		Msg("What can I do for you?");
		OpenShop("DyeSellerShop");
	}
}

public class DyeSellerShop : NpcShopScript
{
	public override void Setup()
	{
		List<uint> colorList = new List<uint>();

        uint color = 0x000000;
        for(uint i = 0; i < 6; i++) {
            for(uint k = 0; k < 6; k++) {
                color = 0x000000 + (0x003300 * k) + (0x330000 * i);
                for(int l = 0; l < 6; l++) {
                    colorList.Add(color);
                    color+=51;
                }

            }
        }

        colorList.Sort((x, y) => Color.FromArgb(Convert.ToInt32(x)).GetHue().CompareTo(Color.FromArgb(Convert.ToInt32(y)).GetHue()));
        List<uint> colorListRed = new List<uint>();
        List<uint> colorListBlue = new List<uint>();
        List<uint> colorListGreen = new List<uint>();
        List<uint> colorListPurple = new List<uint>();
        //for(int i = 0; i < colorList.Count; i++) {
        //    Add("Red Dyes", 63030, colorList[i], colorList[i], colorList[i], 0);
        //}

        for(int i = 0; i < 42; i++) {
            colorListRed.Add(colorList[i]);
        }

        for(int i = 42; i < 111; i++) {
            colorListGreen.Add(colorList[i]);
        }

        for(int i = 111; i < 159; i++) {
            colorListBlue.Add(colorList[i]);
        }

        for(int i = 159; i < 196; i++) {
            colorListPurple.Add(colorList[i]);
        }

        for(int i = 196; i < 216; i++) {
            colorListRed.Add(colorList[i]);
        }

        colorListRed.Sort((x, y) => Color.FromArgb(Convert.ToInt32(x)).GetBrightness().CompareTo(Color.FromArgb(Convert.ToInt32(y)).GetBrightness()));
        colorListGreen.Sort((x, y) => Color.FromArgb(Convert.ToInt32(x)).GetBrightness().CompareTo(Color.FromArgb(Convert.ToInt32(y)).GetBrightness()));
        colorListBlue.Sort((x, y) => Color.FromArgb(Convert.ToInt32(x)).GetBrightness().CompareTo(Color.FromArgb(Convert.ToInt32(y)).GetBrightness()));
        colorListPurple.Sort((x, y) => Color.FromArgb(Convert.ToInt32(x)).GetBrightness().CompareTo(Color.FromArgb(Convert.ToInt32(y)).GetBrightness()));

        for(int i = 0; i < colorListRed.Count; i++) {
            Add("Red Dyes", 63030, colorListRed[i], colorListRed[i], colorListRed[i], 0);
            Add("Metal Red Dyes", 63255, colorListRed[i], colorListRed[i], colorListRed[i], 0);
        }

        for(int i = 0; i < colorListGreen.Count; i++) {
            Add("Green Dyes", 63030, colorListGreen[i], colorListGreen[i], colorListGreen[i], 0);
            Add("Metal Green Dyes", 63255, colorListGreen[i], colorListGreen[i], colorListGreen[i], 0);
        }

        for(int i = 0; i < colorListBlue.Count; i++) {
            Add("Blue Dyes", 63030, colorListBlue[i], colorListBlue[i], colorListBlue[i], 0);
            Add("Metal Blue Dyes", 63255, colorListBlue[i], colorListBlue[i], colorListBlue[i], 0);
        }

        for(int i = 0; i < colorListPurple.Count; i++) {
            Add("Purple Dyes", 63030, colorListPurple[i], colorListPurple[i], colorListPurple[i], 0);
            Add("Metal Purple Dyes", 63255, colorListPurple[i], colorListPurple[i], colorListPurple[i], 0);
        }
	}
}
