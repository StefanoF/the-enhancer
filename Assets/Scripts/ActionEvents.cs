using UnityEngine;

public class ActionEvents : MonoBehaviour {
    private static ActionEvents _instance;
    public static ActionEvents Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    public GameEvent oneActionAtTime;
    public GameEvent sameActionTwice;
    public GameEvent notEnoughResources;
    public GameEvent actionCanceled;
    public GameEvent clickOnBottomPlane;
    public GameEvent investComplete;
    public GameEvent investStarted;
    public GameEvent productionComplete;
    public GameEvent productionStarted;
    public GameEvent useAllBenefits;
    public GameEvent needToInvest;
    public GameEvent needCorrectInvest;
    public GameEvent changeLastAction;
    public GameEvent allBenefitPlaced;
    public GameEvent allBenefitNotPlaced;
}