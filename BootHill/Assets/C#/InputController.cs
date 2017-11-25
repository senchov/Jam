using UnityEngine;
using System.Collections;
using System;

public class InputController : MonoBehaviour 
{
    public event Action Down_down;
    public event Action Down;
    public event Action Up;
    public event Action Right;
    public event Action Left;
    public event Action Space;
	
	void Update ()
    {
        if (Input.GetKey (KeyCode.DownArrow))
            DownHandler ();

        if (Input.GetKey (KeyCode.UpArrow))
            UpHandler ();

        if (Input.GetKey (KeyCode.LeftArrow))
            LeftHandler ();

        if (Input.GetKey (KeyCode.RightArrow))
            RightHandler ();

        if (Input.GetKeyDown (KeyCode.Space))
            SpaceHandler ();
	}

    private void DownHandler () 
    {
        if (Down != null)
            Down ();
    }

    private void UpHandler () 
    {
        if (Up != null)
            Up ();
    }

    private void RightHandler () 
    {
        if (Right != null)
            Right ();
    }

    private void LeftHandler () 
    {
        if (Left != null)
            Left ();
    }      

    private void SpaceHandler () 
    {
        if (Space != null)
            Space ();
    }

    private void Down_downHandler () 
    {
        if (Down != null)
            Down ();
    }
}
