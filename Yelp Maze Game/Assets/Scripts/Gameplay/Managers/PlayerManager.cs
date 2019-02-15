/* Manages the player within the game world */

/* Builtin */
using System.Collections;
using System.Collections.Generic;

/* Unity */
using UnityEngine;

namespace KelpMaze.Gameplay
{
    /*! \brief Manages the players resources
     * 
     * The player receives an input handler to
     * be able to use controls to play the game
     */
    public class PlayerManager : MonoBehaviour
    {
        public void Start()
        {
            audio = this.gameObject.GetComponent<AudioSource>();

            inventory = new List<Equipable>();
            conch = new ConchItem();
            sword = new SwordItem();

            conchMesh = GameObject.Find("ConchArm");
            swordMesh = GameObject.Find("ArmwithSword");
            branchMesh = GameObject.Find("ArmwithBranch");

            conchMesh.SetActive(hasConch);
            swordMesh.SetActive(hasSword);
            branchMesh.SetActive(hasSword);

            if (hasSword && hasConch) // Use case if both objects enabled in UI
            {
                branchMesh.SetActive(false);
                swordMesh.SetActive(false);
            }

            swordLevel = 1;
        }

        /* uses the current item */
        public void UseItem()
        {
            if (currentItem != null)
                currentItem.Execute(this);
            else
                Debug.Log("I have no items!");
        }

        public void SwapItem()
        {
            int len = inventory.Count;
            if (len > 1)
            {
                Equipable prevItem = currentItem;
                int idx = inventory.IndexOf(currentItem);
                Debug.Log("Swapping items!");
                if(idx+1 < len)
                {
                    currentItem = inventory[idx + 1];
                }
                else
                {
                    currentItem = inventory[0];
                }

                if(currentItem == conch)
                {
                    swordMesh.SetActive(false);
                    branchMesh.SetActive(false);
                    conchMesh.SetActive(true);
                }
                else if (currentItem == sword)
                {
                    if(swordLevel == 1)
                    {
                        conchMesh.SetActive(false);
                        swordMesh.SetActive(false);
                        branchMesh.SetActive(true);
                    }
                    else
                    {
                        conchMesh.SetActive(false);
                        branchMesh.SetActive(false);
                        swordMesh.SetActive(true);
                    }
                }

                if(currentItem != prevItem)
                {
                    audio.clip = swapItemClip;
                    audio.Play();
                }
            }
        }

        public void AddConchToInventory()
        {
            if (currentItem == sword)
            {
                branchMesh.SetActive(false);
                swordMesh.SetActive(false);
            }

            Debug.Log("Adding conch to inventory!");
            hasConch = true;
            inventory.Add(conch);
            currentItem = conch;
            conchMesh.SetActive(true);
            audio.clip = equipConchClip;
            audio.Play();
        }

        public void AddSwordToInventory()
        {
            if (currentItem == conch)
                conchMesh.SetActive(false);

            if(hasSword)
            {
                LevelUpSword();
                return;
            }

            Debug.Log("Adding sword to inventory!");
            hasSword = true;
            inventory.Add(sword);
            currentItem = sword;
            branchMesh.SetActive(true);
            audio.clip = equipSwordClip;
            audio.Play();
        }

        public void LevelUpSword()
        {
            Debug.Log("Leveling up sword");
            if (swordLevel == 1)
            {
                branchMesh.SetActive(false);
                swordMesh.SetActive(true);
            }
            swordLevel++;
        }

        public List<Equipable> inventory;
        public Equipable currentItem;

        public ConchItem conch;
        public SwordItem sword;

        public GameObject conchMesh;
        public GameObject branchMesh;
        public GameObject swordMesh;
        public int swordLevel;

        public AudioSource audio;

        public AudioClip equipSwordClip;
        public AudioClip swordHitClip;

        public AudioClip equipConchClip;
        public AudioClip useConchClipNo;
        public AudioClip useConchClipYes;
        public AudioClip useConchClipMaybe;

        public AudioClip swapItemClip;

        // Lame but useful for game jam purposes
        public bool hasConch;
        public bool hasSword;
    }
} /* KelpMaze.Gameplay */