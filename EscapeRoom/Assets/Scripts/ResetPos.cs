using UnityEngine;

public class ResetPos : MonoBehaviour
{
    public Transform player;

    private Vector3 startLocalPos;
    private Quaternion startLocalRot;
    private CharacterController controller;

    void Start()
    {
        if (player == null)
        {
            return;
        }

        // Guarda la posición local y rotación iniciales
        startLocalPos = player.localPosition;
        startLocalRot = player.localRotation;

        controller = player.GetComponent<CharacterController>();
        if (controller == null)
            return;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (controller != null) controller.enabled = false;

            player.localPosition = startLocalPos;
            player.localRotation = startLocalRot;

            if (controller != null) controller.enabled = true;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
