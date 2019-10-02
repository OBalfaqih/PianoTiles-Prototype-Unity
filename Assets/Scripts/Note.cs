/*
 * Created by: Omar Balfaqih 2019 (https://obalfaqih)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Require Animator component, if it's not attached, it will attach one by default
[RequireComponent(typeof(Animator))]

public class Note : MonoBehaviour
{
    // Set this true only for the first tile that starts the game
    public bool startTile = false;
    // Game Manager
    public GameManager gm;
    // The two variables below will be assigned by the GameManager (gm) once it's created
    [HideInInspector]
    public string note;
    private float limit;

    // Has this button been pressed?
    private bool active;
    // The animator component which will be assigned in the Awake method
    private Animator anim;


    private void Awake()
    {
        // Assign anim to the Animator that's attached to this gameObject
        anim = GetComponent<Animator>();
        // Set it to active
        active = true;
    }

    private void Start()
    {
        // Get limit from the GameManager
        limit = gm.screenYLimit;
        // If this is the frist tile "start-tile"
        if(startTile)
        {
            // Give it a random position in the X axis
            Vector2 randomPos = transform.position;
            randomPos.x += gm.stepX * Random.Range(0, 4);
            transform.position = randomPos;
        }
    }

    private void LateUpdate()
    {
        // Return if the game is paused
        if (gm.isPaused)
            return;
        // Slide the tile down with the speed which is set in the GameManager
        transform.Translate(new Vector3(0, -gm.speed * Time.deltaTime, 0));
        // Check if it's active and it crossed the Y limit
        if (active && transform.position.y < limit)
            gm.EndGame(); // End the game
    }

    // Once the tile is clicked
    private void OnMouseDown()
    {
        // Check if it's active and the game isn't paused
        if (active && !gm.isPaused)
        {
            // Play the note this tile has by calling the PlayNote method from the GameManager
            gm.PlayNote(note);
            // Play the fade out animation by triggering the "FadeOut" parameter
            anim.SetTrigger("FadeOut");
            // Deactiviate this tile
            active = false;
        }

        // If it's the start-tile then we will do the same but instead of playing a note, we will just start the game
        if (startTile)
        {
            anim.SetTrigger("FadeOut");
            active = false;
            gm.isPaused = false;
        }
    }

    public void Remove()
    {
        // Simply destroy this tile
        Destroy(gameObject);
    }
}
