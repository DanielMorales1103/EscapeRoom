using UnityEngine;
using System.Collections;

public class HitLogic : MonoBehaviour
{
    public Transform Door;
    public float moveDistance = 5f;
    public float moveDuration = 1f;   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Press();
        }
    }

    private void Press()
    {
        //verificar monedas
        RaycastHit hit;
        Ray camRay = Camera.main.ViewportPointToRay(new Vector3(0.6f, 0.5f, 0));

        if (Physics.Raycast(camRay, out hit))
        {
            if (hit.collider.CompareTag("Clickeable"))
            {
                if(GameManager.Instance != null && GameManager.Instance.HasAllCoins)
                {
                    Renderer rend = hit.collider.GetComponent<Renderer>();
                    if (rend != null)
                    {
                        rend.material.color = Color.green;
                    }
                    StartCoroutine(MoveDoorSmooth());
                }
                
            }
        }
    }
    private IEnumerator MoveDoorSmooth()
    {
        Vector3 start = Door.position;
        Vector3 end = start - Vector3.right * moveDistance;
        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            Door.position = Vector3.Lerp(start, end, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        Door.position = end;
    }
}
