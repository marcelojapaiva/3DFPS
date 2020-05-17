using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendurarCod : MonoBehaviour
{
    public GameObject alvoPendurar;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("mao"))
        {
            col.GetComponentInParent<Controle>().Pendurado(alvoPendurar.transform);
        }
    }
}
