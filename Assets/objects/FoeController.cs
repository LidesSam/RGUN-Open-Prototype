using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeController : MonoBehaviour
{

    int speed = 5;
    Vector3 velocity = new Vector3(0,1,0);
    FoeGenerator factory =null;
    public bool alive = false;
    Collider  meCollider =null;
    // Start is called before the first frame update
    void Start()
    {
        meCollider = GetComponent<Collider>();
        meCollider.enabled=true;
        alive=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(alive){
            transform.position += new Vector3(  0, 0, speed * Time.deltaTime);
        }
    }

    /*
        reset values to defaulte   
    */
    public void recycle(){
     
        alive=true;
        meCollider.enabled=true;
        GetComponent<Renderer>().enabled = true;
            
    }

    /**private void Awake() {
        
    }*/
    
    void Set_Factory(FoeGenerator _Factory){
        factory=_Factory;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("trigger foe:"+other.tag);
        //Check to see if the tag on the collider is equal to Enemy
        if (other.tag == "foeout")
        {
            Debug.Log("Triggered by Enemy");
            alive=false;
             //GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
            GetComponent<Renderer>().enabled = false;
            
        }

        if (other.tag == "bullet")
        {

            this.Kill();
            
            GameManager.SharedInstance.addPointsToScore(1);     
            
            Bullet othercomponent = other.gameObject.GetComponent<Bullet>();
         
            //Make sure this component actually exists
            if(othercomponent == null){
                Debug.Log("No enemy script is attached to the colliding object");
                return;
            }
            othercomponent.HitFoe();
            
        }
    }

    public void Kill(){
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        alive=false;
        meCollider.enabled=false;
        Hide();
            
    }

    private void Hide(){
        GetComponent<Renderer>().enabled = false;
        
    }
    private void Show(){
        GetComponent<Renderer>().enabled = true;
    }


}
