/*
 * Created by: Omar Balfaqih 2019 (https://obalfaqih)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundHit : MonoBehaviour
{
    // Referencing the GameManager script
    public GameManager gm;
    // Offtune audio
    public AudioSource offtune;

    // Whenever the player clicks the background
    private void OnMouseDown()
    {
        // Play off-tune audio
        offtune.Play();
        // End the game by calling its method from gm (GameManager)
        gm.EndGame();
    }
}
