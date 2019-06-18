using Assets.Scripts.Instances;
using UnityEngine;

namespace Assets.Scripts.Menu.Components
{
    public class RestartButtonAction : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private GameObject camera;
        [SerializeField]
        private AudioClip clickSound;


        private AudioSource audioSource;
        #endregion
        #region Unity lifecycle
        private void Awake()
        {
            GameObject obj = GameObject.Find("Main Camera");
            audioSource = obj.GetComponent<AudioSource>();
        }


        private void Start()
        {
            gameObject.SetActive(false);
        }


        private void Update()
        {
            transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, transform.position.z);
        }


        void OnMouseDown()
        {
            audioSource.PlayOneShot(clickSound);
            Game.DropRestartMenu();
            Game.RestartGame();
        }
        #endregion
    }
}

