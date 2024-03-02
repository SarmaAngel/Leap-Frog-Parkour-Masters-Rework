using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeMovement : MonoBehaviour
{
    public float pushForce = 5.0f;
    private ControllerColliderHit contact;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        contact = hit;
        
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body != null && !body.isKinematic)
        {
            body.velocity = hit.moveDirection * pushForce;
        }
    }
}
