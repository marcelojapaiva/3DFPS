using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle : MonoBehaviour
{
   [SerializeField] private float vel = 6;
   [SerializeField] private float velRot = 100;
   [SerializeField] private Animator heroAnimator;

    //IK - Alvo para olhar.
   [SerializeField] private Transform alvo;
   
   //Trigger animação de morto
   [SerializeField] private bool estaMorto = false;

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Vertical") * vel;
        float rotacao = Input.GetAxis("Horizontal") * velRot;

        move *= Time.deltaTime;
        rotacao *= Time.deltaTime;

        if(!estaMorto){transform.Rotate(0,rotacao,0);}
        
        if(move != 0)
        {
            heroAnimator.SetBool("Andar",true);
        }else
        {
            heroAnimator.SetBool("Andar",false);
        }

        if(estaMorto && Input.GetKeyDown(KeyCode.Space))
        {
            heroAnimator.SetTrigger("Levantar");
            estaMorto = false;
        }   
    }
    //
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Enemy"))
        {
            heroAnimator.SetTrigger("Morte");
            estaMorto = true;
        }
    }

    //IK Instancia
   /*  private void OnAnimatorIK(int layerIndex)
    {
        //Cabeça Olhar para o transform.
        heroAnimator.SetLookAtWeight(1);
        heroAnimator.SetLookAtPosition(alvo.position);
    
        //Braço aponta para o transform
        heroAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand,1);
        heroAnimator.SetIKPosition(AvatarIKGoal.LeftHand,alvo.position);
        
        //Perna aponta para o transform
        heroAnimator.SetIKPositionWeight(AvatarIKGoal.LeftFoot,1);
        heroAnimator.SetIKPosition(AvatarIKGoal.LeftFoot,alvo.position);
    } */
}
