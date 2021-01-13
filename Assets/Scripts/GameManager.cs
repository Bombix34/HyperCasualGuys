using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    private CameraManager cameraManager;

    private bool isGameOver = false;

    [SerializeField]
    private GameObject endGamePrefab;
    [SerializeField]
    private RectTransform endGameUI;

    private void Start()
    {
        Time.timeScale = 1f;
        cameraManager = Camera.main.GetComponent<CameraManager>();
        endGameUI.DOAnchorPosY(endGameUI.rect.height, 0f).SetEase(Ease.Linear);
        endGameUI.gameObject.SetActive(false);
    }

    public void GameOver(GameObject mummyTriggered)
    {
        if (isGameOver)
            return;
        isGameOver = true;
        cameraManager.FollowTarget(mummyTriggered.transform, true);
        Time.timeScale = 0.6f;
        StartCoroutine(GameOverPanelTransition());
    }

    private IEnumerator GameOverPanelTransition()
    {
        yield return new WaitForSeconds(1.75f);
        Time.timeScale = 1f;
        endGameUI.gameObject.SetActive(true);
        endGameUI.DOAnchorPosY(0, 0.6f).SetEase(Ease.OutBounce);
        endGamePrefab.SetActive(true);
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndLevel()
    {

    }
}
