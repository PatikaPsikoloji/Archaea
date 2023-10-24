using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Headfollow : MonoBehaviour
{
    public Transform headfollow;
    public Transform target;
    // Start is called before the first frame update
    public float rotationSpeed = 45.0f; // Dönüş hızı, derece/saniye cinsinden
    public float angle, angle2=0;
    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetDir = target.position - transform.position;
            angle = Vector3.Angle(targetDir, transform.forward);

            if (angle < angle2)
                transform.LookAt(target);
        }      
    }
}
