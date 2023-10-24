using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public GameObject canvas;
    public List<Headfollow> headfollows;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other != null) {

            if (other.tag=="Block")
            {
                canvas.SetActive(true);
            }
            if (other.tag == "Block2")
            {
                foreach (Headfollow headfollow in headfollows)
                {
                    headfollow.enabled=true; 
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other != null)
        {

            if (other.tag == "Block")
            {
                canvas.SetActive(false);
            }
           
        }
    }
}
