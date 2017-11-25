using UnityEngine;
using System.Collections;

public class ShootComponent : MonoBehaviour 
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform SpawnPoint; 

    public void Shoot () 
    {
        GameObject bullet = Instantiate (Bullet, SpawnPoint.position, SpawnPoint.rotation) as GameObject;
        bullet.gameObject.SetActive (true);
        bullet.GetComponent <Bullet> ().MoveForward ();   
    }

}
