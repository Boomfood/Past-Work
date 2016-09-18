using UnityEngine;
using System.Collections;

public class AIInterface : MonoBehaviour
{
    public Vector2 movement = Vector2.zero; //y = forward/backward, x = strafe
    public bool jumped = false;
    public RigidbodyAIController movementController;
    public GameObject pet;
    SphereCollider trigger;
    public float triggerSize = 20f;
    public float range = 5f;
    public float width = 1f;
    public string fistCoroutine = "";
    public Vector3 centered = Vector3.zero;

    void Start()
    {
        movementController = GetComponent<RigidbodyAIController>();
        pet = new GameObject();
        trigger = gameObject.AddComponent<SphereCollider>();
        trigger.center = centered;
        trigger.isTrigger = true;
        trigger.radius = triggerSize;
        StartCoroutine("Path");
    }

    public void SetMovement(float x, float y)
    {
        movement.x = x;
        movement.y = y;
        movementController.Move(movement, jumped);
    }
}
