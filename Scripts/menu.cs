using Godot;
using System;

public partial class menu : Control
{
	private void _on_start_button_pressed()
	{
		// Replace with function body.
		GetTree().ChangeSceneToFile("res://Scenes/Scene Management/introduction.tscn");
	}

	private void _on_quit_button_pressed()
	{
		// Replace with function body.
		GetTree().Quit();
	}
}
