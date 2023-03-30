public class stat
{
	public int baseStat = 1;
	public int bonusStat = 0;
	public int bonusPercentage = 0;
	public string name;
	
	public stat(string _name){
		name = _name;
	}
	public int totalStat(){
		return (baseStat+bonusStat)*(1+bonusPercentage/100);
	}
	
}
