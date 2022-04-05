using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FoeGenerator : MonoBehaviour
{   
    float cooldown = 0;
    public FoeController foe = null;
    
    public List<FoeController> FoeList;

    public int maxFoes = 5 ;
    public int mininterval= 2 ;
    public int maxinterval= 5 ;
    
    

    //public list<FoeController> =null;
    // Start is called before the first frame update
    void Start()
    {
  
       FoeList= new List<FoeController>();
        
       cooldown = 2;
    }

    // Update is called once per frame
    void Update()
    {
         if (cooldown <= 0)
        {
            cooldown = Random.Range(mininterval,maxinterval);
            
            //cooldown=1;
           
            GenFoe();
            
        }
        else {
            cooldown -= Time.deltaTime;
        }
    }

    private void GenFoe(){
        //print("flistCOunt:"+FoeList.Count);
        int gridpos = Random.Range(-2,2);
        if(FoeList.Count<maxFoes){
            FoeController instFoe = Instantiate(foe,transform.position+new Vector3(gridpos,0,0), Quaternion.identity) as FoeController;
            FoeList.Add(instFoe);
        }
        else{
            for (int i = 0; i < FoeList.Count; i++)
            {
                if(!FoeList[i].alive){
                    FoeController pooledFoe = FoeList[i];
                    pooledFoe.recycle();
                    pooledFoe.transform.position =transform.position+new Vector3(gridpos,0,0);
                    }
            }
        }
    }
  
}
