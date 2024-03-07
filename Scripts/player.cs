using Godot;
using System;

public partial class player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	private AnimatedSprite2D _animatedSprite;
	private AudioStreamPlayer _runEffect;
	private AudioStreamPlayer _jumpEffect;
	private AudioStreamPlayer _deathEffect;

	private int _tries = 0;
	private int _lives = 3;
	private int _idle = 1;
	

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
			_deathEffect.Play();
			if(_tries < _lives)
			{
				Position = new Vector2(95, 270);
				_tries += 1;
			}
			else 
			{
				_tries = 0;
				GetTree().ChangeSceneToFile("res://Scenes/Scene Management/lose.tscn");
			}
			
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
		_deathEffect = GetNode<AudioStreamPlayer>("Death Effect");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		
		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;
		
		// Jump
		if(Input.IsActionJustPressed("jump"))
		{
			_idle = 0;
			if(IsOnFloor())
			{
				velocity.Y = JumpVelocity;
				if(!_jumpEffect.Playing)
					_jumpEffect.Play();
			}
			
			if(Input.IsActionPressed("move_right"))
			{
				velocity.X = 1 * Speed;
				_animatedSprite.FlipH = false;
			}
			
			if(Input.IsActionPressed("move_left"))
			{
				velocity.X = -1 * Speed;
				_animatedSprite.FlipH = false;
			}
			
		}
		// Run
		else if(Input.IsActionPressed("move_left"))
		{
			_idle = 0;
			velocity.X = -1 * Speed;
			_animatedSprite.FlipH = true;
			_animatedSprite.Play("Omar Run");
			if(!_runEffect.Playing)
				_runEffect.Play();
		}
		else if(Input.IsActionPressed("move_right"))
		{
			_idle = 0;
			velocity.X = 1 * Speed;
			_animatedSprite.FlipH = false;
			_animatedSprite.Play("Omar Run");
			if(!_runEffect.Playing)
				_runEffect.Play();
		}
		// Idle
		else
		{
			_idle = 1;
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			_animatedSprite.Stop();
			_runEffect.Stop();
		}
		
		// Idle Check
		if (_idle == 1)
		{
			_animatedSprite.Play("Omar");
		}
		
		// Idle Check
		if (velocity.Y != 0)
		{
			_animatedSprite.Play("Omar Jump");
		}
		
		Velocity = velocity;
		MoveAndSlide();
	}
}
