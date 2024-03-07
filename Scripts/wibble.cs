using Godot;
using System;

public partial class wibble : Area2D
{
	
	private AnimatedSprite2D _animation;
	private AudioStreamPlayer _victoryEffect;
	private Timer _timer;
	
	private void _on_despawn_timer_timeout()
	{
		// Replace with function body.
		CallDeferred("free");
	}
	
	private void _on_tree_entered()
	{
		// Replace with function body.
		_animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_animation.Play("wibble_active");
	}
	
	private void _on_area_2d_area_entered(Area2D area)
	{
		// Replace with function body.
		_victoryEffect = GetNode<AudioStreamPlayer>("Victory Effect");
		_victoryEffect.Play();
		_timer = GetNode<Timer>("Despawn Timer");
		_timer.Start();
	}
}
