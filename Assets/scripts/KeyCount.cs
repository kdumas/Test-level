using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyCount : MonoBehaviour {


    public Text CountText;


    private static int count;



    void Start()
    {


        count = 0;
        setCount();


    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            setCount();
        }


    }

    public void Use(int waste)
    {
        count -= waste;
        CountText.text = ("Key(s) " + count);
        if(count <= 0)
        {
            count += waste;
        }

    }

   public void setCount()
    {
        CountText.text = "Key(s): " + count.ToString();
    }
}