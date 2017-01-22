using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayer : NetworkBehaviour
{
    public GameObject gameState;
    public GameObject helmsmanGUI;
    public GameObject captainGUI;
    public bool isLocalP;

    private GameState gameStateComponent;

    public bool getIsServer()
    {
        return isServer;
    }

    // Use this for initialization
    void Start()
    {
        if (isServer)
        {
            //Camera.main.transform.position = new Vector3(15, 0, -10);
            if(helmsmanGUI)
            {
                helmsmanGUI.gameObject.SetActive(false);
            }
        }
        else if (isClient)
        {
            Camera.main.GetComponent<CameraController>().enabled = false;
            Camera.main.transform.position = new Vector3(-1500, 0, -10);
            if (captainGUI)
            {
                captainGUI.gameObject.SetActive(false);
            }
        }

        if (gameState == null)
            gameState = GameObject.Find("GameState");

        gameStateComponent = gameState.GetComponent<GameState>();
    }



    // Update is called once per frame
    void Update()
    {
        isLocalP = isLocalPlayer;

        if(gameStateComponent.gameState == State.StateEnum.RUNNING)
        {
            if (isServer)
            {
                gameStateComponent.handleInput(
                    Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
            else
            {
                handleInputCmd(
                    Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escaped the ship");
            gameStateComponent.gameState = State.StateEnum.FAILURE;
            gameStateComponent.disconnect();
        }

    }

    public void handleInputCmd(float horizontal, float vertical)
    {
        if (!isLocalPlayer)
        {
            Debug.Log("set Speed/Direction called as !localPlayer");
            return;
        }
        if(horizontal != 0)
            CmdSetDirection(horizontal);
        if(vertical != 0)
            CmdSetSpeed(vertical);
    }


    #region controllGameState

    //Control of the ship
    [Command]
    public void CmdSetSpeed(float speed)
    {
        gameStateComponent.speed = speed;
    }
    [Command]
    public void CmdSetDirection(float direction)
    {
        gameStateComponent.direction = direction;
    }

    //Cmd from Captain
    public void setLEDUp(bool value)
    {
        if (!isServer)
        {
            Debug.Log("set LED called as !ServerEntity");
            return;
        }
        gameStateComponent.er_up = value;
    }
    public void setLEDDown(bool value)
    {
        if (!isLocalPlayer )
        {
            Debug.Log("set LED called as !ServerEntity");
            return;
        }
        gameStateComponent.er_down = value;
    }
    public void setLEDLeft(bool value)
    {
        if (!isServer)
        {
            Debug.Log("set LED called as !ServerEntity");
            return;
        }
        gameStateComponent.er_left = value;
    }
    public void setLEDRight(bool value)
    {
        if (!isServer)
        {
            Debug.Log("set LED called as !ServerEntity");
            return;
        }
        gameStateComponent.er_right = value;
    }

    #endregion controllGameState
}
