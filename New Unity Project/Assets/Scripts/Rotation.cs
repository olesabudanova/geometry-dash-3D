using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Rigidbody ab; 
    void FixedUpdate()
    {
        if (ab.rotation.y >= 0) 
        {
            ab.AddForce(0, 2, 0); 
        }

        if (ab.rotation.y <= 0) 
        {
            ab.AddForce(0, 2, 0);
        }
    }
}
