using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public GameObject tryAgainButton;
    public GameObject returnToMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        wealthText.text = gameData.wealth.ToString();
        actionsText.text = gameData.actions.ToString();
        starsText.text = gameData.stars.ToString();
        scoreText.text = gameData.score.ToString();

        StartCoroutine("TextAppearing");
    }

    IEnumerator TextAppearing() {
        title.SetActive(true);

        yield return new WaitForSeconds(1);
        subTitle.SetActive(true);

        yield return new WaitForSeconds(0.8f);
        wealthIcon.SetActive(true);
        wealthTextObj.SetActive(true);

        yield return new WaitForSeconds(0.8f);
        starsIcon.SetActive(true);
        starsTextObj.SetActive(true);

        yield return new WaitForSeconds(0.8f);
        actionsIcon.SetActive(true);
        actionsTextObj.SetActive(true);

        yield return new WaitForSeconds(0.8f);
        EndLine.SetActive(true);

        yield return new WaitForSeconds(1.4f);
        scoreIcon.SetActive(true);
        scoreTextObj.SetActive(true);

        yield return new WaitForSeconds(2);
        tryAgainButton.SetActive(true);
        returnToMenuButton.SetActive(true);
    }
}
