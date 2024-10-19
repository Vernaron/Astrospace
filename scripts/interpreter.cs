using Godot;
using System;
using System.Collections.Generic;
public partial class Interpreter : Node2D
{
	[Export]
	Godot.Collections.Dictionary<string, float> values = new Godot.Collections.Dictionary<string, float>();
	float Frequency = 1;
	float delay;
	float currDelay;
	List<InputMask> InputLayer = new List<InputMask>();
	//the types of functions
	Resource Alg = ResourceLoader.Load("res://scripts/Alg.cs");
	public Component tempComp;
	
	
	
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		delay = 1/Frequency;
		currDelay = 0;
		Alg tempAlg = new Alg(FunctionType.Static, "temp");
		tempAlg.setVal(3.0f);
		InputMask tempInput = new InputMask(true, tempAlg);
		tempComp = new Component();
		tempComp.addInput("tempInput");
		tempInput.connectInput(tempComp, "tempInput", "temp");
		InputLayer.Add(tempInput);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	currDelay+=(float)delta;
	if (currDelay > delay){
		currDelay = 0;
		foreach(InputMask i in InputLayer){
			i.update();
			GD.Print(tempComp.getInput("tempInput").getVal());
		} 
		
		GD.Print("Looped");
	}
	}
}
