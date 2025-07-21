using UnityEngine;

public class ClickableBlock : MonoBehaviour
{
    private Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        rend.material.color = Color.green;
        Debug.Log("Block clicked!");
    }
}
