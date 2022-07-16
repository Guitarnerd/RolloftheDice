using UnityEngine;

public class PoppingMechanic : MonoBehaviour
{

    // Update is called once per frame
    public GameObject popper;
    public Rigidbody rb;
    public float explosionForce;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            rb.AddForce(transform.up * explosionForce);
        }
    }
}
