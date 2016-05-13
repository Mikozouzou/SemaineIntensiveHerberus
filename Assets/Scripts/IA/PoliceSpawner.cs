using UnityEngine;
using System.Collections;

public class PoliceSpawner : MonoBehaviour {

    public GameObject[] spawnPrefabList;
    Transform policeHolder;
    public bool canLoop;
    BoxCollider colliderSpawner;
    // spawn un ennemi toute les x secondes si > 0
    public float timerSpawn=0;

    int currentIndex = 0;

	void Start () {
        colliderSpawner = GetComponentInChildren<BoxCollider>();
        policeHolder = GameObject.Find("Policemen").transform;
        if (timerSpawn > 0)
        {
            InvokeRepeating("spawnOne", timerSpawn, timerSpawn);
        }
    }

    public void spawnOne()
    {

        if (currentIndex < spawnPrefabList.Length)
        {
            GameObject men = (GameObject)Instantiate(spawnPrefabList[currentIndex], transform.position, transform.rotation);
            Physics.IgnoreCollision(colliderSpawner, men.GetComponentInChildren<CapsuleCollider>());
            men.transform.parent = policeHolder;
            PoliceStation.instance.AddOnePolice(men);
            currentIndex++;
            
        }
        else if (canLoop)
        {
            currentIndex = 0;
            spawnOne();
        }
    }
}
