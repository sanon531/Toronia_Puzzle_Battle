using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BurnTheUI : MonoBehaviour
{
    [SerializeField] Image TargetImage;
    [SerializeField] Material TargetMaterial;

    // Start is called before the first frame update
    void Start()
    {
        TargetImage = GetComponent<Image>();
    }

    public void Burn()
    {
        StartCoroutine(BurnCoroutine());
    }

    IEnumerator BurnCoroutine()
    {
        float fadeAmount = TargetImage.material.GetFloat("_FadeAmount");
        TargetImage.material.SetFloat("_FadeAmount", 0f);

        while (fadeAmount < 1)
        {
            fadeAmount = TargetImage.material.GetFloat("_FadeAmount");
            yield return new WaitForFixedUpdate();
            TargetImage.material.SetFloat("_FadeAmount", fadeAmount + 0.01f);
            Debug.Log("_FadeAmount__setted");
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
