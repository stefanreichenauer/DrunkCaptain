using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayer : NetworkBehaviour
{
    public GameObject gameState;
    public GameObject helmsmanGUI;
    public GameObject captainGUI;
    public bool isLocalP;

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
    }



    // Update is called once per frame
    void Update()
    {
        isLocalP = isLocalPlayer;

        if(true || Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (isServer)
            {
                gameState.GetComponent<GameState>().handleInput(
                    Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
            else
            {
                handleInputCmd(
                    Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
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
            CmdSetDirection(Input.GetAxis("Horizontal"));
        if(vertical != 0)
            CmdSetSpeed(Input.GetAxis("Vertical"));
    }


    #region controllGameState

    //Control of the ship
    [Command]
    public void CmdSetSpeed(float speed)
    {
        gameState.GetComponent<GameState>().speed = speed;
    }
    [Command]
    public void CmdSetDirection(float direction)
    {
        gameState.GetComponent<GameState>().direction = direction;
    }

    //Cmd from Captain
    public void setLEDUp(bool value)
    {
        if (!isServer)
        {
            Debug.Log("set LED called as !ServerEntity");
            return;
        }
        gameState.GetComponent<GameState>().er_up = value;
    }
    public void setLEDDown(bool value)
    {
        if (!isLocalPlayer )
        {
            Debug.Log("set LED called as !ServerEntity");
            return;
        }
        gameState.GetComponent<GameState>().er_down = value;
    }
    public void setLEDLeft(bool value)
    {
        if (!isServer)
        {
            Debug.Log("set LED called as !ServerEntity");
            return;
        }
        gameState.GetComponent<GameState>().er_left = value;
    }
    public void setLEDRight(bool value)
    {
        if (!isServer)
        {
            Debug.Log("set LED called as !ServerEntity");
            return;
        }
        gameState.GetComponent<GameState>().er_right = value;
    }

    #endregion controllGameState
}
