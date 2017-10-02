using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    int hitCount;
    int hitMax;
	LevelManager levelManager;
    public static int breakableCount;
    public Sprite[] hitSprites;
    public AudioClip snapFinger_fx;//if change name, script will break
    public GameObject smoke;
	// Use this for initialization
	void Start () {
        if (tag == "Breakable")
        {
            breakableCount++;
        }
        hitCount = 0;
        hitMax = hitSprites.Length + 1;
		levelManager = FindObjectOfType<LevelManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            if (!SoundController.mute)
            {
				AudioSource.PlayClipAtPoint(snapFinger_fx, transform.position);
            }
            HandleHits();
        }
    }

    void HandleHits()
    {
		hitCount++;
		if (hitCount >= hitMax)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            EmitSmoke();
            Destroy(gameObject);
        }
        else
		{
			LoadSprites();
		}
    }

    void EmitSmoke()
    {
        var puffs = Instantiate(smoke, transform.position, Quaternion.identity);
        //use "as" as cast
        //puffs.GetComponent<ParticleSystem>().main.startColor = GetComponent<SpriteRenderer>().color;
        //have no idea why this ^ doesn't work
        ParticleSystem.MainModule mainModule = puffs.GetComponent<ParticleSystem>().main;
        mainModule.startColor = gameObject.GetComponent<SpriteRenderer>().color;
        Destroy(puffs, mainModule.duration + 2f);
    }

    void LoadSprites()
    {
        int spriteIndex = hitCount - 1;
		if (hitSprites[spriteIndex] == null)
		{
            Debug.LogError("Missing sprite in hitSprites. Fix ASAP!");
        }else
        {
			GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }
}
