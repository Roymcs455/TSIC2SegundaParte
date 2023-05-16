using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public GameObject[] levels;
    int currentLevel = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Advance()
    {
        currentLevel++;
        switch (currentLevel)
        {   
            default:
                currentLevel = 0;
                levels[0].SetActive(true);
                levels[1].SetActive(false);
                levels[2].SetActive(false);
            break;
            case 0:
                levels[0].SetActive(true);
                levels[1].SetActive(false);
                levels[2].SetActive(false);
            break;
            case 1:
                levels[0].SetActive(false);
                levels[1].SetActive(true);
                levels[2].SetActive(false);

            break;
            case 2:
                levels[0].SetActive(false);
                levels[1].SetActive(false);
                levels[2].SetActive(true);
            break;
        }

    }
}
