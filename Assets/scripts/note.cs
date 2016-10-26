using UnityEngine;
using UnityStandardAssets.Utility;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class note : MonoBehaviour {
    [SerializeField]private AudioClip message;
    private AudioSource m_audiosource;

    void start()
    {
        m_audiosource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            Items.notes+=1;
            Playmessage();
            Destroy(gameObject);
            Debug.Log(Items.notes);
        }
    }

    private void Playmessage()
    {
        m_audiosource.clip = message;
        m_audiosource.Play();
    }

}