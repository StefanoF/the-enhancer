using UnityEngine;

namespace TheEnhancer {
    public class ActionEnabler : MonoBehaviour
    {
        public ActionData actionData;
        public GameData gameData;
        private MeshRenderer meshRenderer;

        void Awake() {
            meshRenderer = gameObject.GetComponent<MeshRenderer>();
        }

        void Start() {
            ChangeMaterial();
        }

        public void ChangeMaterial() {
            if (actionData.needInvestment) {
                if (gameData.investCounter < actionData.investAmountNeeded) {
                    actionData.isActive = false;
                    meshRenderer.material = actionData.passiveMaterial;
                    return;
                }
                actionData.isActive = true;
                meshRenderer.material = actionData.activeMaterial;
            }

            if (gameData.HasResources(actionData.costs)) {
                actionData.isActive = true;
                meshRenderer.material = actionData.activeMaterial;
            }
            else {
                actionData.isActive = false;
                meshRenderer.material = actionData.passiveMaterial;
            }
        }
    }
}