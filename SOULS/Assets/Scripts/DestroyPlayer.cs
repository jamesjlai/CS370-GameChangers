using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{   private turnManager turnManagerScript;
    public int damageAmount=10;
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
        if(collision.gameObject.CompareTag("Player")){
            Destroy(collision.gameObject);
            turnManagerScript.DecreasePlayerHealth(damageAmount);
        }
    }
}
