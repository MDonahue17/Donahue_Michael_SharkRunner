using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRemain : MonoBehaviour
{

    private static MusicRemain instance = null;

    MusicRemain Instance
    {
        get { return instance; }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        } else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
