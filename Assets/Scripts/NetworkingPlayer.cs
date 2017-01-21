using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkingPlayer : NetworkBehaviour {
    public bool isServerEntity;
    public GameObject gameState;

    // Use this for initialization
    void Start () {
        if (isServer)
        {
            isServerEntity = true;
            Camera.main.transform.position = new Vector3(15, 0, -10);
        }
        else if (isClient)
        {
            isServerEntity = false;
            Camera.main.transform.position = new Vector3(-15, 0, -10);
        }

        if (gameState == null)
            gameState = GameObject.Find("GameState");
    }


	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            if (isServerEntity)
            {
                Debug.Log(Network.proxyIP);
                gameState.GetComponent<GameState>().recolor();
            }else 
            {
                setC();
            }
            
        }
    }


    [Command]
    private void CmdC()
    {
        gameState.GetComponent<GameState>().recolor();
    }

    public void setC()
    {
        if (!isLocalPlayer)
        {
            Debug.Log("setC - return");
            return;
        }
        Debug.Log("setC - executed");
        CmdC();
    }



    #region controllGameState

    //Control of the ship
    public void setSpeed(float speed)
    {
        if (!isLocalPlayer || isServerEntity)
        {
            Debug.Log("set Speed called as !localPlayer OR ServerEntity");
            return;
        }
        CmdSetSpeed(speed);
    }
    [Command]
    public void CmdSetSpeed(float speed)
    {
        gameState.GetComponent<GameState>().Speed = speed;
    }
    public void setDirection(float direction)
    {
        if (!isLocalPlayer || isServerEntity)
        {
            Debug.Log("set Direction called as !localPlayer OR ServerEntity");
            return;
        }
        CmdSetDirection(direction);
    }
    [Command]
    public void CmdSetDirection(float direction)
    {
        gameState.GetComponent<GameState>().Direction = direction;
    }

    //Cmd from Captain
    public void setLEDUp(bool value)
    {
        if (!isServerEntity)
        {
            Debug.Log("set LED called as !ServerEntity");
            return;
        }
        gameState.GetComponent<GameState>().LEDup = value;
    }
    public void setLEDDown(bool value)
    {
        if (!isServerEntity)
        {
            Debug.Log("set LED called as !ServerEntity");
            return;
        }
        gameState.GetComponent<GameState>().LEDdown = value;
    }
    public void setLEDLeft(bool value)
    {
        if (!isServerEntity)
        {
            Debug.Log("set LED called as !ServerEntity");
            return;
        }
        gameState.GetComponent<GameState>().LEDleft = value;
    }
    public void setLEDRight(bool value)
    {
        if (!isServerEntity)
        {
            Debug.Log("set LED called as !ServerEntity");
            return;
        }
        gameState.GetComponent<GameState>().LEDright = value;
    }

    #endregion controllGameState
}
