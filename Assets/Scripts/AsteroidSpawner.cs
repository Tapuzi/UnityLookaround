using UnityEngine;
using System;

[Serializable]
public class AsteroidSpawner : MonoBehaviour
{
    public float SpawnDelayMin = 5f;
    public float SpawnDelayMax = 10f;
    public float SpawnAngleHorizontal = 60f;
    public float SpawnAngleVerticalMin = -10f;
    public float SpawnAngleVerticalMax = 20f;
    public float SpawnDistance = 25.0f;
    public Transform Asteroid;
    
    private float Timer = 0.0f;
    private float SpawnDelay = 0.0f;
    private GameObject MainCamera;

    // Use this for initialization
    void Start ()
    {
        if (SpawnDelayMax < SpawnDelayMin ||
            SpawnAngleVerticalMax < SpawnAngleVerticalMin ||
            SpawnAngleHorizontal < 0f)
        {
            Debug.LogError("Oops. The Spawn attributes are illegal.");
            Application.Quit();
        }

        if (SpawnDistance < 5f)
        {
            Debug.LogError("Oops. The SpawnDistance is too low.");
            Application.Quit();
        }

        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        UpdateSpawnDelay();
    }

    void UpdateSpawnDelay()
    {
        SpawnDelay = UnityEngine.Random.value * (SpawnDelayMax - SpawnDelayMin) + SpawnDelayMin;
    }

    Vector3 GetSpawnLocation()
    {
        Transform spawn_point = GameObject.FindGameObjectWithTag("AsteroidSpawn").transform;
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        float horizontal_value = (UnityEngine.Random.value - 0.5f) * SpawnAngleHorizontal * 2;
        float vertical_value = -SpawnAngleVerticalMin - UnityEngine.Random.value * (SpawnAngleVerticalMax - SpawnAngleVerticalMin);

        spawn_point.localPosition = player.forward * SpawnDistance;
        spawn_point.RotateAround(player.position, Vector3.up, horizontal_value);
        spawn_point.RotateAround(player.position, player.transform.right, vertical_value);

        return spawn_point.position;
    }

    void SpawnAsteroid()
    {
        Instantiate(Asteroid, GetSpawnLocation(), Quaternion.identity);
        Debug.Log("Spawn Asteroid.");
    }	
	
	void Update ()
    {

        Timer += Time.deltaTime;

        if (Timer > SpawnDelay)
        {
            Timer = 0;
            UpdateSpawnDelay();
            SpawnAsteroid();
        }
    }
}
