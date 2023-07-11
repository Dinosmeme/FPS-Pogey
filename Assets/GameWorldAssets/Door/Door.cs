using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    private bool isOpen = false;
    private bool canBeInteracted = true;
    private Animator anim;
    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    public override void OnFocus()
    {
        
    }

    public override void OnInteract()
    {
        if (canBeInteracted)
        {
            isOpen = !isOpen;

            Vector3 doorTransformDirection = transform.TransformDirection(Vector3.forward);
            Vector3 playersTransformDirection = FirstPersonController.instance.transform.position - transform.position;
            float dot = Vector3.Dot(doorTransformDirection, playersTransformDirection);

            anim.SetFloat("dot", dot);
            anim.SetBool("isOpen", isOpen);

            StartCoroutine(AutoClose());
        }
    }

    public override void OnLoseFocus()
    {
        
    }

    private IEnumerator AutoClose()
    {
        while (isOpen)
        {
            yield return new WaitForSeconds(3); 

            if(Vector3.Distance(transform.position, FirstPersonController.instance.transform.position) > 3)
            {
                isOpen = false;
                anim.SetFloat("dot", 0);
                anim.SetBool("isOpen", isOpen);
            }
        }
    }


    //These two can't be used because our animator attached to parent. This will be fixed when proper objects with proper pivot point is added into project

    private void Animator_LockInteraction()
    {
        canBeInteracted = false;
    }

    private void Animator_UnlockInteraction()
    {
        canBeInteracted = true;
    }
}
