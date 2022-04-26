using UnityEngine;

public class AD : MonoBehaviour
{
    public Rigidbody ad;
    void FixedUpdate()
    {
        if (ad.position.x < 0)
        {
            ad.AddForce(2, 0, 0, ForceMode.VelocityChange); 
        }
        if (ad.position.x >= 0) 
        {
            ad.AddForce(-2, 0, 0, ForceMode.VelocityChange);  
        }
    }
}
