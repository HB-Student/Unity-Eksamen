public class wizard : hero
{
	public override void decide()
	{
		if (scan("monster")){
			doing = action.combat;
		}
		 else {
			doing = action.Idle;
		}
	}

	public override void doSomething()
	{
		throw new System.NotImplementedException();
	}


	public void move(){
		
	}
	void Update(){
		decide();
	}
}