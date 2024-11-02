using System;
using System.Drawing;

public class Ball
{
	public float x;
	public float y;
	
	public int size;
	
	public float velX;
	public float velY;
	
	public RectangleF rect;
	
	public Ball()
	{
		size = 32;
		
		x = MainForm.width/2-(size/3f);
		y = MainForm.height/2-(size/3f);
		
		velX = 10f;
		velY = 5f;
		
		rect = new RectangleF(x, y, size, size);
	}
	
	public void Tick()
	{
		x += velX;
		y -= velY;
		
		rect = new RectangleF(x-(size/2), y-(size/2), size, size);
		
		if(y <= 8 && velY > 0) velY = -velY;
		if(y >= MainForm.height-(size*2-8) && velY < 0) velY = -velY;
		
		if(rect.IntersectsWith(GameController.Instance.paddle1.rect) && velX < 0) velX = -velX;
		if(rect.IntersectsWith(GameController.Instance.paddle2.rect) && velX > 0) velX = -velX;
		
		if(x > MainForm.width-(size*2-8)) GameController.Instance.AddScore(PaddleSide.Left);
		if(x < 8) GameController.Instance.AddScore(PaddleSide.Right);
	}
}
