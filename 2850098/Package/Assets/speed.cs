using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [Header("Player movement Settings")]
    [SerializeField] private float steadySpeed = 5.0f;

    [Space(10)]
    [SerializeField] private float boostIncrease = 5.0f;
    [SerializeField] private float boostTime = 10.0f;

    private bool isBoostActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.mass = 10;
            if (isBoostActivated)
            {
                rb.velocity = transform.forward * (steadySpeed + boostIncrease);
            }
            else
            {
                rb.velocity = transform.forward * steadySpeed;
            }
        }

        if (Input.GetKey(KeyCode.B))
        {
            if (!isBoostActivated)
            {
                Debug.Log("Boosting player speed");
                isBoostActivated = true;
                Invoke("EndBoost", boostTime);
            }
        }
        Debug.Log(rb.velocity);
    }
}
