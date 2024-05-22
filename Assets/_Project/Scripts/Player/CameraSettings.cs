    using UnityEngine;
    using UnityEngine.Serialization;

    [CreateAssetMenu(fileName ="New Camera Settings", menuName ="Portage/Settings/Camera")]
    public class CameraSettings : ScriptableObject
    {

        [SerializeField] private float _xSensitivity = 15;
        [SerializeField] private float _ySensitivity = 15;
        [SerializeField] private bool _invertY = false;
        [SerializeField] private float _lookThreshold = 0.01f;
        [FormerlySerializedAs("_clampValue")] [SerializeField] private Vector2 _verticalClamp;

        /// <summary>
        /// How sensitive the camera looks in the X (horizontal) axis
        /// </summary>
        public float XSensitivity => _xSensitivity;
        /// <summary>
        /// How sensitive the camera looks in the Y (vertical) axis
        /// </summary>
        public float YSensitivity => _ySensitivity;
        
        /// <summary>
        /// Threshold for axis movement before rotating camera
        /// </summary>
        public float LookThreshold => _lookThreshold;
        
        /// <summary>
        /// Angle to clamp vertical rotation
        /// </summary>
        public Vector2 VerticalClamp => _verticalClamp;
        /// <summary>
        /// Invert vertical input?
        /// </summary>
        public bool InvertY => _invertY;

    }

