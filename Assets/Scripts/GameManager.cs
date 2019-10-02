/*
 * Created by: Omar Balfaqih 2019 (https://obalfaqih)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // To create a Music Notes object, Right click > Create > Music Notes then you can set the notes there using this format "NOTE:ORDER"
    public MusicNotes musicNotes;
    // Storing the notes from the musicNotes variable to this one
    private string[] notes;
    // The notes sounds in this order: A, B, C, D, E, F, G
    public AudioSource[] notesSound;

    // How far each step whether horizontally or vertically
    [Header("Steps")]
    public float stepY = 2.7f;
    public float stepX = 1.786f;
    
    [Header("Tile Settings")]
    // Where to start the first tile
    public Vector2 startPoint;
    // The tile prefab
    public GameObject noteTile;
    // How fast will the tiles slide down
    public float speed = 1;
    // Keeping record of the current Y position to place them on top of each other
    private float currentY;
    // How far can each tile go off screen in the Y axis
    public float screenYLimit = -6.5f;
    // Current score which will be used to count
    private int score = 0;

    [Header("Score")]
    // The UI Text that will show the score
    public Text scoreText;
    // How many tiles were clicked by the player
    private int clickedTiles = 0;

    [Header("Menus")]
    // We will have two menus only, one for the pause and the other one when the game ends whether the plyer wins or loses
    public GameObject pauseMenu;
    public GameObject endMenu;
    // This is another UI Text which will show the score on the end menu
    public Text endScore;

    // To control the game's pause status
    public bool isPaused = true;

    public void Start()
    {
        // Set the notes variable to the notes variable under musicNotes
        notes = musicNotes.notes;
        // Make sure the game is paused in the beginning until the player clicks the "start-tile"
        isPaused = true;
        // Set current Y position to the startPoint's Y
        currentY = startPoint.y;
        // Pre-load and create all the tiles
        InitiateTiles();
    }

    public void InitiateTiles()
    {
        for (int i = 0; i < notes.Length; i++)
        {
            // Since the format is as follow NOTE:ORDER
            // We will separate them into two variables
            // Note: A to G
            // Order: 1 to 4
            string n = notes[i].Split(':')[0];
            int order = int.Parse(notes[i].Split(':')[1]);

            // Create a temporary variable to store the position
            Vector2 _tmpPoint = startPoint;
            // Then modify it based on the order
            _tmpPoint.x += stepX * (order - 1);
            _tmpPoint.y = currentY;

            // Create a single note then assign its variables
            GameObject tmp_note = Instantiate(noteTile, _tmpPoint, Quaternion.identity);
            tmp_note.GetComponent<Note>().note = n;
            tmp_note.GetComponent<Note>().gm = this;

            // Increase the currentY position so the next tile will be placed above the current one
            currentY += stepY * Random.Range(1, 3);
        }
    }

    public void PlayNote(string note)
    {
        // Check which note has to be played then play that sound from the notesSound array
        switch (note)
        {
            case "A":
                notesSound[0].Play();
                break;
            case "B":
                notesSound[1].Play();
                break;
            case "C":
                notesSound[2].Play();
                break;
            case "D":
                notesSound[3].Play();
                break;
            case "E":
                notesSound[4].Play();
                break;
            case "F":
                notesSound[5].Play();
                break;
            case "G":
                notesSound[6].Play();
                break;
        }
        // Give the player a score
        score += 25;
        // Update the score UI Text
        scoreText.text = score.ToString();
        // Increment the clicked tiles
        clickedTiles++;
        // If the player clicked all, end the game and show the end menu
        if (clickedTiles == notes.Length)
            EndGame();
    }

    public void EndGame()
    {
        // Stop tiles from moving
        speed = 0;
        // Pause
        isPaused = true;
        // Show the end menu
        StartCoroutine(ShowEndMenu());
    }

    private IEnumerator ShowEndMenu()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(1);
        // Then show the end menu
        endMenu.SetActive(true);
        // Update the score UI Text on the end menu
        endScore.text = score.ToString();
    }

    public void Pause()
    {
        // If it's paused, resume otherwise, pause
        isPaused = !isPaused;
        // Show the pause menu
        pauseMenu.SetActive(isPaused);
    }

    public void Restart()
    {
        // Play the current level that is playing (Restart)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
