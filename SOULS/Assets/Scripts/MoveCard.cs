using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCard : MonoBehaviour
{
    Camera playerCam;
    Camera computerCam;
    private turnManager turnManagerScript;
    bool hasMoved,onAttack,playerTurn,opponentTurn;
    private int playerCount,opponentCount=0;
    public int damageAmount=10;
    // Start is called before the first frame update
    void Start()
    {
        hasMoved = false;
        onAttack=false;
        playerTurn=true;
        opponentTurn=false;

        playerCam = GameObject.Find("mainCamera").GetComponent<Camera>();
        computerCam = GameObject.Find("tableCamera").GetComponent<Camera>();

        playerCam.gameObject.SetActive(true);
        //computerCam.gameObject.SetActive(false);
        turnManagerScript=GameObject.Find("Turn Manager").GetComponent<turnManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Player"))
        {
            MoveCardForward("Player");
            //SwitchToPlayerCam();
            //turnManagerScript.endTurn(); //switch over to computer's turn
        }

        if (gameObject.CompareTag("Computer"))
        {
            MoveCardForward("Computer");
            //SwitchToComputerCam();
            //turnManagerScript.playerTurn(); //switch over to player's turn
        }
    }

    public void MoveCardForward(string turn)
    {   
        if (turn == "Player")
        {   playerTurn=true;
            opponentTurn=false;
            if (!hasMoved)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
                playerCount++;
                hasMoved = true;
            }
            else if(hasMoved && playerCount==1 ){
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.5f);
            }
           
            playerTurn=false;
            opponentTurn=true;
            
        }
        else if (turn == "Computer")
        {   playerTurn=false;
            opponentTurn=true;
            if (!hasMoved)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
                opponentCount++;
                hasMoved = true;
            }
            else if(hasMoved && opponentCount==1){
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.5f);
            }
            
            opponentTurn=false;
            playerTurn=true;
            
        }
    }

    public void SwitchToPlayerCam()
    {
        playerCam.gameObject.SetActive(true);
        computerCam.gameObject.SetActive(false);
    }

    public void SwitchToComputerCam()
    {
        playerCam.gameObject.SetActive(false);
        computerCam.gameObject.SetActive(true);
    }
    
        

        
        
        
    
}
