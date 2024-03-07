using Godot;
using System;

public partial class player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	private AnimatedSprite2D _animatedSprite;
	private AudioStreamPlayer _runEffect;
	private AudioStreamPlayer _jumpEffect;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	private void _on_area_2d_area_entered(Area2D area)
	{
		// Replace with function body.
		if(area.IsInGroup("portal_0"))
		{
			Position = new Vector2(2340, 790);
		}
		
		// Replace with function body.
		if(area.IsInGroup("portal_1"))
		{
			Position = new Vector2(6230, 725);
		}
		
		if(area.IsInGroup("death"))
		{
			Position = new Vector2(95, 270);
		}
		
		if(area.IsInGroup("win"))
		{
			GetTree().ChangeSceneToFile("res://Scenes/Scene Management/endgame.tscn");
		}
		
	}

	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_runEffect = GetNode<AudioStreamPlayer>("Run Effect");
		_jumpEffect = GetNode<AudioStreamPlayer>("Jump Effect");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		
		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;
		
		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		float inputX = Input.GetAxis("move_left", "move_right");
		Vector2 direction = new Vector2(inputX, 0);
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			_animatedSprite.Play("Omar Run");
			
			if(_runEffect.Playing != true)
			{
				_runEffect.Play();
			}
			
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			_animatedSprite.Stop();
			_runEffect.Stop();
		}
		
		if (direction == Vector2.Zero)
		{
			_animatedSprite.Play("Omar");
		}
		
		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
			_animatedSprite.Play("Omar Jump");
			if(_jumpEffect.Playing != true)
			{
				_jumpEffect.Play();
			}
		}
		
		Velocity = velocity;
		MoveAndSlide();
	}
}
