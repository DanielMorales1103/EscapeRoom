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
            Debug.LogError("Asigna el PlayerArmature en el Inspector.");
            enabled = false;
            return;
        }

        // Guarda la posición local y rotación iniciales
        startLocalPos = player.localPosition;
        startLocalRot = player.localRotation;

        // Cachea el CharacterController para deshabilitarlo durante el teletransporte
        controller = player.GetComponent<CharacterController>();
        if (controller == null)
            Debug.LogWarning("No encontré CharacterController en PlayerArmature.");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Asegúrate de que el colisionador entrante sea el jugador
        if (!other.CompareTag("Player")) return;

        Debug.Log("Player tocó Danger — reseteando posición del PlayerArmature.");

        // 1) Deshabilito el CharacterController para que no sobrescriba mi teletransporte
        if (controller != null) controller.enabled = false;

        // 2) Teletransporto el niño (no el root) a su posición local inicial
        player.localPosition = startLocalPos;
        player.localRotation = startLocalRot;

        // 3) Reactivo el CharacterController
        if (controller != null) controller.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
