using UnityEngine;

namespace Assets.Scripts.Menu.Components
{
    public class BestScoreResultFieldAction : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private GameObject camera;
        #endregion
        #region Unity lifecycle
        private void Start()
        {
            gameObject.SetActive(false);
        }


        private void Update()
        {
            transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + 3, transform.position.z);
        }
        #endregion
    }
}

