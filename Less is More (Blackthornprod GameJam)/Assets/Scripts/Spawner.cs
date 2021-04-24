using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    int rateMin = 0;
    [SerializeField]
    int rateMax = 0;

    [SerializeField]
    float rate = 0;

    public GameObject enemy_time;

    private void Start()
    {
        rate = Random.Range(rateMin, rateMax + 1);
    }

    // Update is called once per frame
    void Update()
    {
        rate -= Time.deltaTime;
        if(rate < 1)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject x = Instantiate(enemy_time, pos, Quaternion.identity);
            rate = Random.Range(rateMin, rateMax + 1);
            Destroy(x, 15);
        }
    }
}
