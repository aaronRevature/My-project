using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

    public class AutoAim : MonoBehaviour
    {
        public bool IsAuto;
        private GunControl gunControl;
        private GameObject fish;
        
        private void Awake()
        {
            
            fish = GameObject.FindWithTag("fish");
          gunControl =  GetComponent<GunControl>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (IsAuto)
            {
                if (TryGetComponent<Swim>(out Swim swim))
                {
                SetTarget(fish);
                    gunControl.Fire();


                }
            }
        }
      public void SetTarget(GameObject fish)
        {
            this.fish = fish;
        }
    
    }
