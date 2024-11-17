using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cookie : MonoBehaviour
{
    public GameManager manager;
    public UnityEvent onClick;
    public Sprite nextCookieImage;
    public Sprite defaultCookieImage;
    public ParticleSystem skinUnlockParticles;

    bool skinUnlockParticlesPlayed = false;

    void Update()
    {
        if (manager.clicks > 500)
        {
            GetComponent<SpriteRenderer>().sprite = nextCookieImage;
            if(!skinUnlockParticlesPlayed)
            {
                skinUnlockParticles.Play();
                skinUnlockParticlesPlayed = true;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = defaultCookieImage;
            skinUnlockParticlesPlayed = false;
        }

        if (transform.localScale.x > 1f)
        {
            transform.localScale -= Vector3.one * 2 * Time.deltaTime;
        }
    }

    void OnMouseDown()
    {
        transform.localScale = Vector3.one * 1.2f;
        onClick.Invoke();
    }
}
