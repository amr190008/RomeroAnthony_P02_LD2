using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This script allows user to spawn objects in waves, only once, or from another event.
/// original: Tim Lewis
/// date: 8/4/2022
/// </summary>
/// 
public class Spawner : MonoBehaviour
{
    [Header("Required")]
    [Tooltip("Object to Spawn")]
    public GameObject Prefab;
    [Tooltip("Location To Spawn At")]
    public Transform Location;

    [Header("Waves")]
    [Tooltip("Start On Awake - If this is turned off, you can instead turn it on via an event. You can also call the public Spawn method to spawn a single instance of the object")]
    public bool StartSpawning = true;
    public int AmountToSpawnPerWave = 3;
    [Min(1)]
    public float timeBetweenSpawns = 2;
    private float timer = 0;
    private bool firstTimeEnabled = false;

    public bool InfiniteWaves = false;
    [Min(1)]
    public int MaxWaves = 1;
    private int CurrentWave = 0;
    private bool wavesEnded = false;

    [Tooltip("Triggers when the last objects are spawned. This will not work properly if you are calling spawn from external events")]
    public UnityEvent onSpawningComplete;
    [Tooltip("Triggers when the last objects are destroyed. This will not work properly if you are calling spawn from external events")]
    public UnityEvent onAllObjectsDestroyed;


    private List<GameObject> spawnedObjects;
    private int amountOfTotalObjects = 0;
    private int amountOfDestroyedObjects = 0;
    private bool allDeadCalledOnce = false;
    

    // Start is called before the first frame update
    void Start()
    {
        spawnedObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //If we started the waves timer
        if(StartSpawning)
        {
            if(!firstTimeEnabled)
            {
                //In here we do everything for the first time the timer was enabled!
                amountOfTotalObjects = MaxWaves * AmountToSpawnPerWave;

                //Spawn the very first wave!
                Spawn();

                firstTimeEnabled = true;
            }

            if (CurrentWave < (MaxWaves - 1))
            {
                timer += Time.deltaTime;
                if (timer > timeBetweenSpawns)
                {
                    Spawn();
                    timer = 0;
                    if(!InfiniteWaves)
                        CurrentWave++;
                }
            }
        }

        if(!wavesEnded && CurrentWave == (MaxWaves - 1))
        {
            wavesEnded = true;
            Debug.Log("waves ended");
            onSpawningComplete.Invoke();
        }

        if(!InfiniteWaves)
        {
            amountOfDestroyedObjects = 0;
            for (int y = 0; y < spawnedObjects.Count; y++)
            {
                if (spawnedObjects[y] == null)
                {
                    amountOfDestroyedObjects++;
                }
            }

            if (amountOfTotalObjects == amountOfDestroyedObjects)
            {
                if (allDeadCalledOnce == false)
                {
                    allDeadCalledOnce = true;
                    onAllObjectsDestroyed.Invoke();
                    Debug.Log("All Destroyed");
                }
            }
        }
    }

    public void Spawn()
    {
        if (Prefab)
            for (int x=0;x< AmountToSpawnPerWave; x++)
            {
                spawnedObjects.Add(Instantiate(Prefab, Location.transform.position, Location.transform.rotation));
            }

    }
}
