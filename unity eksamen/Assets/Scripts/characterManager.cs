using UnityEngine;
public class characterManager : MonoBehaviour
{
	public stat vitality = new stat("vitality");
	public stat strength = new stat("strength");
	public stat agility = new stat("agility");
	public stat abilityHaste = new stat("abilityHaste");
	public stat sightRadius = new stat("sightRadius");

	public void bonusStat(string stat, int difference)
	{
					vitality.bonusStat += difference;
					strength.bonusStat += difference;
					agility.bonusStat += difference;
					abilityHaste.bonusStat += difference;
					sightRadius.bonusStat += difference;
		foreach (Transform child in transform)
		{
			character character = child.GetComponent<character>();
			switch (stat)
			{
				case "vitality":
					character.vitality.bonusStat =vitality.bonusStat;
					break;
				case "strength":
					character.strength.bonusStat  = strength.bonusStat;
					break;
				case "agility":
					character.agility.bonusStat  = strength.bonusStat;
					break;
				case "abilityHaste":
					character.abilityHaste.bonusStat  = strength.bonusStat;
					break;
				case "sightRadius":
					character.sightRadius.bonusStat  = strength.bonusStat;
					break;
				default:
					return;
			}
		}
		gameObject.GetComponent<Animation>().Play("heroLevelUp");
	}
	public void bonusPercentage(string stat, int difference)
	{
					agility.bonusPercentage += difference;
					strength.bonusPercentage += difference;
					agility.bonusPercentage += difference;
					abilityHaste.bonusPercentage += difference;
					sightRadius.bonusPercentage += difference;
		foreach (Transform child in transform)
		{
			character character = child.GetComponent<character>();
			switch (stat)
			{
				case "vitality":
					character.vitality.bonusPercentage = agility.bonusPercentage;
					break;
				case "strength":
					character.strength.bonusPercentage = strength.bonusPercentage;
					break;
				case "agility":
					character.agility.bonusPercentage = agility.bonusPercentage;
					break;
				case "abilityHaste":
					character.abilityHaste.bonusPercentage = abilityHaste.bonusPercentage;
					break;
				case "sightRadius":
					character.sightRadius.bonusPercentage = sightRadius.bonusPercentage;
					break;
				default:
					return;
			}
		}
			gameObject.GetComponent<Animation>().Play("heroLevelUp");
	}

}