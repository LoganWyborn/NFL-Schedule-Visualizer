using Godot;
using System;
using System.Linq;

public partial class Main : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(!FileAccess.FileExists("schedule.txt"))
		{
			GD.Print("File at 'schedule.txt' not found, unable to load level data.");
			return;
		}
		using var fileReader = FileAccess.Open("schedule.txt", FileAccess.ModeFlags.Read);
		
		Godot.Collections.Array<Node> children = GetChildren();

		int day = 0;
		while(fileReader.GetPosition() < fileReader.GetLength())
		{
			string line = fileReader.GetLine();
			if(line.Contains("Bye week:"))
				continue;
			
			if(line.Contains("Thursday"))
			{
				day = 1;
				continue;
			}
			else if(line.Contains("Sunday"))
			{
				day = 2;
				continue;
			}
			else if(line.Contains("Monday"))
			{
				day = 3;
				continue;
			}

			foreach(Node child in children)
			{
				if(child is Team team && line.Contains(team.TeamName))
				{
					if(day == 1)
					{
						team.thursCounter++;
						continue;
					}
					else if(day == 2)
					{
						if(line.Contains("1 p.m."))
						{
							team.sunMornCounter++;
							continue;
						}
						else if(line.Contains("4:05 p.m.") || line.Contains("4:25 p.m."))
						{
							team.sunAftCounter++;
							continue;
						}
						else if(line.Contains("8:15 p.m.") || line.Contains("8:20 p.m."))
						{
							team.sunNightCounter++;
							continue;
						}
					}
					else if(day == 3)
					{
						team.monCounter++;
						continue;
					}

					GD.Print("Assuming international/other on line: ");
					GD.Print(line);
					team.intlCounter++;
				}
			}
		}
		foreach(Node child in children)
		{
			if(child is Team team)
			{
				GD.Print(team.TeamName + ": \nThursday: " + team.thursCounter + ", Morning: " + team.sunMornCounter + ", Afternoon: " + team.sunAftCounter + ", Night: " + team.sunNightCounter + ", Monday: " + team.monCounter + ", International: " + team.intlCounter);
			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
