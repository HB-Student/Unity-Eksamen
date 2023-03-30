using UnityEngine;
class characterManager : MonoBehaviour
{
	public stat vitality = new stat("vitality");
	public stat strength = new stat("strength");
	public stat agility = new stat("agility");
	public stat abilityHaste = new stat("abilityHaste");
	public stat sightRadius = new stat("sightRadius");

	public void bonusStat(string stat, int difference)
	{
		foreach (Transform child in transform)
		{
			character character = child.GetComponent<character>();

			switch (stat)
			{
				case "vitality":
					agility.bonusStat += difference;
					character.vitality.bonusStat = agility.bonusStat;
					break;
				case "strength":
					strength.bonusStat += difference;
					character.strength.bonusStat = strength.bonusStat;
					break;
				case "agility":
					agility.bonusStat += difference;
					character.agility.bonusStat = agility.bonusStat;
					break;
				case "abilityHaste":
					abilityHaste.bonusStat += difference;
					character.abilityHaste.bonusStat = abilityHaste.bonusStat;
					break;
				case "sightRadius":
					sightRadius.bonusStat += difference;
					character.sightRadius.bonusStat = sightRadius.bonusStat;
					break;
				default:
					return;
			}
		}
	}
	public void bonusPercentage(string stat, int difference)
	{
		foreach (Transform child in transform)
		{
			character character = child.GetComponent<character>();
			switch (stat)
			{
				case "vitality":
					agility.bonusPercentage += difference;
					character.vitality.bonusPercentage = agility.bonusPercentage;
					break;
				case "strength":
					strength.bonusPercentage += difference;
					character.strength.bonusPercentage = strength.bonusPercentage;
					break;
				case "agility":
					agility.bonusPercentage += difference;
					character.agility.bonusPercentage = agility.bonusPercentage;
					break;
				case "abilityHaste":
					abilityHaste.bonusPercentage += difference;
					character.abilityHaste.bonusPercentage = abilityHaste.bonusPercentage;
					break;
				case "sightRadius":
					sightRadius.bonusPercentage += difference;
					character.sightRadius.bonusPercentage = sightRadius.bonusPercentage;
					break;
				default:
					return;
			}
		}
	}
}