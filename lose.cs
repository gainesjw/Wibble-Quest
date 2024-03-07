using Godot;
using System;

public partial class lose : Control
{
private void _on_timer_timeout()
	{
		GetTree().ChangeSceneToFile("res://Scenes/Scene Management/menu.tscn");
	}
}
