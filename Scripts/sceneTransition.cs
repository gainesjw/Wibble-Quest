using Godot;
using System;

public partial class sceneTransition : Control
{
	
	private void _on_timer_fade_in_timeout()
	{
		// Replace with function body.
		var animation = GetNode<AnimationPlayer>("AnimationPlayer");
		animation.Play("fade_to_blank");
	}


	private void _on_timer_fade_out_timeout()
	{
		// Replace with function body.
		var animation = GetNode<AnimationPlayer>("AnimationPlayer");
		animation.Play("fade_to_black");
	}
	
}






