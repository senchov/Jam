using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField] private InputController InputCntrl;
    [SerializeField] private Transform Player;
    [SerializeField] private float Speed = 1.0f;
    [SerializeField] private ShootComponent ShootComp;

    private void Start () 
    {
        InputCntrl.Up += InputCntrl_Up;
        InputCntrl.Down += InputCntrl_Down;
        InputCntrl.Left += InputCntrl_Left;
        InputCntrl.Right += InputCntrl_Right;
        InputCntrl.Space += InputCntrl_Space;
    }

    void InputCntrl_Space ()
    {
        ShootComp.Shoot ();
    }

    void InputCntrl_Right ()
    {
        Move (new Vector2 (Time.deltaTime * Speed,0));
    }

    void InputCntrl_Left ()
    {
        Move (new Vector2 (-Time.deltaTime * Speed,0));
    }

    void InputCntrl_Down ()
    {
        Move (new Vector2 (0,-Time.deltaTime * Speed));
    }

    void InputCntrl_Up ()
    {
        Move (new Vector2 (0,Time.deltaTime * Speed));
    }
	
	

    private void Move (Vector2 moveValue) 
    {
        Player.position = new Vector3 (Player.position.x + moveValue.x, Player.position.y + moveValue.y, Player.position.z);
    }
}
