using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour
{
    public Transform Door;
    public float moveDistance = 5f;
    public float moveDuration = 1f;

    [SerializeField] private AudioClip slash;
    [SerializeField][Range(0f, 1f)] private float volume = 1.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Push"))
        {         
            AudioSource.PlayClipAtPoint(slash, transform.position, volume);
            StartCoroutine(MoveDoorSmooth());            
        }
    }

    private IEnumerator MoveDoorSmooth()
    {
        Vector3 start = Door.position;
        Vector3 end = start - Vector3.forward * moveDistance;
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
