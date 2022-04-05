using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Text scoreTxt = null;
    public Text lifebarTxt = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //update score
    public void updateScore(int points=0){
        if(scoreTxt!=null){
            scoreTxt.text = "Score:"+points.ToString();
        }
    }
    // update Lifepoints
    // this is a temporal function for testing
    //it gonna be replace for a PointBar object(currently in developmennt)
    public void updateLP(int points = 3,int maxLp =3){
        
        if(lifebarTxt !=null){
            lifebarTxt.text = points.ToString() +"/"+maxLp.ToString();
        }
    
   }
}
