using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    public NavMeshAgent agente;
    public Animator animator;

    public enum MyEnum
    {
        idle,
        moving,
        atacking,
        moveToAtack,
    }

    public MyEnum myEnum;
    public GameObject clickEffect;
    void Start()
    {
        agente = this.GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (agente != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    if (hit.transform.tag == "ground")
                    {
                        agente.SetDestination(hit.point);
                        myEnum = MyEnum.moving;
                        Instantiate(clickEffect, hit.point, Quaternion.identity);
                        Debug.Log(hit.point);
                    }

                    else if(hit.transform.tag == "enemy")
                    {
                        agente.SetDestination(hit.point);
                        myEnum = MyEnum.moveToAtack;
                    }
                    
                   
                    
                }
            }
            

        }

        Debug.Log(agente.hasPath);

        if (agente.hasPath)
        {
            animator.SetBool("IsMoving", true);
        }

        else { animator.SetBool("IsMoving", false); }


        switch (myEnum) 
        {
            case MyEnum.idle:

                break;
            case MyEnum.moving:
                break;
            case MyEnum.atacking:
                break;
            case MyEnum.moveToAtack:
                break;
        } 

    }
}
