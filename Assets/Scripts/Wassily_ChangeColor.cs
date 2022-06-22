using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wassily_ChangeColor : MonoBehaviour
{
    public Color targetColor;
    public Renderer floorRenderer;
    public float colorChangeDuration = 5;
    public float colorChangeControl = 0;
    public bool changeColor = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       
            
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Color curColor = floorRenderer.material.color;
            floorRenderer.material.SetColor("_Color", Color.Lerp(curColor, targetColor, Time.time * 0.0001f));
        }
    }
}
