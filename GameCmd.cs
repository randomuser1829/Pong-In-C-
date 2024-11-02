using System;
using System.Collections.Generic;
using System.Windows.Forms;

public static class GameCmd
{
	public static List<CmdThing> cmdThings = new List<CmdThing>();
	
	public static void Init()
	{
		CmdThing cmd01 = new CmdThing() {name="paddle1up"};
		CmdThing cmd02 = new CmdThing() {name="paddle1down"};
		CmdThing cmd03 = new CmdThing() {name="paddle2up"};
		CmdThing cmd04 = new CmdThing() {name="paddle2down"};
		
		cmdThings.Add(cmd01);
		cmdThings.Add(cmd02);
		cmdThings.Add(cmd03);
		cmdThings.Add(cmd04);
	}
	
	public static void ActivateCmd(string name)
	{
		for(int i = 0; i < cmdThings.Count; i++)
		{
			if(cmdThings[i].name == name) cmdThings[i].active = true;
		}
	}
	
	public static void DeactivateCmd(string name)
	{
		for(int i = 0; i < cmdThings.Count; i++)
		{
			if(cmdThings[i].name == name) cmdThings[i].active = false;
		}
	}
	
	public static bool GetCmd(string name)
	{
		foreach(var cmd in cmdThings)
		{
			if(cmd.name == name) return cmd.active;
		}
		
		return false;
	}
}

[Serializable]
public class CmdThing
{
	public string name;
	public bool active;
}
