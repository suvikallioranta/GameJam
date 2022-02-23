using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    Vector3 velocity;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }


    //public void OnTriggerStay(Collider other)
    //{
    //    //Debug.Log("enter collision");
    //    if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F))
    //    {
    //        Debug.Log("interact");
    //    }
    //}
}