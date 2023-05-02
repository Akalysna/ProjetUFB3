using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class Teleport : MonoBehaviour
    {
        public Transform TPEndPoint;

        public string layer;
        public string sortingLayer;
        private void OnTriggerEnter2D(Collider2D other)
        {
            GameObject.Find("PF Player").GetComponent<Cainos.PixelArtTopDown_Basic.TopDownCharacterController>().transform.position = TPEndPoint.transform.position;
            other.gameObject.layer = LayerMask.NameToLayer(layer);

            other.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayer;
            SpriteRenderer[] srs = other.gameObject.GetComponentsInChildren<SpriteRenderer>();
            foreach ( SpriteRenderer sr in srs)
            {
                sr.sortingLayerName = sortingLayer;
            }
        }
    }