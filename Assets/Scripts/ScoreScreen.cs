using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreScreen : MonoBehaviour
{
    public SharedData gameData;
    public GameObject title;
    public GameObject subTitle;

    public GameObject wealthIcon;
    public GameObject actionsIcon;
    public GameObject starsIcon;
    public GameObject scoreIcon;
    public GameObject wealthTextObj;
    public GameObject actionsTextObj;
    public GameObject starsTextObj;
    public GameObject scoreTextObj;
    public Text wealthText;
    public Text actionsText;
    public Text starsText;
    public Text scoreText;

    public GameObject EndLine;

    public GameObject footerTitle;
    public GameObject footerImage;

    public GameObject tryAgainButton;

    // Start is called before the first frame update
    void Start()
    {
        wealthText.text = gameData.wealth.ToString();
        actionsText.text = gameData.actions.ToString();
        starsText.text = gameData.stars.ToString();
        scoreText.text = gameData.score.ToString();

        StartCoroutine("TextAppearing");
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator TextAppearing() {
        title.SetActive(true);

        yield return new WaitForSeconds(1);
        subTitle.SetActive(true);

        yield return new WaitForSeconds(0.8f);
        wealthIcon.SetActive(true);
        wealthTextObj.SetActive(true);

        yield return new WaitForSeconds(0.8f);
        actionsIcon.SetActive(true);
        actionsTextObj.SetActive(true);

        yield return new WaitForSeconds(0.8f);
        starsIcon.SetActive(true);
        starsTextObj.SetActive(true);

        yield return new WaitForSeconds(0.8f);
        EndLine.SetActive(true);

        yield return new WaitForSeconds(1.4f);
        scoreIcon.SetActive(true);
        scoreTextObj.SetActive(true);

        yield return new WaitForSeconds(1);
        footerTitle.SetActive(true);

        yield return new WaitForSeconds(0.8f);
        footerImage.SetActive(true);

        yield return new WaitForSeconds(3);
        footerTitle.SetActive(false);
        footerImage.SetActive(false);
        tryAgainButton.SetActive(true);
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
