using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeCardClickable : MonoBehaviour
{
    public UnityEvent unityEvent = new UnityEvent(); //variable to call unity events
    public GameObject button; //variable for button object
    public SlotManager SlotManager;

    // Start is called before the first frame update
    void Start()
    {
        turnManager = GameObject.Find("SlotManager").GetComponent<SlotManager>();
        button = this.gameObject; //setting unity object as button
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //finding where in 3D space the player clicks
        RaycastHit hit; //variable to track where ray intersects with game objects
        if (Input.GetMouseButtonDown(0))
        { //if user clicks
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            { //if click on button
                SlotManager.slot(); //trigger event in separate script
            }
        }
    }
}
