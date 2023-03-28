public class stat
{
	public int baseStat = 1;
	public int bonusStat = 0;
	public int bonusPercentage = 0;
	public int totalStat(){
		return (baseStat+bonusStat)*(1+bonusPercentage/100);
	}
	
}
