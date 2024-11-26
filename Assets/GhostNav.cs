using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GhostNav : MonoBehaviour
{
     enum GhostState
        {
            WANDERING,
            FOUND
        };

        GhostState state = GhostState.WANDERING;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update (){
        NavMeshAgent agent = GetComponent<NavMeshAgent> ();       

        if (state == GhostState.WANDERING){
            if (agent.remainingDistance <= 1.0f){
                float x = Random.Range(-75.0f, 75.0f);
                float z = Random.Range(-75.0f, 75.0f);
                agent.destination = new Vector3(x, 0.0f, z);
            }
        }
        else if(state == GhostState.FOUND){
            agent.destination = player.transform.position;
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.name == "Player")
        {
            state = GhostState.FOUND;
            player = other.gameObject;
        }
    }   

}   

