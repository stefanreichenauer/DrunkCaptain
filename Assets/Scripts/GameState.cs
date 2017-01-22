using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

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
    public float speed = 0.0f;
    public float direction = 0.0f;

    private float last_time_called = -1.0f;

    [SyncVar]
    public State.StateEnum gameState = State.StateEnum.PREPERATION;

    public bool isClientConnected;

    public GameObject NetworkGUI;
    private NetworkManager netManager;

    private bool disconnectIfNoClients = false;

    public GameObject menuManagerObj;
    public MenuManager menuManager;

    // Use this for initialization
    void Start()
    {
        menuManagerObj = GameObject.Find("MenuManager");
        menuManager = menuManagerObj.GetComponent<MenuManager>();
        netManager = NetworkGUI.GetComponent < NetworkManager > ();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState == State.StateEnum.PREPERATION)
        {
            if(getIsClientConnected())
            {
                gameState = State.StateEnum.RUNNING;
            }
        }
        else if (gameState == State.StateEnum.COLLISION)
        {
            if (last_collision + 1 < Time.time)
            {
                gameState = State.StateEnum.RUNNING;
            }
        }
        else if (gameState == State.StateEnum.SUCCESS)
        {
            if (isClient)
            {
                menuManager.isSuccess = true;
                disconnect();
            }
        }
        //Debug.Log("Clients: " + getIsClientConnected());
        if (disconnectIfNoClients && !getIsClientConnected())
        {
            netManager.StopServer();
            loadScene();
        }

        
    }

    public bool getIsClientConnected()
    {
        isClientConnected = netManager.numPlayers > 0;
        return isClientConnected;
    }

    private float last_collision = -1.0f;

    public void setCollision()
    {
        gameState = State.StateEnum.COLLISION;

        last_collision = Time.time;
    }

    public void finishReached()
    {
        menuManager.isSuccess = true;
        gameState = State.StateEnum.SUCCESS;
        disconnect();
    }

    public void timeOver()
    {
        menuManager.isSuccess = false;
        gameState = State.StateEnum.FAILURE;
        disconnect();
    }

    public void disconnect()
    {
        if(isServer)
        {
            disconnectIfNoClients = true;
        }
        else
        {
            netManager.StopClient();
            loadScene();
        }
    }

    public void loadScene()
    {
        if (gameState == State.StateEnum.SUCCESS)
        {
            SceneManager.LoadScene("EndScene");
        }
        else if (gameState == State.StateEnum.FAILURE)
        {
            SceneManager.LoadScene("EndScene");
        }

    }

    public void handleInput(float horizontal, float vertical)
    {
        er_up = vertical > 0;
        er_down = vertical < 0;
        er_right = horizontal > 0;
        er_left = horizontal < 0;
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
