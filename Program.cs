using System;
using System.Windows.Forms;

internal sealed class Program
{
	[STAThread]
	static void Main(string[] args)
	{
		Application.EnableVisualStyles();
		Application.Run(new MainForm());
	}
}
