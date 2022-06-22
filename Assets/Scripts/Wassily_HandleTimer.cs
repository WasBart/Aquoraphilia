using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wassily_HandleTimer : MonoBehaviour
{
    public AudioSource audiosource1;
    public AudioSource audiosource2;
    public AudioSource audiosource3;
    public bool stopped = false;
    private IEnumerator audioCoroutine;
    private IEnumerator countdownCoroutine;
    public GameObject stopVolume;
    private Wassily_StopGame stopGameScript;
    public GameObject characterController;
    // Start is called before the first frame update
    void Start()
    {
        audioCoroutine = StartVoiceTrack();
        StartCoroutine(audioCoroutine);
        stopGameScript = stopVolume.GetComponent<Wassily_StopGame>();
        countdownCoroutine = CountdownEnding();
    }

    // Update is called once per frame
    void Update()
    {
        if(stopped)
        {
            StopCoroutine(audioCoroutine);
        }
    }

    IEnumerator StartVoiceTrack()
    {
        yield return new WaitForSeconds(30.0f);
        if (characterController.transform.position != Vector3.zero)
            stopVolume.transform.position = new Vector3(0, 0.5f, 0);
        else
        {
            StartCoroutine(countdownCoroutine);
            yield break;
        }
        audiosource1.Play();
        while(!stopped)
        {
            yield return new WaitForSeconds(10.0f);
            audiosource2.Play();
            yield return new WaitForSeconds(10.0f);
            audiosource3.Play();
        }
    }
    IEnumerator CountdownEnding()
    {
        yield return new WaitForSeconds(300.0f);
        stopGameScript.EndGame();
    }
}
