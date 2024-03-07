using Godot;
using System;

public partial class portal : Area2D
{
	
	private AnimatedSprite2D _animation;
	private AudioStreamPlayer _teleportEffect;
	
	private void _on_tree_entered()
	{
		// Replace with function body.
		_animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_animation.Play("portal_active");
	}
	
	private void _on_area_2d_area_entered(Area2D area)
	{
		// Replace with function body.
		_teleportEffect = GetNode<AudioStreamPlayer>("Teleport Effect");
		_teleportEffect.Play();
		GD.Print("test");
	}
}
