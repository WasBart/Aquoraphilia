using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wassily_StopGame : MonoBehaviour
{
    public GameObject endTitleGo;
    public GameObject effectsCameraGo;
    private Wassily_EffectsCameraFollow ecFollow;
    public GameObject ocelotAudioSources;
    public GameObject[] particleSystems;
    public GameObject timerHandler;
    private Wassily_HandleTimer hTimer;
    // Start is called before the first frame update
    void Start()
    {
        ecFollow = effectsCameraGo.GetComponent<Wassily_EffectsCameraFollow>();
        hTimer = timerHandler.GetComponent<Wassily_HandleTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            EndGame();
            
        }
    }

    public void EndGame()
    {
        endTitleGo.SetActive(true);
        ecFollow.enabled = false;
        ocelotAudioSources.SetActive(false);
        hTimer.stopped = true;
    }
}
