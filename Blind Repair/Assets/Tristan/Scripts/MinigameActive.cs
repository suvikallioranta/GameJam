using UnityEngine;
using UnityEngine.Events;

public class MinigameActive : MonoBehaviour
{
    [SerializeField] private UnityEvent Minigame;

    public void OnTriggerStay(Collider other)
    {
        //Debug.Log("enter collision");
        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.F))
        {
            Debug.Log("interact");
            Minigame.Invoke();
        }
    }
}
