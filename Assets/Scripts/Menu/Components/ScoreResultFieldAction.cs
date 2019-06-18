using UnityEngine;

namespace Assets.Scripts.Menu.Components
{
    public class ScoreResultFieldAction : MonoBehaviour
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
            transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + 2, transform.position.z);
        }
        #endregion
    }
}
