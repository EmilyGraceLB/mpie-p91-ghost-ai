using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    enum GhostState {
        WANDERING,
        FOUND_PLAYER
    };

    GhostState state = GhostState.WANDERING;

    GameObject player;
    void OnTriggerEnter(Collider collision) {
        if(collision.gameObject.name == "Player") {
            state = GhostState.FOUND_PLAYER;
            player = collision.gameObject;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        NavMeshAgent agent = GetComponent<NavMeshAgent> ();
        if(state == GhostState.WANDERING) {
            if(agent.remainingDistance <= 1.0f) {
                float x = Random.Range(-30.0f, 30.0f);
                float z = Random.Range(-30.0f, 30.0f);
                agent.destination = new UnityEngine.Vector3(x, 0.0f, z);
        } 
        } else if(state == GhostState.FOUND_PLAYER) {
            agent.destination = player.transform.position;
        }

    }
}
