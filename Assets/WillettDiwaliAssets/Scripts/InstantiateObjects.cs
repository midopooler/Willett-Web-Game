using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjects : MonoBehaviour
{
    [SerializeField]
    Transform[] Objects;

    int RandomObj;
    //Transform Obj;

    float TimeAdd= 2f;
    float TimeUp;

	GameObject RocketInstObj;

    AudioSource AS;

	RocketInstantiate RInstScript;

	void Start()
    {
		RocketInstObj = GameObject.Find("Rocket_Instantiate_Point");
		RInstScript = RocketInstObj.GetComponent<RocketInstantiate>();
        
	}

   
    void Update()
    {
        if(RInstScript.TimerValue<=0)
        {
            return;
        }

        RandomObj = Random.Range(0, 2);
        if (Time.time > TimeUp)
        {
            Instantiate(Objects[RandomObj], transform.position, Quaternion.identity);

            //RandomN = Random.Range(1.5f,)

            TimeUp = Time.time + TimeAdd;

        }
    }
}
