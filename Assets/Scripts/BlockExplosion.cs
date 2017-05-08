using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockExplosion : MonoBehaviour
{
    private IEnumerator destroyRoutine;


    public void Initialize()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1);
    }

    private void Start()
    {
        SetDestroyRoutine();
    }

    private void SetDestroyRoutine()
    {
        float waitTime = gameObject.GetComponent<AudioSource>().clip.length;
        if (waitTime < 1)
        {
            waitTime = 1.0f;
        }

        destroyRoutine = Destroy(waitTime);
        StartCoroutine(destroyRoutine);
    }

    private IEnumerator Destroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }

    public void HideAfterAnimation()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
