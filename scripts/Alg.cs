using Godot;
using System;
using System.Collections.Generic;
//class that represents component functions
public enum FunctionType{
		Null, Add, Sub, Mul, Div, Step, Var, Static
		}
public class Alg : DataObj{
	
		public Alg(string _name) : base(0)
		{
			type = FunctionType.Null;
			name = _name;
		}	
		public Alg(FunctionType _type, string _name) : this(_name){
			type = _type;
		}
		//recalculates the values of all algs that come after
		public void recalculate()
		{
			foreach(Alg target in targets){
				target.calculate();
			}	
		}
		//binds this alg to another alg's var list
		//and another alg to this alg's target list
		public void connectAlgs(Alg _target){
			targets.Add(_target);
			_target.addVar(this);
		}
		public void addVar(Alg _var){
			vars.Add(_var);
		}
		public string getName(){return name;}
		//performs the calculation for the algorithm depending on the type
		//the type being dictated by the type variable
		public void calculate()
		{
			switch(type){
				//does nothing
				case FunctionType.Null:
					val = 0;
					break;
				//functions as simple value storage
				case FunctionType.Var:
					if(vars.Count>0&&val!=vars[0].getVal()){
						val = vars[0].getVal();
						recalculate();
					}
					break;
				case FunctionType.Add:
					val = 0;
					for(int i=0;i<vars.Count;i++){
						val+=vars[i].getVal();
					}
					break;
				case FunctionType.Sub:
					break;
				//functions as a static value
				case FunctionType.Static:
					recalculate();
					break;
				default:
					break;
			}
				
		}
		protected string name;
		protected List<Alg> targets = new List<Alg>();		
		private	List<DataObj> vars = new List<DataObj>();
		private	FunctionType type;
	
		
	}
