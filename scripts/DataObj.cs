using Godot;
using System;

//parent class for the Alg
	public class DataObj{
			
		public void setVal(float _val){val = _val;}
		public float getVal(){return val;}
		protected float val;
		protected DataObj(float newVal){val = newVal;}
	}
	
