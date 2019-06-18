using Assets.Scripts.Instances;
using UnityEngine;

namespace Assets.Scripts.Actions
{
    public class BonusAction : MonoBehaviour
    {
        #region Unity lifecycle
        private void Start()
        {
            OnEnable();
        }


        private void OnTriggerEnter2D(Collider2D bonusCollider2D)
        {
            if (bonusCollider2D.gameObject.tag == "Player")
            {
                Game.AddBonusScore();
                Destroy(gameObject);
            }
        }


        private void OnEnable()
        {
            Storages.Bonuses.OnRemove += Bonus_OnRemove;
            Storages.Bonuses.OnRemoveAll += Bonus_OnRemoveAll;
        }
        #endregion
        #region Event handlers
        private void Bonus_OnRemove(GameObject bonus)
        {
            DestroyImmediate(bonus);
        }


        private void Bonus_OnRemoveAll()
        {
            GameObject[] bonuses = GameObject.FindGameObjectsWithTag("Bonus");
            foreach (GameObject bonus in bonuses)
                Destroy(bonus);
        }
        #endregion
    }
}


