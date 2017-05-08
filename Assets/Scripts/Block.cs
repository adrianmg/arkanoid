using System.Collections;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int Hits;
    public int Score;

    private void OnCollisionEnter2D(Collision2D e)
    {
        if (e.gameObject.tag == "Ball")
        {
            UpdateHits();
        }
    }

    private void Destroy()
    {
        GameManager.UpdateScore(Score);

        ObjectFactory.CreateBlockExplosion(this.transform);

        Destroy(gameObject.transform.parent.gameObject);
    }

    private void UpdateHits()
    {
        Hits--;

        if (Hits <=0)
        {
            Destroy();
        }
    }
}