using Godot;
using System;

//Input type of componenet. Used for interfacing with other systems
	public class InputMask : Component{
		OutputMask output;
		bool isStarter = false;
		public InputMask(bool _isStarter, Alg _starterAlg) : base(){
			algOutputs.Add(_starterAlg);
			isStarter = _isStarter;
		}
		public void update(){
			if(isStarter){
				algOutputs[0].calculate();
			}
		}
	}
