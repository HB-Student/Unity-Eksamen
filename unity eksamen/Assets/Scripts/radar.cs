using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class radar : MonoBehaviour
{
	public GameObject radarDot;
	GameObject radarMiddle;
	public List<GameObject> monsters;
	List<GameObject> dots = new List<GameObject>();
	void Start()
	{
		radarMiddle = GameObject.Find("radarMiddle");
		StartCoroutine(updateRadar());
	}
	IEnumerator updateRadar()
	{
		yield return new WaitForSeconds(0.2f);
		while (true)
		{
			List<GameObject> monsters = radarMiddle.GetComponent<radarScanner>().radarMonsters;
			foreach (GameObject monster in monsters)
			{
				GameObject dot = Instantiate(radarDot, monster.transform.position/2.2f+transform.position, Quaternion.identity);
				dot.transform.SetParent(transform);
				dots.Add(dot);
			}
			StartCoroutine(radarVFX());
			yield return new WaitForSeconds(2);
			foreach (GameObject dot in dots)
			{
				Destroy(dot);
			}
		}
	}
	IEnumerator radarVFX(){
		gameObject.GetComponent<Image>().color = Color.green;
		yield return new WaitForSeconds(0.125f);
		gameObject.GetComponent<Image>().color = Color.white;
	}
}