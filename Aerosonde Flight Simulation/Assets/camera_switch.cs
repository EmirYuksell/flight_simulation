using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_switch : MonoBehaviour
{
    public GameObject Camera_1;
    public GameObject Camera_2;
    public GameObject Camera_3; 
    public GameObject Camera_4;
    // Start is called before the first frame update
    void Start()
    {
        Camera_1.SetActive(true);
        Camera_2.SetActive(false);
        Camera_3.SetActive(false);
        Camera_4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Camera_1.SetActive(true);
            Camera_2.SetActive(false);
            Camera_3.SetActive(false);
            Camera_4.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            Camera_1.SetActive(false);
            Camera_2.SetActive(true);
            Camera_3.SetActive(false);
            Camera_4.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            Camera_1.SetActive(false);
            Camera_2.SetActive(false);
            Camera_3.SetActive(true);
            Camera_4.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            Camera_1.SetActive(false);
            Camera_2.SetActive(false);
            Camera_3.SetActive(false);
            Camera_4.SetActive(true);
        }
    }
}
