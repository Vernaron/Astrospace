using Godot;
using System;

//Output type of a component. used for interfacing with other systems
	public class OutputMask : Component{
		Component previousComponent;
		public float get_value(){
			return previousComponent.get_value();
		}
	}
	
	
