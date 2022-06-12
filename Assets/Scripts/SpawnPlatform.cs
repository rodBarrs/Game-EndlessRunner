using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{

    public List<GameObject> platforms = new List<GameObject>();
    public GameObject pedestre;
    public List<Transform> currentPlatforms = new List<Transform>();
    private Transform player;
    private Transform currentPlatformPoint;
    private int platformIndex;
    public int offset;
    public int offsetPedestre;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < platforms.Count; i++)
        {
            Transform p = Instantiate(platforms[i], new Vector3(0, 0, i * 86), transform.rotation).transform;
            currentPlatforms.Add(p);
            offset += 86;
        }

        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().point;
    }

    // Update is called once per frame
    void Update()
    {
       float distance = player.position.z - currentPlatformPoint.position.z;


        if (distance >= 5)
       {
           Recycle(currentPlatforms[platformIndex].gameObject, pedestre);
           platformIndex++;

           if (platformIndex > currentPlatforms.Count - 1)
           {
               platformIndex = 0;
           } 
           currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().point;
        } 
    }

    public void Recycle(GameObject platform, GameObject pedestre)
        {
        platform.transform.position = new Vector3(0, 0, offset);
        pedestre.transform.position = new Vector3(0, 1, offset - 86);
        offset += 86;
        
        



    }
}

