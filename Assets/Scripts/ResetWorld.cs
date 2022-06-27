using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetWorld : MonoBehaviour
{
    public GameObject endText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(ReloadScene());
            endText.SetActive(true);
        }
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(10.0f);
        SceneManager.LoadScene(0);
    }
}
