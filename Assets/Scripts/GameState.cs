using UnityEngine;
using UnityEngine.Networking;

public class GameState : NetworkBehaviour
{
    //Bool variables controlling the engine room LEDs
    [SyncVar]
    public bool er_up = false;
    [SyncVar]
    public bool er_down = false;
    [SyncVar]
    public bool er_left = false;
    [SyncVar]
    public bool er_right = false;

    //ship controls
    [SyncVar]
    public float speed = 0.0f;
    public float direction = 0.0f;
    
    public bool speedUp = false;

    private float last_time_called = -1.0f;

    public GameObject player;
    private PlayerController playerController;

    // Use this for initialization
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerController.shipSpeed = speed;
    }

    public void switchUpLED(bool up)
    {
        er_up = up;
    }

    public void setSpeed()
    {/*
        Debug.Log("setSpeed0 " + speed);
        
        if (last_time_called + 1.0f > Time.time)
            return;
        else
            last_time_called = Time.time;
            */
        Debug.Log("setSpeed " + speedUp);
        speedUp = true;
        Debug.Log("setSpeed2 " + speedUp);
    }

    /*

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
            Debug.Log("UpSetter " + value);
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
    public void setLEDUp(bool value)
    {
        er_up = value;
    }
    */
}
