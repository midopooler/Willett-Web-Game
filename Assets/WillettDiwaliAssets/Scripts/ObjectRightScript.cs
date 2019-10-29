using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRightScript : MonoBehaviour
{

    float RandomN;

    GameObject RocketInstObj;


    RocketInstantiate RInstScript;

    [SerializeField]
    Transform BoomAnim;

    GameObject CoinAudio;

    AudioSource ASCoin;

    GameObject BoomAudio;

    AudioSource ASBoom;

    private void Start()
    {
        RocketInstObj = GameObject.Find("Rocket_Instantiate_Point");

        RandomN = Random.Range(2f, 4f);

        RInstScript = RocketInstObj.GetComponent<RocketInstantiate>();

        CoinAudio = GameObject.Find("SoundHolderCoin");

        ASCoin = CoinAudio.GetComponent<AudioSource>();

        BoomAudio = GameObject.Find("SoundHolderBoom");

        ASBoom = BoomAudio.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(RInstScript.TimerValue<=0)
        {
            Destroy(this.gameObject);
        }

        transform.Translate(RandomN * Time.deltaTime, 0f, 0f);


        if(transform.position.x > 9f)
        {
            Destroy(transform.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Rocket")
        {

            Destroy(collision.gameObject);

            if(gameObject.transform.tag == "Laddu")
            {
               // if (!ASCoin.isPlaying)
                //{
                    ASCoin.Play();
                //}
                RInstScript.ScoreValue++;
            }
            else
            {
                if (RInstScript.ScoreValue > 0)
                {

                    RInstScript.ScoreValue--;
                }
                ASBoom.Play();
                    Instantiate(BoomAnim, transform.position, Quaternion.identity);
                }

            RInstScript.Score();
               
            StartCoroutine(DestroyThis());
        }
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(0.1f);

        Destroy(this.gameObject);
    }
}
