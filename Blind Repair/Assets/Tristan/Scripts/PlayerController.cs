using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController Controller;

    public float Speed = 12f;
    public float Gravity = -9.81f;

    Vector3 _velocity;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        Controller.Move(move * Speed * Time.deltaTime);

        _velocity.y += Gravity * Time.deltaTime;

        Controller.Move(_velocity * Time.deltaTime);
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