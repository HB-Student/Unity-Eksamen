using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class environment : MonoBehaviour
{
	public List<GameObject> plants = new List<GameObject>();
	int width = 200;
	int height = 200;

	void Start()
	{
		for (int x = -1*width; x < width; x += width/30)
		{
			for (int y = -1*height; y < height; y += width/30)
			{
				if (Random.Range(0,10) > 6)
				{
					GameObject plant = plants[Random.Range(0, plants.Count)];
					Instantiate(plant, new Vector2(x, y), Quaternion.identity);
				}
			}
		}
	}
}
