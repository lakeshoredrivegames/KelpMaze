using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace KelpMaze.Gameplay
{
    public class Breakable : MonoBehaviour
    {
        private void Start()
        {
            audio = this.gameObject.AddComponent<AudioSource>();
            originalPos = this.gameObject.transform.localPosition;
        }

        /* Got hit by something */
        public void Hit(PlayerManager player)
        {
            if(player.swordLevel >= minimumSwordLevel)
            {
                audio.clip = attackedClip;
                audio.Play();
                Health -= player.swordLevel;
                isShaking = true;
                if (Health <= 0)
                    Broken(player);
            }
        }

        public void Update()
        {
            if(isShaking)
            {
                if(shakeDuration > 0)
                {
                    this.gameObject.transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
                    shakeDuration -= Time.deltaTime * decreaseFactor;
                }
                else
                {
                    shakeDuration = 0.1f;
                    this.gameObject.transform.localPosition = originalPos;
                    isShaking = false;
                }
            }

        }

        public void Broken(PlayerManager player)
        {
            audio.clip = brokenClip;
            audio.Play();
            Destroy(this.gameObject);
        }

        public int Health;
        public int minimumSwordLevel;
        public AudioClip attackedClip;
        public AudioClip brokenClip;
        public AudioSource audio;

        private Vector3 originalPos;
        private float shakeDuration = 0.1f;
        private float shakeAmount = 0.1f;
        private float decreaseFactor = 1.0f;
        public bool isShaking;
    }
}
