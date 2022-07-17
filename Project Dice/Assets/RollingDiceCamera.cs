using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingDiceCamera : MonoBehaviour
{
    public GameObject Die;
    public GameObject Camera;
    private void Update()
    {

        Vector3 newPos = Die.transform.position;
        newPos = new Vector3(0, 1f, 0);

        Camera.transform.position = Die.transform.position + newPos;
        
    }
    public void enableCamera()
    {
        Camera.SetActive(true);
    }
    public void disableCamera()
    {
        Camera.SetActive(false);
    }
}
