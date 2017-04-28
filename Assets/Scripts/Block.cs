using System.Collections;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int hits;

    private AudioSource audioDestroy;

    private void Awake()
    {
        AddAudioDestroy();
    }

    private void OnCollisionEnter2D(Collision2D e)
    {
        if (e.gameObject.tag == "Ball")
        {
            hits--;

            if (hits <= 0)
            {
                DestroyBlock();
            }
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(audioDestroy.clip, this.transform.position, 1.0f);

        Destroy(gameObject.transform.parent.gameObject);
    }

    private void AddAudioDestroy()
    {
        audioDestroy = gameObject.AddComponent<AudioSource>();

        //audioDestroy.clip = Resources.Load<AudioClip>("block-" + Random.Range(1, 3).ToString());
        audioDestroy.clip = Resources.Load<AudioClip>("block-2");
    }
}