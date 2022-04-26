using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    private static Fire _inst = null;

    public static Fire inst
    {
        get
        {
            if (_inst == null)
            {
                _inst = FindObjectOfType<Fire>();
            }
            return _inst;
        }
    }

    void Start()
    {
    
    }


    void Update()
    {
        
    }

    public void ReceiveWood(Treee treee)
    {
        Destroy(treee.gameObject);

        //WoodAddToFireParticle.Clear();
        //WoodAddToFireParticle.Stop();
        //WoodAddToFireParticle.Play();
        //NumberOfWood += 1;
    }
}
