using UnityEngine;
using System.Collections;

public class PoliceSpawnerManager : MonoBehaviour {
    public static PoliceSpawnerManager instance;
    PoliceSpawner[] arraySpawner;

	void Start () {
        instance = this;
        arraySpawner = GetComponentsInChildren<PoliceSpawner>();

    }
	
    

    public void eventSpawnOne()
    {
        foreach (PoliceSpawner spawn in arraySpawner)
        {
            spawn.spawnOne();
        }
    }
}
