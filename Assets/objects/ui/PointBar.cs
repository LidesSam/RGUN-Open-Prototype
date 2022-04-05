using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//multipropource bar made of points
//this is for visual propource and don't manipulate the variables(like lp, mp, energy, etc) directly
//this allow to make posible manipulate the var while the visual effect is playing
public class PointBar : MonoBehaviour
{

    //life texture
    public Texture lpTexture = null;
    //empy life texture
    public Texture lpTextureOut = null;
    
    List<Image> sprPoints = null;


    //indicate if the var is refilling
    bool onRefill = false;
    //used to indicate when have to stop updating the bar
    int refillLimit =0;
    //this
    int currentFullPoints =0;
    
    // Start is called before the first frame update
    void Start()
    {
        update_lp();
    }

    public void update_lp(int points=3, int maxPoints=3){
        
        sprPoints= new List<Image>();
        for(var i=0; i<maxPoints;i++){
            //Image point = new Image();
            if(i<=points){
                ////full point
                // point = lpTextureOut
            }
            else{
                //// empty Point
                // point = lpTextureOut
            }
            
        }

    }
    

    // Update is called once per frame
    void Update()
    {
        if(onRefill){
                /** here go the code to refill the point bar(like megaman/rockman)
                this don't affect the real value of the point 
                */
                if(currentFullPoints >= refillLimit){
                    if(currentFullPoints >refillLimit){
                        //aply correction
                    }
                    onRefill=false;    
                }else{

                    currentFullPoints+=1;
                    //// get point texture 
                    // Texture currentpoint = list[curretFullPoints];
                    ////change texture here here
                    // currentpoint = lpTextureOut
                }

        }

    }
}