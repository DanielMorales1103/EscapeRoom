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

        // Guarda la posici�n local y rotaci�n iniciales
        startLocalPos = player.localPosition;
        startLocalRot = player.localRotation;

        // Cachea el CharacterController para deshabilitarlo durante el teletransporte
        controller = player.GetComponent<CharacterController>();
        if (controller == null)
            Debug.LogWarning("No encontr� CharacterController en PlayerArmature.");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Aseg�rate de que el colisionador entrante sea el jugador
        if (!other.CompareTag("Player")) return;

        Debug.Log("Player toc� Danger � reseteando posici�n del PlayerArmature.");

        // 1) Deshabilito el CharacterController para que no sobrescriba mi teletransporte
        if (controller != null) controller.enabled = false;

        // 2) Teletransporto el ni�o (no el root) a su posici�n local inicial
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
