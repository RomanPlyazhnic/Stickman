using Assets.Scripts.Instances;
using Assets.Scripts.Settings;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Actions
{
    public class StickAction : MonoBehaviour
    {
        #region Fields
        private const float STICK_JOINT_ANCHOR_X = 0.5f;
        private const float STICK_JOINT_ANCHOR_Y = -0.5f;


        private bool isSetstickJoint = false;
        private Rigidbody2D stickRigidBody;
        private HingeJoint2D stickJoint;
        #endregion
        #region Unity lifecycle
        private void Awake()
        {
            stickJoint = GetComponent<HingeJoint2D>();
            stickRigidBody = GetComponent<Rigidbody2D>();
        }


        private void Start()
        {
            OnEnable();
            stickJoint.enableCollision = true;
        }


        private void Update()
        {
            CreateStick();
        }


        private void OnEnable()
        {
            Storages.Sticks.OnRemove += ActionStick_OnRemove;
            Storages.Sticks.OnRemoveAll += ActionStick_OnRemoveAll;
        }
        #endregion
        #region Private methods
        private void CreateStick()
        {
            Stick lastStick = Storages.Sticks.Objects.FirstOrDefault(x => x.IsPassed == false);
            if (lastStick != null)
            {
                if (name == lastStick.Item.name)
                {
                    if (Storages.Sticks.IsAbleToIncrease && lastStick.IsMade == false)
                    {
                        if (Input.GetMouseButtonDown(0) && !Storages.Sticks.IsIncreasingStick)
                            Storages.Sticks.IsIncreasingStick = true;
                        if (Input.GetMouseButtonUp(0) && Storages.Sticks.IsIncreasingStick)
                        {
                            Storages.Sticks.IsIncreasingStick = false;
                            Storages.Sticks.IsAbleToIncrease = true;
                            lastStick.IsMade = true;
                        }
                    }
                    else
                    {
                        if (!isSetstickJoint)
                        {
                            isSetstickJoint = true;
                            stickRigidBody.simulated = true;
                            stickJoint.anchor = new Vector2(STICK_JOINT_ANCHOR_X, STICK_JOINT_ANCHOR_Y);
                        }
                    }
                    if (Storages.Sticks.IsIncreasingStick)
                    {
                        if (transform.localScale.y < StickSettings.MaxHeight)
                        {
                            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + (StickSettings.CreatingSpeed * 2 * Game.GameCoef), transform.localScale.z);
                            transform.position = new Vector3(transform.position.x, transform.position.y + (StickSettings.CreatingSpeed * Game.GameCoef), transform.position.z);
                        }
                    }
                }
            }
        }
        #endregion
        #region Event handlers
        private void ActionStick_OnRemove(GameObject stick)
        {
            DestroyImmediate(stick);
        }


        private void ActionStick_OnRemoveAll()
        {
            GameObject[] sticks = GameObject.FindGameObjectsWithTag("Stick");
            foreach (GameObject stick in sticks)
                Destroy(stick);
        }
        #endregion
    }
}

