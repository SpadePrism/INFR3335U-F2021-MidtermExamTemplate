using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    private float speed;
    private float dirX;
    private float dirZ;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * speed;

        dirZ = Input.GetAxis("Vertical") * speed;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(dirX, rb.velocity.y, dirZ);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Coin coin = collision.gameObject.GetComponent<Coin>();
        if(coin)
        {
            Destroy(collision.gameObject);
            count += 1;
            if(count >= 10)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("End");
                count = 0;
            }
        }
    }
}
