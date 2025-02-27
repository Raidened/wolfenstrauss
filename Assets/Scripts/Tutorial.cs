using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tutorial : MonoBehaviour
{
    public GameObject PanelDirection;   
    public GameObject PanelJump;
    public GameObject PanelDash;
    private int index = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        PanelDirection.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(TutorialEvent());
        Debug.Log("Play Tutorial");  
    }

    IEnumerator TutorialEvent()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.D))
        {
            if (index == 0)
            {
                Debug.Log(index);
                Debug.Log("Moved");
                yield return new WaitForSeconds(0.5f);
                PanelDirection.SetActive(false);
                PanelJump.SetActive(true);
                index += 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && index == 1)
        {
            Debug.Log(index);
            Debug.Log("Jumped");
            yield return new WaitForSeconds(0.5f);
            PanelJump.SetActive(false);
            PanelDash.SetActive(true);
            index += 1;
        }
        
        if (Input.GetKeyDown(KeyCode.S) && index == 2)
        {
            Debug.Log(index);
            Debug.Log("Dashed");
            yield return new WaitForSeconds(0.5f);
            PanelDash.SetActive(false);
            index += 1;
        }
    }
}
