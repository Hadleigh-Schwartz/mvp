using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanEvap : MonoBehaviour
{
    public GameObject evapButton;
    public GameObject drizzle;
    public bool canEvap;
    // Start is called before the first frame update
    void Start()
    {
        canEvap = false;
        evapButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (drizzle.transform.position.y > 18)
        {
            canEvap = true;
        }
        if (canEvap = true)
        {
            evapButton.SetActive(true);
        }
    }
}
