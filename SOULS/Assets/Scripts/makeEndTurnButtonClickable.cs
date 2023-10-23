using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //added to trigger events


public class makeEndTurnButtonClickable : MonoBehaviour
{
    public UnityEvent unityEvent = new UnityEvent(); //variable to call unity events
    public GameObject button; //variable for button object
    public turnManager turnManager;

    // Start is called before the first frame update
    void Start()
    {
        turnManager = GameObject.Find("turnManager").GetComponent<turnManager>();
        button = this.gameObject; //setting unity object as button
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //finding where in 3D space the player clicks
        RaycastHit hit; //variable to track where ray intersects with game objects
        if(Input.GetMouseButtonDown(0)) { //if user clicks
            if(Physics.Raycast(ray,out hit) && hit.collider.gameObject == gameObject) { //if click on button
                turnManager.endTurn(); //trigger event in separate script
            }
        }
    }
}
