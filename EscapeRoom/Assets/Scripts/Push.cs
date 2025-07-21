using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Push : MonoBehaviour
{
    public float pushPower = 2f;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic) return;

        // Impulsa el objeto en la dirección de tu movimiento
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.AddForce(pushDir * pushPower, ForceMode.VelocityChange);
    }
}
