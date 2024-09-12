using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialLoop : MonoBehaviour
{
    [SerializeField] private float speedLoop = 0.25f;
    private Vector2 _offSet = Vector2.zero;
    private Material _meshMaterial;

    private void Start() {
        _meshMaterial = GetComponent<Renderer>().material;
        _offSet = _meshMaterial.GetTextureOffset("_MainTex");
    }

    private void FixedUpdate() {
        _offSet.x += speedLoop * Time.deltaTime;
        _meshMaterial.SetTextureOffset("_MainTex", _offSet);
    }
}
