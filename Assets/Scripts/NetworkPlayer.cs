using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayer : NetworkBehaviour
{
    public bool isServerEntity;
    public GameObject gameState;
    public GameObject helmsmanGUI;
    public GameObject captainGUI;

    // Use this for initialization
    void Start()
    {
        if (isServer)
        {
            isServerEntity = true;
            //Camera.main.transform.position = new Vector3(15, 0, -10);
            if(helmsmanGUI)
            {
                helmsmanGUI.gameObject.SetActive(false);
            }
        }
        else if (isClient)
        {
            isServerEntity = false;
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
    }




    #region controllGameState

    //Control of the ship
    public void setSpeed(float speed)
    {
        if (!isLocalPlayer || isServerEntity)
        {
            Debug.Log("set Speed called as !localPlayer OR ServerEntity " + isServerEntity);
            return;
        }
        CmdSetSpeed(speed);
    }
    [Command]
    public void CmdSetSpeed(float speed)
    {
        gameState.GetComponent<GameState>().speed = speed;
    }
    public void setDirection(float direction)
    {
        if (!isLocalPlayer || isServerEntity)
        {
            Debug.Log("set Direction called as !localPlayer OR ServerEntity " + isServerEntity);
            return;
        }
        CmdSetDirection(direction);
    }
    [Command]
    public void CmdSetDirection(float direction)
    {
        Debug.Log("SetDir2: " + Input.GetAxis("Horizontal"));
        gameState.GetComponent<GameState>().direction = direction;
    }

    //Cmd from Captain
    public void setLEDUp(bool value)
    {
        if (!isServerEntity)
        {
            Debug.Log("set LED called as !ServerEntity");
            return;
        }
        gameState.GetComponent<GameState>().er_up = value;
    }
    public void setLEDDown(bool value)
    {
        if (!isServerEntity)
        {
            Debug.Log("set LED called as !ServerEntity");
            return;
        }
        gameState.GetComponent<GameState>().er_down = value;
    }
    public void setLEDLeft(bool value)
    {
        if (!isServerEntity)
        {
            Debug.Log("set LED called as !ServerEntity");
            return;
        }
        gameState.GetComponent<GameState>().er_left = value;
    }
    public void setLEDRight(bool value)
    {
        if (!isServerEntity)
        {
            Debug.Log("set LED called as !ServerEntity");
            return;
        }
        gameState.GetComponent<GameState>().er_right = value;
    }

    #endregion controllGameState
}
