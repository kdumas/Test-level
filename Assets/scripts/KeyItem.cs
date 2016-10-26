using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyItem : MonoBehaviour
{
    public float keytime;
     bool PickUpKey;
    bool UsedKey;
    public Text KeyText;

    void Start()
    {

        KeyText.enabled = false;
          PickUpKey = false;
         UsedKey = false;


    }

       void OnTriggerStay(Collider collider)
     {
       if (collider.gameObject.CompareTag("Player"))
     {
       PickUpKey = true;
      KeyText.enabled = true;
    }
       }

     void OnTriggerExit(Collider collider)
    {
      if (collider.gameObject.CompareTag("Player"))
     {
      KeyText.enabled = false;
     PickUpKey = false;
    }
//    if (UsedKey){
  //    Invoke("TakeKey", keytime);
   //}
   }
            void OnTriggerEnter(Collider collider) {
            if (collider.gameObject.name == "Player"){

    
         }
       }

    void update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && (PickUpKey))
        {
            Items.keys += 1;
            UsedKey = true;
            Destroy(gameObject);
            Debug.Log(Items.keys);
        }
    }
    }


    //void TakeKey()
    //{
        //UsedKey = false;
    //}
//}
