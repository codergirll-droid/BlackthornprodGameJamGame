using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public GameObject player;
    public ParticleSystem particle;

    // Update is called once per frame

    void Update()
    {
        Vector3 pos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        this.transform.position = pos;

        if (player.activeSelf == false)
        {
            particle.Play();
        }
    }
}
