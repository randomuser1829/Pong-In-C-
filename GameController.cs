using System;
using System.Drawing;

public sealed class GameController
{
	public static GameController Instance;
	
	public int score1;
	public int score2;
	
	public Paddle paddle1;
	public Paddle paddle2;
	
	Ball ball;
	
	public GameController()
	{
		Instance = this;
		
		paddle1 = new Paddle(PaddleSide.Left);
		paddle2 = new Paddle(PaddleSide.Right);
		
		ball = new Ball();
		
		score1 = 0;
		score2 = 0;
	}
	
	public void Tick()
	{
		paddle1.Tick();
		paddle2.Tick();
		
		ball.Tick();
	}
	
	public void Draw(Graphics g)
	{
		// just for debugging.
		//g.FillRectangle(Brushes.Gray, MainForm.width/2-16, 0, 16, 600);
	
		g.DrawString(score1.ToString(), new Font("Arial.ttf", 69), Brushes.White, new PointF(MainForm.width/2-160, 20));
		g.DrawString(score2.ToString(), new Font("Arial.ttf", 69), Brushes.White, new PointF(MainForm.width/2+60, 20));
		
		int p1 = 24;
		int p2 = 128;
		
		g.FillRectangle(Brushes.White, paddle1.x-(p1/2), paddle1.y-(p2/2), p1, p2);
		g.FillRectangle(Brushes.White, paddle2.x-(p1/2), paddle2.y-(p2/2), p1, p2);
		
		int a1 = ball.size;
		int a2 = ball.size;
		
		g.FillEllipse(Brushes.White, 
			new RectangleF(ball.x-(a1/2), ball.y-(a2/2), a1, a2));
	}
	
	public void AddScore(PaddleSide side)
	{
		if(side == PaddleSide.Left) score1++;
		else if(side == PaddleSide.Right) score2++;
		
		ball.x = MainForm.width/2-(ball.size/3f);
		ball.y = MainForm.height/2-(ball.size/3f);
		
		ball.velX = 10f;
		ball.velY = 5f;
	}
}
