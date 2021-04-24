using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAround : MonoBehaviour
{
    public float speed;
    public Transform[] moveSpot;
    private int randomSpot;
    float waittime;
    [SerializeField]
    float startwaittime = 2f;



    private void Start()
    {
        randomSpot = Random.Range(0, moveSpot.Length);
        waittime = startwaittime;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot[randomSpot].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpot[randomSpot].position) < .1f)
        {
            randomSpot = Random.Range(0, moveSpot.Length);
            waittime = startwaittime;
        }
        else
        {
            waittime -= Time.deltaTime;
        }

    }

}
