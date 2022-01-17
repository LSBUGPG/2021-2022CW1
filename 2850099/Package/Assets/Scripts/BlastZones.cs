using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastZones : MonoBehaviour
{

    [SerializeField] private Transform player;

    [SerializeField] private Transform Respawn;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = Respawn.transform.position;  
    }
}
