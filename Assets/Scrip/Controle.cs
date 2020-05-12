using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle : MonoBehaviour
{
   [SerializeField] private float vel = 6;
   [SerializeField] private float velRot = 100;
   [SerializeField] private Animator heroAnimator;
   

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Vertical") * vel;
        float rotacao = Input.GetAxis("Horizontal") * velRot;

        move *= Time.deltaTime;
        rotacao *= Time.deltaTime;

        transform.Rotate(0,rotacao,0);

        if(move != 0)
        {
            heroAnimator.SetBool("Andar",true);
        }else
        {
            heroAnimator.SetBool("Andar",false);
        }
        
    }
}
