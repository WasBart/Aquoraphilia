using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wassily_EffectsCameraFollow : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position + new Vector3(0,1.0f,0);
        this.transform.rotation = player.transform.rotation;
    }
}
