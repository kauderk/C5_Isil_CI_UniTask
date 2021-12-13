using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandom : MonoBehaviour
{
    public string resourceToLoad = "Planetoid Enemy With Path";
    public void SpawnRandomAmount(int x)
    {
        // print radom times
        var r = Random.Range(1, Mathf.Abs(x));
        for (int i = 0; i < r; i++)
        {
            var spawend = Instantiate(Resources.Load(resourceToLoad) as GameObject);
            spawend.GetComponent<PlanetoidEnemyUnidirectional>().satelite.angle = Random.Range(180, 260);
            spawend.transform.position = transform.position;
        }
    }
}
