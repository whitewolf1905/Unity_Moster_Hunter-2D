using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public AudioSource Die;
    private void GameOverSound()
    {
        Die.Play();
    }
}
