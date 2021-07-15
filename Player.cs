using Godot;
using System;

public class Player : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    // private Vector2 position;
    private float force;
    private Vector2 direction;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        force = 10 * delta;
        MoveAndCollide(direction);
        direction = new Vector2(0, 0);
    }
    public override void _Input(InputEvent inputEvent)
    {
        if (inputEvent is InputEventKey keyEvent)
        {
            int amount = 10;
            var direction = new Vector2();
            if ((KeyList)keyEvent.Scancode == KeyList.Right)
                direction = new Vector2(amount, 0);
            //this.Position += new Vector2(amount, 0);
            if ((KeyList)keyEvent.Scancode == KeyList.Down)
                direction = (new Vector2(0, amount));
            //this.Position += new Vector2(0, amount);
            if ((KeyList)keyEvent.Scancode == KeyList.Left)
                direction = (new Vector2(-amount, 0));
            //this.Position += new Vector2(-amount, 0);
            if ((KeyList)keyEvent.Scancode == KeyList.Up)
                direction = (new Vector2(0, -amount));
            //this.Position += new Vector2(0, -amount);
            direction.y += force;

        }

        base._Input(inputEvent);
    }
}

