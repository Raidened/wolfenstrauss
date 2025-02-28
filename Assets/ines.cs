using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ines : MonoBehaviour
{
    
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InesAnimation();
    }
    
    private IEnumerator InesAnimation()
    {
        anim.SetInteger("Dir", 0);
        yield return new WaitForSeconds(2);
        anim.SetInteger("Dir", 1);
        yield return new WaitForSeconds(2);
    }
}
