using Godot;
using System;
using System.Collections.Generic;

public partial class interpreter : Node2D
{
	[Export]
	Dictionary<string, float> values = new Dictionary<string, float>();
	float Frequency = 1;
	float delay;
	float currDelay;
	List<InputMask> InputLayer = new List<InputMask>();
	//the types of functions
	  
	public enum FunctionType{
		Null, Add, Sub, Mul, Div, Step, Var, Static
	}
	//parent class for the Alg
	public class DataObj{
			
		public void setVal(float _val){val = _val;}
		public float getVal(){return val;}
		protected float val;
		protected DataObj(float newVal){val = newVal;}
	}
	//class that represents component functions
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
	//Output type of a component. used for interfacing with other systems
	public class OutputMask : Component{
		string output;
		public void linkOutput( string _output){
			output = _output;
		}
	}
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
