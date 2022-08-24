using DG.Tweening;
using UnityEngine;

namespace Assignment.Player
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        [SerializeField] private GameObject _stickObject;
        [SerializeField] private float _speed = 10;
        [SerializeField] private float _rotationSpeed = 5;

        public bool ControllerActive {get; set;}
        private Transform m_transform;
        private Rigidbody m_rb;
        private Vector3 m_velocity;
        private float _moveInput = 0;
        private float _rotaionInput = 0;


        // Start is called before the first frame update
        void Start()
        {
            m_transform = transform;
            m_rb = GetComponent<Rigidbody>();
            ControllerActive = false;
        }

        // Update is called once per frame
        void Update()
        {
            if(!ControllerActive)
            {
                return;
            }
            
            _moveInput = Input.GetAxis("Vertical");
            _rotaionInput = Input.GetAxis("Horizontal");

            if(Input.GetKeyUp(KeyCode.Space))
            {
                Debug.Log($"Space up");
                AnimateStickPush();
            }
        }

        private void AnimateStickPush()
        {
            _stickObject.transform.DOMoveZ(3,2).SetEase(Ease.InOutBounce);
        }

        private void FixedUpdate()
        {
            m_velocity = (m_transform.forward * _moveInput) * _speed * Time.fixedDeltaTime;
            m_velocity.y = m_rb.velocity.y;
            m_rb.velocity = m_velocity;
            m_transform.Rotate((m_transform.up * _rotaionInput) * _rotationSpeed * Time.fixedDeltaTime);
        }
    }
}