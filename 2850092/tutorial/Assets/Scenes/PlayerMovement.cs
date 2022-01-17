using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = .1f;


    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, yDirection);

        transform.position += moveDirection * speed;
    }
}
