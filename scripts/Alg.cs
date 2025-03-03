using Godot;
using System;
using System.Collections.Generic;
//class that represents component functions
public enum FunctionType{
		Null, Add, Sub, Mul, Div, Step, Var, Static
		}
public abstract class Alg{
	protected List<float> inputs;
	protected List<Alg> inputTargets;
	protected float outputs;
	protected Alg[] outputTargets;
	public void addInputAlg(Alg newAlg){
		inputTargets.Add(newAlg);
	}
	public void processInputAlg(Alg inputAlg, float val){
		for(int i=0;i<inputTargets.Length;i++);
			if (inputTargets[i]==inputAlg){
				inputs[i]=val;
			}
	}
	
	public abstract float process_inputs();
	public void set_inputs(float[] _inputs){
		inputs = _inputs;
	}
	
	
}
public class Alg_Add : Alg{
	public override float process_inputs(){
		
		float temp_input = 0;
		for(int i=0;i< inputs.Length;i++){
			temp_input+=inputs[i];
		}
		return temp_input;
	}
}
