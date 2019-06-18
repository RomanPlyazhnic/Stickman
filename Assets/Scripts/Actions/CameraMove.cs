using UnityEngine;
using System.Linq;
using Assets.Scripts.Settings;
using Assets.Scripts.Instances;

namespace Assets.Scripts.Actions
{
    public class CameraMove : MonoBehaviour
    {
        #region Fields
        private const float CAMERA_POS_Z = -20;


        [SerializeField]
        private GameObject player;
        [SerializeField]
        private GameObject block;
        [SerializeField]
        private GameObject bonus;


        private Rigidbody2D playerRigidBody;
        private Camera cameraView;
        private float increasingTimeFlag = 0.0f;
        #endregion
        #region Unity lifecycle
        private void Awake()
        {
            cameraView = gameObject.GetComponent<Camera>();
            playerRigidBody = player.GetComponent<Rigidbody2D>();
        }


        private void Start()
        {
            OnEnable();
            InitFirstBlocks();
        }


        private void Update()
        {
            MoveCamera();
            if (Storages.Blocks.Objects.Count(x => x.IsPassed) >= BlockSettings.MaxPassedCount)
            {
                AddMissingBlock();
            }
            if (!Game.IsInMainMenu)
            {
                ZoomCamera();
            }
        }


        private void OnEnable()
        {
            Game.OnResetGame += Camera_OnResetGame;
            Storages.Blocks.OnRemove += Block_OnRemove;
            Storages.Blocks.OnRemoveAll += Block_OnRemoveAll;
        }
        #endregion
        #region Private methods
        private void MoveCamera()
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, CAMERA_POS_Z);
        }


        private void AddMissingBlock()
        {
            Storages.Blocks.Remove(Storages.Blocks.Objects.FirstOrDefault(x => x.IsPassed));
            InitBlockRandom();
        }


        private void ZoomCamera()
        {
            cameraView.orthographicSize = Mathf.Lerp(CameraSettings.MainMenuDistance, CameraSettings.GameDistance, increasingTimeFlag);
            increasingTimeFlag += CameraSettings.IncreaseSpeed * Time.deltaTime;
        }


        private void InitFirstBlocks()
        {
            block.transform.localScale = new Vector3(BlockSettings.FirstBlockWidth, block.transform.localScale.y, block.transform.localScale.z);
            Storages.Blocks.Add(Instantiate(block, new Vector2(BlockSettings.FirstBlockXPos, BlockSettings.YPos), Quaternion.identity));
            for (int i = 0; i < BlockSettings.MaxCount - 1; i++)
                InitBlockRandom();
        }


        private void InitBlockRandom()
        {
            GameObject lastBlock = Storages.Blocks.Objects.Last().Item;
            float lastBlockRightPos = lastBlock.transform.localScale.x / 2 + lastBlock.transform.position.x;
            float blockWidth = Random.Range(BlockSettings.MinWidth, BlockSettings.MaxWidth);
            float minCreateDistance = lastBlockRightPos + BlockSettings.MinDistance + blockWidth / 2;
            float maxCreateDistance = lastBlockRightPos + BlockSettings.MaxDistance + blockWidth / 2;
            float blockXPos = Random.Range(minCreateDistance, maxCreateDistance);
            float bonusYPos = BlockSettings.YPos + block.transform.localScale.y / 2 + BonusSettings.Size / 2;
            block.transform.localScale = new Vector3(blockWidth, block.transform.localScale.y, block.transform.localScale.z);
            Storages.Blocks.Add(Instantiate(block, new Vector2(blockXPos, BlockSettings.YPos), Quaternion.identity));
            CreateBonus(blockXPos, bonusYPos);
        }


        private void CreateBonus(float bonusXPos, float bonusYPos)
        {
            Storages.Bonuses.Add(Instantiate(bonus, new Vector2(bonusXPos, bonusYPos), Quaternion.identity));
        }
        #endregion
        #region Event handlers
        private void Camera_OnResetGame()
        {
            Storages.Sticks.RemoveAll();
            Storages.Blocks.RemoveAll();
            Storages.Bonuses.RemoveAll();
            Game.InitGame();
            InitFirstBlocks();
        }


        private void Block_OnRemove(GameObject block)
        {
            DestroyImmediate(block);
        }


        private void Block_OnRemoveAll()
        {
            GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
            foreach (GameObject block in blocks)
                Destroy(block);
        }
        #endregion
    }
}

