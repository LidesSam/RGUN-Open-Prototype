using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{



    //Weapon Vars
    public Bullet bullet =null;
    public List<Bullet> bulletList;
    public int maxBullets= 10;
    Weapon weapon =null;
    public float cooldown = 0.0f;
    public float cooldown_time = 1.0f;
    //Weapon Vars end

    //movemente Vars
    //float speed = 80.0f;

    bool moving = false;
    Vector2 velocity = new Vector2(0, 0);
    Vector2 inGridPosition= new Vector2(0,0);

    public int maxLp=3;
    int lp=3;
    int dir =1;

    //Audio player
    AudioSource audioSource = null;
    //sfx
    public AudioClip damageSfx =null;


   
    void Start()
    {
        cooldown=0;
        bulletList = new List<Bullet>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.SharedInstance.currentGameState == GameManager.InGameState){

         if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
        }
        
        //move To Left
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            dir=-1;
            moving = true;
            inGridPosition=inGridPosition - new Vector2(1,0);
            if(inGridPosition.x<-2){
                inGridPosition.x=-2;
            }   
        }

        //move To Right
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            dir=1;
            moving = true;
            inGridPosition=inGridPosition + new Vector2(1,0);
            if(inGridPosition.x>2){
                inGridPosition.x=2;
            }   
        }

        if(Input.GetKeyDown(KeyCode.X)){
           Shot();
        }

        if (moving) { 
            
            //place on grid
            //for test position on the grid
            /**note: this grid is relative to the start position
            //Eventually the position gonna be take fom a singleton that manage these*/

            transform.position = new Vector3(-inGridPosition.x,transform.position.y,transform.position.z);
            //right side
            /**
            if(dir ==1){
                if(transform.position.x >=-inGridPosition.x){
                        moving ==false
                        //to adjust if pass out of range.
                        //transform.position = new Vector3(-inGridPosition.x,transform.position.y,transform.position.z);
                }
                else{
                    translate
                }
            }
            */
             //left side 
             //repeat Right side invert values of checks
            
        }

        

     if(cooldown>0){
            cooldown-=Time.deltaTime;
            
             if(cooldown<0){
                print("timeout");
             }
        }
        
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        print("trigger foe:"+other.tag);
        //Check to see if the tag on the collider is equal to Enemy
        if (other.tag == "foe")
        {
             //GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
         

            lostLP();
            FoeController othercomponent = other.gameObject.GetComponent<FoeController>();
         
            //Make sure this component actually exists
            if(othercomponent == null){
                Debug.Log("No enemy script is attached to the colliding object");
                return;
            }
            
            othercomponent.Kill();
        }
        /**
        //code fragement to handle colltion with enemy bullets
        if (other.tag == "foebullet")
        {
            lostLP();
     
            
            Bullet othercomponent = other.gameObject.GetComponent<Bullet>();
         
            //Make sure this component actually exists
            if(othercomponent == null){
                Debug.Log("No enemy script is attached to the colliding object");
                return;
            }
            othercomponent.HitFoe();
            
        }*/
    }

    public void lostLP(int points=1){
        print("loastLp");
        lp-=points;
        if(lp<=0){
            lp=0;
            //here call change game state to Game Over
        }

        GameManager.SharedInstance.Hud.updateLP(lp,maxLp);
        //play damage Sfx
        audioSource.PlayOneShot(damageSfx, 0.7F);
    }
    //move it and vars to weapon
    void Shot(){
         if(cooldown<=0){
            cooldown = cooldown_time;
            
            if(bulletList.Count<maxBullets){
                Bullet instbullet = Instantiate(bullet,transform.position, Quaternion.identity) as Bullet;
                bulletList.Add(instbullet);
            }
            else{
                for (int i = 0; i < bulletList.Count; i++)
                {
                    
                    if(!bulletList[i].alive){
                        print("recycle bullet Nr"+i);
                        Bullet pooledbullets = bulletList[i];
                        pooledbullets.recycle();
                        pooledbullets.transform.position =transform.position;
                        }
                }
            }
         }
     }
}
