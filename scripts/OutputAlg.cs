using Godot;
using System;

public partial class OutputAlg : Alg
{
	public override float process_inputs(){
		return inputs[0].process_inputs();
	}
}
