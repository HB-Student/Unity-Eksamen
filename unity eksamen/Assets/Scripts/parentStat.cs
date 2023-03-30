using UnityEngine;
class parentStat : MonoBehaviour
{
	public void bonusStat(string stat, int difference){
		foreach (Transform child in transform)
		{
			character character = child.GetComponent<character>();

			switch (stat)
			{
				case "vitality":
				character.vitality.bonusStat+=difference;
				break;
				case "strength":
				character.strength.bonusStat+=difference;
				break;
				case "agility":
				character.agility.bonusStat+=difference;
				break;
				case "abilityHaste":
				character.abilityHaste.bonusStat+=difference;
				break;
				case "sightRadius":
				character.sightRadius.bonusStat+=difference;
				break;
				default:
				return;
			}
		}
	}
	public void bonusPercentage(string stat, int difference){
		foreach (Transform child in transform)
		{
			character character = child.GetComponent<character>();
			switch (stat)
			{
				case "vitality":
				character.vitality.bonusPercentage+=difference;
				break;
				case "strength":
				character.strength.bonusPercentage+=difference;
				break;
				case "agility":
				character.agility.bonusPercentage+=difference;
				break;
				case "abilityHaste":
				character.abilityHaste.bonusPercentage+=difference;
				break;
				case "sightRadius":
				character.sightRadius.bonusPercentage+=difference;
				break;
				default:
				return;
			}
		}
	}
}