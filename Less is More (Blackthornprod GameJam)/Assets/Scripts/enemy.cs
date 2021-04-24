using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    float turnDegree;

    // Start is called before the first frame update
    void Start()
    {
        turnDegree = Random.Range(3f, 9f);
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.Rotate(new Vector3(0, 0, 0.3f), turnDegree);

    }
}
