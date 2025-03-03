using Godot;
using System;
using System.Collections.Generic;
public abstract class Component
	{
		Vector<Component> input_components;
		Vector<Component> output_components;
		Vector<Alg> outputAlgs;
		Vector<Alg> inputAlgs;
		void set_outputs(int index, float val){
				
		}
		protected abstract void process_outputs();
		protected virtual void set_inputs(int index, float val){}
	}
