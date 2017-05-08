using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFactory : MonoBehaviour
{
    protected static ObjectFactory instance;

    public GameObject BlockExplosion;


    private void Awake()
    {
        instance = this;
    }

    public static BlockExplosion CreateBlockExplosion(Transform transform)
    {
        var explosion = Object.Instantiate(instance.BlockExplosion, transform.position, Quaternion.identity).GetComponent<BlockExplosion>();
        explosion.Initialize();

        return explosion;
    }
}
