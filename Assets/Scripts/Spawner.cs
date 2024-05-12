using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject floor;
    SphereCollider floorCollider;
    float radius;

    public GameObject boostPickup;
    public GameObject boostPad;
    public GameObject jumpPad;
    public GameObject slowPit;
    public GameObject teslaWall;
    public GameObject coin;

    public GameObject[] floorPads;
    public GameObject[] pickups;
    public GameObject[] obstacles;


    // Start is called before the first frame update
    void Awake()
    {
        floorCollider = floor.GetComponent<SphereCollider>();
        radius = floorCollider.radius;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Spawn(boostPickup);
        }
    }

    void Spawn(GameObject obj)
    {
        GameObject spawned = Instantiate(obj);

        spawned.transform.position = randomPoint();
        rotateToMatchSphereFloor(spawned);

        //Debug.Log("Spawned new " + spawned.name + " at " + spawned.transform.position + " and time " + Time.time);
    }

    public void SpawnRandomObject()
    {
        int i = Random.Range(0, 2);

        switch (i) {
            case 0:
                SpawnRandomPad();
                break;

            case 1:
                SpawnRandomPickup();
                break;

            case 2:
                SpawnRandomObstacle();
                break;
        }     
    }

    public void SpawnRandomNoPickups()
    {
        int i = Random.Range(0, 1);

        switch (i)
        {
            case 0:
                SpawnRandomPad();
                break;

            case 1:
                SpawnRandomObstacle();
                break;
        }
    }

    public void SpawnRandomPad()
    {
        int i = Random.Range(0, floorPads.Length);
        Spawn(floorPads[i]);
    }

    public void SpawnRandomPickup()
    {
        int i = Random.Range(0, pickups.Length);
        Spawn(pickups[i]);
    }

    public void SpawnRandomObstacle()
    {
        int i = Random.Range(0, obstacles.Length);
        Spawn(obstacles[i]);
    }

    Vector3 randomPoint()
    {
        float x = Random.Range(-100, 100);
        float y = Random.Range(-100, 100);
        float z = Random.Range(-100, 100);

        Vector3 randomVec = new Vector3(x, y, z);
        Vector3 randomDir = (randomVec - Vector3.zero).normalized;
        Vector3 randPos = Vector3.zero + randomDir * radius;

        return randPos;
    }

    void rotateToMatchSphereFloor(GameObject obj)
    {
        Vector3 upDir = (Vector3.zero - obj.transform.position).normalized;

        Plane localPlane = new Plane(upDir, obj.transform.position);
        Vector3 planePoint = localPlane.ClosestPointOnPlane(randomPoint());

        Vector3 fwdDir = (planePoint - obj.transform.position).normalized;

        Quaternion rot = new Quaternion();
        rot.SetLookRotation(fwdDir, upDir);

        obj.transform.rotation = rot;
    }
}
