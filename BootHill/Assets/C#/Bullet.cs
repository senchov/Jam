using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
    [SerializeField] private Rigidbody RB;
    [SerializeField] private float Speed;
    [SerializeField] private Transform Dir;

    [ContextMenu ("MoveForward")]
    public void MoveForward () 
    {
        RB.AddForce ((Dir.position - transform.position) * Speed);
    }

    private void OnCollisionEnter (Collision col) 
    {
        if (col.gameObject.tag == TagsConstants.Wall)
            Destroy (gameObject);
    }
}
