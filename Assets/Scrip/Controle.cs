using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle : MonoBehaviour
{
   [SerializeField] private float vel = 6;
   [SerializeField] private float velRot = 100;
   [SerializeField] private Animator heroAnimator;

    //IK - Alvo para olhar.
   //[SerializeField] private Transform alvo;
   
   //Trigger animação de morto
   private bool estaMorto = false;
   private bool flag;

   //Pendurar variaveis
    private bool estaPendurando = false;
    private Transform alvoPendurar;

    void Start()
    {
        alvoPendurar = null;
        flag = true;
    }

    void FixedUpdate()
    {
        if(!alvoPendurar)return;
        if(estaPendurando && flag)
        {
            transform.position = alvoPendurar.position;
            flag = false;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Vertical");
        float rotacao = Input.GetAxis("Horizontal") * velRot;

        

        if(!estaMorto && !estaPendurando)
        {
            rotacao *= Time.deltaTime;
            transform.Rotate(0,rotacao,0);
        }

        if(estaPendurando)
        {
            if(rotacao > 1)
            {
                heroAnimator.SetBool("PenduradoDir",true);
            }else if(rotacao < -1)
            {
                heroAnimator.SetBool("PenduradoEsc",true);
            }else
            {
                heroAnimator.SetBool("PenduradoDir",false);
                heroAnimator.SetBool("PenduradoEsc",false);
            }
        }
        
        if(move != 0)
        {
            heroAnimator.SetBool("Andar",true);
        }else
        {
            heroAnimator.SetBool("Andar",false);
        }

        if(estaMorto && Input.GetKeyDown(KeyCode.Q))
        {
            heroAnimator.SetTrigger("Levantar");
            estaMorto = false;
        }   
         if(Input.GetKeyDown(KeyCode.Space))
        {
            heroAnimator.SetTrigger("Pular");
        }   
    }

    //Pendurar na barra
    public void Pendurado(Transform alv)
    {
        if(estaPendurando)return;
        heroAnimator.SetTrigger("Agarrar");
        GetComponent<Rigidbody>().isKinematic = true;
        estaPendurando = true;
        alvoPendurar = alv;
    }


    //Trigger morte
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
