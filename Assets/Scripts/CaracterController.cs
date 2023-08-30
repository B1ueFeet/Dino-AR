using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaracterController : MonoBehaviour
{
    [SerializeField] float jumpForce;
    private Rigidbody rb;
    private bool isGround = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            if (rb.velocity.y <= 0.1f) 
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGround = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    public void playStep()
    {
        SoundManager.PlaySound(SoundManager.Sound.playerSteep01);
    }
}
