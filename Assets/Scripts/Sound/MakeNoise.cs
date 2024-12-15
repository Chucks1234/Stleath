using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MakeNoise : MonoBehaviour
{
    public event UnityAction<Vector3> OnCreateNoise;

    private Transform ownTransform;

    [ContextMenu("Create Noise")]
    public void CreateNoise() => OnCreateNoise?.Invoke(ownTransform.position);



    private void OnEnable() => ownTransform = transform;

    private void OnDisable() => OnCreateNoise = null;

}
