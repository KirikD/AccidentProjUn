//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem.Sample
{
    public class RenderModelChangerUI : UIElement
    {
        public GameObject leftPrefab;
        public GameObject rightPrefab;

        protected SkeletonUIOptions ui;

        protected override void Awake()
        {
            base.Awake();

            ui = this.GetComponentInParent<SkeletonUIOptions>();
            //Invoke(nameof(OnButtonClick),1);
        }
        void Start() {
            if (this.gameObject.name == "thick glove")
            {
                Invoke(nameof(OnButtonClick), 1);
             
            }
        }
        public void SetGloves() { OnButtonClick(); }
        protected override void OnButtonClick()
        {
            GameObject.Find("TestObjects").SetActive(false);
            Debug.Log("RenderModelChangerUI  SetGloves " + this.gameObject.name);
            base.OnButtonClick();

            if (ui != null)
            {
                ui.SetRenderModel(this);
            }
        }
    }
}