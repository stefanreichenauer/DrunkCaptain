using UnityEngine;
using UnityEngine.Networking;

public class GameState : NetworkBehaviour
{
    //Bool variables controlling the engine room LEDs
    [SyncVar]
    private bool er_up = false;
    [SyncVar]
    private bool er_down = false;
    [SyncVar]
    private bool er_left = false;
    [SyncVar]
    private bool er_right = false;

    //ship controls
    private float speed = 0.0f;
    private float direction = 0.0f;

    private float last_time_called = -1.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    #region msgFromCpt
    //properties
    public bool LEDup
    {
        get
        {
            return er_up;
        }
        set
        {
            er_up = value;
        }
    }
    public bool LEDdown
    {
        get
        {
            return er_down;
        }
        set
        {
            er_down = value;
        }
    }
    public bool LEDleft
    {
        get
        {
            return er_left;
        }
        set
        {
            er_left = value;
        }
    }
    public bool LEDright
    {
        get
        {
            return er_right;
        }
        set
        {
            er_right = value;
        }
    }
    #endregion msgFromCpt

    #region controlShip
    //properties
    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
    public float Direction
    {
        get
        {
            return direction;
        }
        set
        {
            direction = value;
        }
    }


    #endregion controlShip

}
