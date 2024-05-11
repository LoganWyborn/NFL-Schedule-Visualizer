using Godot;
using System;

public partial class Team : Sprite2D
{
    [Export]
    public string TeamName { get; set; }
    public int thursCounter = 0;
    public int sunMornCounter = 0;
    public int sunAftCounter = 0;
    public int sunNightCounter = 0;
    public int monCounter = 0;
    public int intlCounter = 0;
    public override void _Draw()
    {
        int startHeight = -150;
        DrawRect(new Rect2(-100, startHeight, 200, -thursCounter*80), new Color("BLUE"));
        startHeight -= thursCounter*80;
        DrawRect(new Rect2(-100, startHeight, 200, -sunMornCounter*80), new Color("YELLOW"));
        startHeight -= sunMornCounter*80;
        DrawRect(new Rect2(-100, startHeight, 200, -sunAftCounter*80), new Color("ORANGE"));
        startHeight -= sunAftCounter*80;
        DrawRect(new Rect2(-100, startHeight, 200, -sunNightCounter*80), new Color("RED"));
        startHeight -= sunNightCounter*80;
        DrawRect(new Rect2(-100, startHeight, 200, -monCounter*80), new Color("GREEN"));
        startHeight -= monCounter*80;
        DrawRect(new Rect2(-100, startHeight, 200, -intlCounter*80), new Color("SILVER"));

        for(int height = -150; height > -1430; height -= 80)
        {
        	DrawRect(new Rect2(-100, height, 200, -80), new Color("BLACK"), false, 5);
        }

    }
}
