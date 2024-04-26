using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab = null;
    public Transform spawnpoint = null;
    public float min = 1.0f;
    public float max = 3.5f;

    private void Start()
    {
        //Roep Spawn na een random tijd
        Invoke("Spawn", Random.Range(min, max));
    }

    private void Spawn()
    {
        //Instaniate prefab
        GameObject go = Instantiate(prefab);
        go.transform.position = new Vector3(spawnpoint.position.x, spawnpoint.position.y, spawnpoint.position.z); //Plaats het gespawnede prefab op de spawnpositie
        Invoke("Spawn", Random.Range(min, max)); //Roep Spawn na een random tijd
    }
}
