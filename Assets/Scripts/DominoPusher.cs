using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DominoPusher : MonoBehaviour
{
    //public DominoPusher controls;

    private void Awake()
    {
        
    }


    public void ActivePhysicOnBall()
    {
        GameObject.FindGameObjectWithTag("Pusher").GetComponent<Rigidbody>().useGravity = true;
    }

  


}
