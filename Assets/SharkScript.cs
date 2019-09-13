using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkScript : MonoBehaviour
{
    public GameObject pause;
    public bool dead = false;
    private GameObject ls;
    public LevelSwitcher levelSwitcher;
    public GameObject lost;


    // Start is called before the first frame update
    void Start()
    {
        pause = GameObject.Find("Pause_Menu");
        lost = GameObject.Find("Lose_Text");
        ls = GameObject.Find("LevelSwitcher");
        //level = ls.
        lost.active = false;
        pause.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!pause.active && !dead)
        {
            Vector3 temp = new Vector3(0, 0, 0.2f);
            gameObject.transform.position += temp;

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                temp = new Vector3(-0.1f, 0, 0);
                gameObject.transform.position += temp;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                temp = new Vector3(0.1f, 0, 0);
                gameObject.transform.position += temp;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause.active)
            {
                pause.active = false; 
            }
            else
            {
                pause.active = true;
            }
        }

    }

    public void OnCollisionEnter(Collision col)
    {
        if(col.transform.tag == "Die")
        {
            dead = true;
            StartCoroutine(YouAreDeadNow());
            levelSwitcher.GoToLevelOne();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Goldfish_Prefab")
        {
            GameData.AddPoints(100);
        }

    }



        IEnumerator YouAreDeadNow()
    {
        lost.active = true;
        yield return new WaitForSeconds(2);
        lost.active = false;        
    }
}
