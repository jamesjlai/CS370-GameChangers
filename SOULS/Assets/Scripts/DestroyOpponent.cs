using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOpponent : MonoBehaviour
{   public int damageAmount=10;
    private turnManager turnManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        turnManagerScript=GameObject.Find("Turn Manager").GetComponent<turnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Computer")){
            Destroy(collision.gameObject);
            turnManagerScript.DecreaseOpponentHealth(damageAmount);
        }
    }
}
