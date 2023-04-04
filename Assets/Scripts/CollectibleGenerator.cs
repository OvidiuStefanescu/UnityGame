using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleGenerator : MonoBehaviour
{
    [SerializeField] private Collectibles collectiblePrefab;
    [SerializeField] private int spawnAmount = 40;
    [SerializeField] private float spawnDistance = 20f;

    private void Start()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            var hadPositiveNumber = false;
            for (int j = -1; j < 2; j++)
            {
                var clone = Instantiate(collectiblePrefab, new Vector3(j * 1.5f, 1, (i + 1) * spawnDistance), Quaternion.identity);
                var score = Random.Range(-10, 5);
               
                if (score > 0)
                {
                    hadPositiveNumber = true;
                }
                if( j == 1 && !hadPositiveNumber)
                {
                    score = Random.Range(1, 5);
                }

                clone.RandomizeScore(score);
            }
        }
    }
}
