/*
 * Created by: Omar Balfaqih 2019 (https://obalfaqih)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Adding a shortcut to create a new MusicNotes
// [Right click > Create > Music Notes]
[CreateAssetMenu]
public class MusicNotes : ScriptableObject
{
    // Assigning the music notes following this format [NOTE:ORDER]
    // NOTE: A - G
    // ORDER: 1-4
    [Header("Format: [Note:Order] (Ex: A:3)")]
    public string[] notes;

    // To test it out, you can give the MusicNotes a randomized notes by clicking the Gear icon > Randomize
    [ContextMenu("Randomize")]
    public void Randomize()
    {
        // Random range for the notes for anything from 25 to 49 notes
        notes = new string[Random.Range(25, 50)];
        // All the notes letters
        string[] letters =
        {
            "A", "B", "C", "D", "E", "F", "G"
        };
        // Going through them one by one and give it a random note (A-G) with a random order (1-4)
        for (int i = 0; i < notes.Length; i++)
            notes[i] = letters[Random.Range(0, 7)] + ":" + Random.Range(1, 5);
    }
}
