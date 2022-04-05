using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Bullet bullet =null;
    //pool list for Bullets
    public List<Bullet> bulletpolling;
    public int maxBullets = 5;
    //cooldown between Shots(Timer)
    float cooldown = 0;

    //cooldown between Shots
    public float cooldown_time = 3;


    int bullet_per_shot = 1;
    //varitation function
    //function deviation
    
    //using only for burst weapon/ -1 mean disabled
    public float burstTimes =-1;
    public float burst_cooldown =-1;
    
    

    // object that own this one
    //use for callbacks
    GameObject parent =null;
    
    void Start()
    {
         bulletpolling = new List<Bullet>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown>0){
            cooldown-=Time.deltaTime;
        }
        

    }

    //single shot with pooling
    //for thest
    void Shot(){
         if(cooldown<=0){
            cooldown=cooldown_time;

            if( bulletpolling.Count<maxBullets){
                Bullet instbullet = Instantiate(bullet,transform.position, Quaternion.identity) as Bullet;
                 bulletpolling.Add(instbullet);
            }
            else{
                for (int i = 0; i < bulletpolling.Count; i++)
                {
                    if(! bulletpolling[i].alive){
                        Bullet pooledbullets = bulletpolling[i];
                        pooledbullets.recycle();
                        pooledbullets.transform.position =transform.position;
                        }
                }
            }
         }
     }

}
