using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlsModifier : MonoBehaviour
{
    private OVRPlayerController pCScript;
    private Vector3 lastPlayerPos;

    public float speedMultiplier = 2;
    public GameObject playerController;
    // Start is called before the first frame update
    void Start()
    {
        pCScript = playerController.GetComponent<OVRPlayerController>();
        lastPlayerPos = playerController.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curPlayerPos = playerController.transform.position;
        if (lastPlayerPos.y < curPlayerPos.y)
        {
            pCScript.MoveScaleMultiplier /= speedMultiplier;
        }
        else if (lastPlayerPos.y > curPlayerPos.y)
        {
            pCScript.MoveScaleMultiplier *= speedMultiplier;
        }
    }
}
