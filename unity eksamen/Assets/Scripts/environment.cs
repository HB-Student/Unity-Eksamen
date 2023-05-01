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
		for (int x = -width; x < width; x += 10)
		{
			for (int y = -height; y < height; y += 10)
			{
				if (Mathf.PerlinNoise(x, y) > 0.6)
				{
					GameObject spawn = plants[Random.Range(0, plants.Count)];
					Instantiate(spawn, new Vector2(x, y), Quaternion.identity);
				}
			}
		}
	}
}
