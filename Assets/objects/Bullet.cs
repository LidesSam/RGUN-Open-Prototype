using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    int speed = 5;
    Vector3 velocity = new Vector3(0,1,0);
    FoeGenerator factory =null;
    public bool alive = false;
    float toDieCooldown = 3;
    float timeToDie =3;

    Collider  meCollider =null;
    // Start is called before the first frame update
    void Start()
    {
        meCollider = GetComponent<Collider>();
        meCollider.enabled=true;
        alive = true;
        toDieCooldown =timeToDie ;
    }
    /*
        reset values to defaulte   
    */
    public void recycle(){
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        alive=true;
        meCollider.enabled=true;
        toDieCooldown = timeToDie ;
        Show();
            
    }

    private void Awake() {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(alive){
            transform.position += new Vector3(  0, 0, -speed* Time.deltaTime);
            if( toDieCooldown <=0){
                Kill();
            }else{
                toDieCooldown -=Time.deltaTime;
            }
        }
        
    }

     private void Kill(){
        alive=false;
        meCollider.enabled=false;
        Hide();
        
        /**
          add Kill Callback
        */
    }

    public void HitFoe(){
        
        //per default
        Kill();

        /**
            add here effect
        */
    }
    private void Hide(){
        GetComponent<Renderer>().enabled = false;
    }
    private void Show(){
        GetComponent<Renderer>().enabled = true;
    }
}
