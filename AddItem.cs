using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class AddItem : MonoBehaviour
{
    [SerializeField] bool fromChest;
    [SerializeField] GameObject chestClosed;
    [SerializeField] GameObject chestOpened;
    [SerializeField] string itemName;
    [SerializeField] Text notificationText;
    [SerializeField] GameObject questDialogue;
    [SerializeField] GameObject questGUI;
    [SerializeField] AudioClip notificationClip;
    [SerializeField] AudioClip openChest;
    [SerializeField] AudioSource audioSource;

    bool isQuestItemCollected = false;
   
    // Start is called before the first frame update
    private void Start()
    {
      
        questGUI.SetActive(false);
        audioSource = GetComponent<AudioSource>();

        if (fromChest)
        {
            
            chestOpened.SetActive(false);
            chestClosed.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (!isQuestItemCollected)
            {
                CollectItem();
                StartCoroutine(NotifyPlayer(5f));

            }
        }
    }

    private IEnumerator NotifyPlayer(float delay)
    {
        audioSource.PlayOneShot(notificationClip);
        
        questGUI.SetActive(true);
        notificationText.text = itemName + " has been collected";
        yield return new WaitForSeconds(delay);
        notificationText.enabled = false;
        questGUI.SetActive(false);
        
        
    }

    

    private void CollectItem()
    {
        
            isQuestItemCollected = true;
            print(itemName + " has been collected");

            if (fromChest)
            {
                OpenChest();
            }
        
    }

    private void OpenChest()
    {
        audioSource.PlayOneShot(openChest);
        chestClosed.SetActive(false);
        chestOpened.SetActive(true);
    }

    public bool GetisQuestItemCollected()
    {
        return isQuestItemCollected;
    }
}
