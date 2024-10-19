using Godot;
using System;
using System.Collections.Generic;
public class Component
	{
		 protected List<Alg> algInputs = new List<Alg>();
		 protected List<Alg> algOutputs = new List<Alg>();
		 public void addInput(string _name){
			algInputs.Add(new Alg(FunctionType.Var, _name));
		 }
		 public void addOutput(Alg new_output){
			algOutputs.Add(new_output);
		 }
		//connects another component's specified input alg to the
		//specified output alg on this component
		public void connectInput(Component comp, string input_name, string output_name){
			Alg input = comp.getInput(input_name);
			if(input!=null){
				algOutputs.Find(x=>x.getName()==output_name)
					.connectAlgs(input);
			}
		}
		public Alg getInput(string _name){
			return algInputs.Find(x=>x.getName()==_name);
		}
	}
