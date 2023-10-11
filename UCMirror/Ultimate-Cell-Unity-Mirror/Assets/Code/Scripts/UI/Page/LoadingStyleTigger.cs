using UnityEngine;
using DG.Tweening;

public class LoadingStyleTigger : MonoBehaviour 
{
    public GameObject LoadIcon;

    private void Start()
    {
        Transform targetTransform = LoadIcon.transform;

        float duration = 1.0f;

        targetTransform.DORotate(new Vector3(0, 0, 360), duration, RotateMode.FastBeyond360)
            .SetLoops(-1)
            .SetEase(Ease.Linear);
    }
}