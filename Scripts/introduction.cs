using Godot;
using System;

public partial class introduction : Control
{
	private void _on_timer_timeout()
	{
		GetTree().ChangeSceneToFile("res://Scenes/Scene Management/world.tscn");
	}
}
