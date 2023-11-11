using UnityEngine;
using UnityEngine.UI;

public class Leaf_Gif_loadManager : MonoBehaviour 
{
    public RawImage ImageInfo;

    public bool useInfo = true;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        ImageInfo = GetComponent<RawImage>();
    }

    private void Update()
    {
        if (ImageInfo.texture != null && useInfo) 
        {
            useInfo = false;
        }
    }
}