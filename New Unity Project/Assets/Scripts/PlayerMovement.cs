using UnityEngine;

public struct Limiter
{
    public Limiter(Vector3 min, Vector3 max)
    {
        MIN = min; 
        MAX = max;
    }
    public Vector3 MIN { get; }
    public Vector3 MAX { get; }
}

public class PlayerMovement : MonoBehaviour
{
    // This is a reference to the Rigidbody component called "rb"
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    private bool isTransforming = false;
    public Limiter limiter = new Limiter(new Vector3(1f, 0.5f, 1f), new Vector3(15f, 1f, 1f));
    public float xScaleTrigger = 3f;
    private Vector3 xScaleChange = new Vector3(0.05f, 0f, 0f);
    private Vector3 yScaleChange = new Vector3(0f, 0.05f, 0f);

    // We marked this as "Fixed"Update becase we 
    // are using it to mess with physics.
    void FixedUpdate()
    {
        // Add a forward force 
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        CheckValues();
        
        if (Input.GetKey("d")) 
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        } 

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if (Input.GetKey("u"))
        {
            Deform();
        }

        if (Input.GetKey("i"))
        {
            Deform(true);
        }
    }

    private void Deform(bool reverse = false)
    {
        
        transform.localScale += reverse ? -xScaleChange : xScaleChange;

       // if (transform.localScale.x > xScaleTrigger)
        
            transform.localScale += reverse ? yScaleChange : -yScaleChange;
        

        

    }

    private void CheckValues()
    {
        if (transform.localScale.y < limiter.MIN.y)
        {
            transform.localScale = new Vector3(transform.localScale.x, limiter.MIN.y, transform.localScale.z);
        }
        if (transform.localScale.y > limiter.MAX.y)
        {
            transform.localScale = new Vector3(transform.localScale.x, limiter.MAX.y, transform.localScale.z);
        }

        if (transform.localScale.x < limiter.MIN.x)
        {
            transform.localScale = new Vector3(limiter.MIN.x, transform.localScale.y, transform.localScale.z);
        }
        if (transform.localScale.x > limiter.MAX.x)
        {
            transform.localScale = new Vector3(limiter.MAX.x, transform.localScale.y, transform.localScale.z);
        }
    }
}
