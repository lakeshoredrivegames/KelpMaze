using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KelpMaze.Gameplay
{
    public class SwordItem : Equipable
    {
        private float maxAttackRange = 1.5f;
        private float swordCooldown = 0.5f;
        private bool isCooling;
        private float swordCooldownTime;
        private ParticleSystem playerParticles;
        
        public override void Execute(PlayerManager player)
        {
            if (isCooling)
            {
                if (Time.time >= swordCooldownTime)
                {
                    isCooling = false;
                }
            }
            else
            {
                Debug.Log("Swinging the sword!");

                // Play particle
                playerParticles = player.GetComponent<ParticleSystem>();
                playerParticles.Emit(10);


                Animator anim;
                if(player.swordLevel == 1)
                {
                    anim = player.branchMesh.GetComponent<Animator>();
                    player.audio.clip = player.swingBranchClip;
                }
                else
                {
                    anim = player.swordMesh.GetComponent<Animator>();
                    player.audio.clip = player.swingSwordClip;
                }
                if(anim != null)
                {
                    anim.Play("SwordSlash");
                }
                player.audio.Play();

                // Check if hit object
                GameObject playerObj = player.gameObject;
                RaycastHit hit;

                Debug.DrawRay(playerObj.transform.position, playerObj.transform.forward, Color.green);
                if (Physics.Raycast(playerObj.transform.position, playerObj.transform.forward, out hit, maxAttackRange))
                {
                    if(hit.transform != null)
                    {
                        player.audio.clip = player.swordHitClip;
                        player.audio.Play();
                        Breakable breakableObj = hit.transform.gameObject.GetComponent<Breakable>();
                        if(breakableObj != null)
                        {
                            breakableObj.Hit(player);
                        }
                    }
                }
                isCooling = true;
                swordCooldownTime = Time.time + swordCooldown;
            }
        }

        
    }
}
