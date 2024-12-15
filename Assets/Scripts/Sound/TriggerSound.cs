using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class TriggerSound : MonoBehaviour
{
    public UnityEvent<Vector3> OnHeardSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MakeNoise>(out MakeNoise makeNoise))
        {
            makeNoise.OnCreateNoise += ListenForNoise;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<MakeNoise>(out MakeNoise makeNoise))
        {
            makeNoise.OnCreateNoise -= ListenForNoise;
        }
    }

    private void ListenForNoise(Vector3 worldPositionOfNoise)
    {
        OnHeardSound.Invoke(worldPositionOfNoise);
    }

}
