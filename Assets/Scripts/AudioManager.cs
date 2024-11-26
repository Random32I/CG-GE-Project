using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] AudioSource[] Sounds = new AudioSource[8];
    //0: ArrowShoot
    //1: SwordSwoosh
    //2: SwordClang
    //3: HeartGet
    //4: ChestOpen
    //5: EnemyAngry
    //6: EnemyDie
    //7: EnemyPassive

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(int soundIndex, Vector3 pos, float volume)
    {
        Sounds[soundIndex].transform.position = pos;
        Sounds[soundIndex].volume = volume;
        Sounds[soundIndex].Play();
    }

    public void StopSound(int soundIndex)
    {
        Sounds[soundIndex].Stop();
    }
}
