using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip jumpSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Jump();
        }
    }

    void Jump()
    {
        //sound\

        SoundFXManager.instance.PlaySFXClip(jumpSound, transform);

    }
}
