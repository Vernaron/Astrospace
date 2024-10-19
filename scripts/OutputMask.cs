using Godot;
using System;

//Output type of a component. used for interfacing with other systems
	public class OutputMask : Component{
		string output;
		public void linkOutput( string _output){
			output = _output;
		}
	}
	
	
