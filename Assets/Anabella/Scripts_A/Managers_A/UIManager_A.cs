using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Changed completely. Added almost every field and method
/// Also added library UnityEngine.UI;
/// </summary>
public class UIManager_A : MonoBehaviour
{
    [SerializeField] private GameObject gameActivePanel;
    [SerializeField] private TMP_Text healthTxt;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text scoreTxt;
    [SerializeField] private TMP_Text highScoreTxt;

    [SerializeField] private GameObject gameOverPanel;

    private Stack<Image> nukePickups = new Stack<Image>();
    [SerializeField] private Image nukePickupImg;
    [SerializeField] private Vector2 pickupStackPos;
    private int nukePickupCount = 0;
    public int NukePowerupCount { get { return nukePickupCount; } private set { nukePickupCount = value; } }

    private void OnEnable()
    {
        GameEvents.CollectNukePowerup += AddNukePickup;
        GameEvents.ActivateNukePowerUp += UseNukePickup;
        GameEvents.GameOver += GameOverUI;
    }

    private void OnDisable()
    {
        GameEvents.CollectNukePowerup -= AddNukePickup;
        GameEvents.ActivateNukePowerUp -= UseNukePickup;
        GameEvents.GameOver -= GameOverUI;
    }

    private void Start()
    {
        UpdateHighScore();
    }

    public void UpdateScore()
    {
        scoreTxt.text = $"Score: {GameManager_A.GetInstance().scoreManager.GetScore()}";
    }

    public void UpdateHighScore()
    {
        highScoreTxt.text = $"High Score: {GameManager_A.GetInstance().scoreManager.GetHighScore()}";
    }


    public void UpdateHealth(float _health)
    {
        healthTxt.text = $"Health: {(int)_health}";
        healthSlider.value = _health;
    }

    public void GameOverUI()
    {
        while (NukePowerupCount > 0)
        {
            UseNukePickup();
        }
        gameOverPanel.SetActive(true);
    }

    public void AddNukePickup()//shows a new icon for the nuke power up collected next to the previous one
    {
        Image newIcon = Instantiate(nukePickupImg, gameActivePanel.transform);
        newIcon.rectTransform.anchoredPosition = pickupStackPos;
        pickupStackPos.x -= 32f;
        nukePickupCount++;
        nukePickups.Push(newIcon);
    }

    public void UseNukePickup()//deletes the last icon added
    {
        Image removedIcon = nukePickups.Pop();
        Destroy(removedIcon);
        pickupStackPos.x += 32f;
        nukePickupCount--;
    }

}
