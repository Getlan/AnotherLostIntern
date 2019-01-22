using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderRandomGenerator : MonoBehaviour
{
    [SerializeField] private Animator thunderAnim;
    [SerializeField] private Animator windowAnim;
    private int random;
    private bool fadeOut = false;
    private float initialGlowValue = 0f;
    private float glowValue = 5f;

    private float sfxTimer = 0f;
    [SerializeField] private AudioSource thunderSfx;

    private void Start()
    {
        StartCoroutine(Thunder());
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeOut && glowValue > initialGlowValue)
        {
            glowValue -= 3f * Time.deltaTime;
            StepManager.instance.GlowObjects(glowValue);
        }
        else if (glowValue <= initialGlowValue)
        {
            fadeOut = false;
        }
    }

    private IEnumerator Thunder()
    {
        random = Random.Range(15, 30);
        yield return new WaitForSeconds(random);
        glowValue = 5f;
        thunderAnim.SetTrigger("Thunder");
        windowAnim.SetTrigger("Thunder");
        thunderSfx.Play();
        StepManager.instance.GlowObjects(glowValue);
        yield return new WaitForSeconds(1.5f);
        fadeOut = true;
        StartCoroutine(Thunder());
    }
}
