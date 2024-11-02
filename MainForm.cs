using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

public sealed class MainForm : Form
{
	public static int width = 800;
	public static int height = 600;
	
	Graphics g;
	PictureBox p;
	
	public MainForm()
	{
		GameCmd.Init();
		
		p = new PictureBox();
		p.Size = new Size(width, height);
		p.Image = new Bitmap(width, height);
		p.Paint += OnPaint;
		g = Graphics.FromImage(p.Image);
		
		Controls.Add(p);
		
		Size = new Size(width, height);
		Text = "SharpPong";
		
		KeyDown += OnKeyDown;
		KeyUp += OnKeyUp;
		Closed += WriteScoreText;
		
		new GameController();
		
		Timer timer = new Timer();
		timer.Interval = 1000/35;
		timer.Tick += OnTick;
		timer.Start();
	}
	
	void WriteScoreText(object s, EventArgs e)
	{
		string wholething = string.Format("Player 1 Score: {0} Player 2 Score: {1}", GameController.Instance.score1, GameController.Instance.score2);
		File.WriteAllText("./score.txt", wholething);
	}
	
	public void Exit()
	{
		string wholething = string.Format("Player 1 Score: {0} Player 2 Score: {1}", GameController.Instance.score1, GameController.Instance.score2);
		File.WriteAllText("./score.txt", wholething);
		
		Close();
	}
	
	void OnKeyDown(object s, KeyEventArgs e)
	{
		if(e.KeyCode == Keys.Escape) Exit();
		
		if(e.KeyCode == Keys.W) GameCmd.ActivateCmd("paddle1up");
		if(e.KeyCode == Keys.S) GameCmd.ActivateCmd("paddle1down");
		if(e.KeyCode == Keys.Up) GameCmd.ActivateCmd("paddle2up");
		if(e.KeyCode == Keys.Down) GameCmd.ActivateCmd("paddle2down");
	}
	
	void OnKeyUp(object s, KeyEventArgs e)
	{
		if(e.KeyCode == Keys.W) GameCmd.DeactivateCmd("paddle1up");
		if(e.KeyCode == Keys.S) GameCmd.DeactivateCmd("paddle1down");
		if(e.KeyCode == Keys.Up) GameCmd.DeactivateCmd("paddle2up");
		if(e.KeyCode == Keys.Down) GameCmd.DeactivateCmd("paddle2down");
	}
	
	void OnTick(object s, EventArgs e)
	{
		GameController.Instance.Tick();
		
		Refresh();
	}
	
	void OnPaint(object s, PaintEventArgs e)
	{
		g.FillRectangle(Brushes.Black, 0, 0, width, height);
		
		GameController.Instance.Draw(g);
	}
}
