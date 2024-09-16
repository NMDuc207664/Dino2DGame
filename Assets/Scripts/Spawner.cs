using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab;
        [Range(0f, 1f)]
        public float spawnChance;
    }
    public SpawnableObject[] objects;

    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;

    private void Awake()
    {
        //revive = GetComponent<Revive>();
    }
    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        float spawnChance = Random.value;
        GameObject obstacle;
        foreach (var obj in objects)
        {
            if (Revive.Instance.life > 0 && spawnChance < obj.spawnChance)
            {
                if (obj.prefab.name != "Heart")
                {
                    obstacle = Instantiate(obj.prefab);
                    obstacle.transform.position += transform.position;
                    break;
                }
            }
            else if (Revive.Instance.life <= 0 && spawnChance < obj.spawnChance)
            {
                obstacle = Instantiate(obj.prefab);
                obstacle.transform.position += transform.position;
                break;
            }

            spawnChance -= obj.spawnChance;
        }
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }
}
