using UnityEngine;

public class AB : MonoBehaviour
{
    public Rigidbody ab;
    void FixedUpdate()
    {
        if (ab.position.x < 0)
        {
            ab.AddForce(2, 0, 0, ForceMode.VelocityChange);
        }
        if (ab.position.x >= 0)
        {
            ab.AddForce(-2, 0, 0, ForceMode.VelocityChange);
        }
    }
}
