using System;
using System.Drawing;

public class Paddle
{
	public float x;
	public float y;
	
	public PaddleSide side;
	
	const float SPEED = 20;
	
	public RectangleF rect;
	
	public Paddle(PaddleSide side)
	{
		this.side = side;
		
		if(this.side == PaddleSide.Left) 		x = 40;
		else if(this.side == PaddleSide.Right) 	x = MainForm.width-60;
		
		y = MainForm.height/2;
		
		rect = new RectangleF(x, y, 24, 128);
	}
	
	public void Tick()
	{
		if(GameCmd.GetCmd("paddle1up") && side == PaddleSide.Left) y -= SPEED;
		if(GameCmd.GetCmd("paddle1down") && side == PaddleSide.Left) y += SPEED;
		
		if(GameCmd.GetCmd("paddle2up") && side == PaddleSide.Right) y -= SPEED;
		if(GameCmd.GetCmd("paddle2down") && side == PaddleSide.Right) y += SPEED;
		
		rect = new RectangleF(x-(24/2), y-(128/2), 24, 128);
	}
}

public enum PaddleSide
{
	Null = 0,
	Left = 1,
	Right = 2
}
