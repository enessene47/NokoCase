using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.Video;

public abstract class CustomManager : MonoBehaviour
{
    private Transform _transform;

    public Transform Transform
    {
        get
        {
            if (_transform == null)
                _transform = transform;

            return _transform;
        }
    }

    private VideoPlayer _videoPlayer;

    public VideoPlayer VideoPlayer
    {
        get
        {
            if (_videoPlayer == null)
                _videoPlayer = GetComponent<VideoPlayer>();

            return _videoPlayer;
        }
    }

    private Light _light;

    public Light Light
    {
        get
        {
            if (_light == null)
            {
                _light = GetComponent<Light>();

                if (_light == null)
                {
                    foreach (Transform child in transform)
                        if (child.GetComponent<Light>())
                        {
                            _light = child.GetComponent<Light>();

                            break;
                        }
                }
            }

            return _light;
        }
    }

    private TrailRenderer _trailRenderer;

    public TrailRenderer TrailRenderer
    {
        get
        {
            if (_trailRenderer == null)
            {
                _trailRenderer = GetComponent<TrailRenderer>();

                if (_trailRenderer == null)
                {
                    foreach (Transform child in transform)
                        if (child.GetComponent<TrailRenderer>())
                        {
                            _trailRenderer = child.GetComponent<TrailRenderer>();

                            break;
                        }
                }
            }

            return _trailRenderer;
        }
    }
    private LineRenderer _lineRenderer;

    public LineRenderer LineRenderer
    {
        get
        {
            if (_lineRenderer == null)
            {
                _lineRenderer = GetComponent<LineRenderer>();

                if (_lineRenderer == null)
                {
                    foreach (Transform child in transform)
                        if (child.GetComponent<LineRenderer>())
                        {
                            _lineRenderer = child.GetComponent<LineRenderer>();

                            break;
                        }
                }
            }

            return _lineRenderer;
        }
    }

    private Animator _animator;

    public Animator Animator
    {
        get
        {
            if (_animator == null)
            {
                _animator = GetComponent<Animator>();

                if(_animator == null)
                {
                    foreach(Transform child in transform)
                        if(child.GetComponent<Animator>())
                        {
                            _animator = child.GetComponent<Animator>();

                            break;
                        }
                }
            }

            return _animator;
        }
    }

    private Rigidbody _physics;

    public Rigidbody Rigidbody
    {
        get
        {
            if (_physics == null)
                _physics = GetComponent<Rigidbody>();

            return _physics;
        }
    }

    private Rigidbody2D _physics2D;

    public Rigidbody2D Rigidbody2D
    {
        get
        {
            if (_physics2D == null)
                _physics2D = GetComponent<Rigidbody2D>();

            return _physics2D;
        }
    }

    private Collider _coll;

    public Collider Collider
    {
        get
        {
            if (_coll == null)
                _coll = GetComponent<Collider>();

            return _coll;
        }
    }

    private Collider2D _coll2D;

    public Collider2D Collider2D
    {
        get
        {
            if (_coll2D == null)
                _coll2D = GetComponent<Collider2D>();

            return _coll2D;
        }
    }

    private BoxCollider _boxCollider;

    public BoxCollider BoxCollider
    {
        get
        {
            if (_boxCollider == null)
                _boxCollider = GetComponent<BoxCollider>();

            return _boxCollider;
        }
    }


    private BoxCollider2D _boxCollider2D;

    public BoxCollider2D BoxCollider2D
    {
        get
        {
            if (_boxCollider2D == null)
                _boxCollider2D = GetComponent<BoxCollider2D>();

            return _boxCollider2D;
        }
    }

    private SphereCollider _sphereCollider;

    public SphereCollider SphereCollider
    {
        get
        {
            if (_sphereCollider == null)
                _sphereCollider = GetComponent<SphereCollider>();

            return _sphereCollider;
        }
    }

    private CapsuleCollider _capsuleCollider;

    public CapsuleCollider CapsuleCollider
    {
        get
        {
            if (_capsuleCollider == null)
                _capsuleCollider = GetComponent<CapsuleCollider>();

            return _capsuleCollider;
        }
    }

    private MeshCollider _meshCollider;

    public MeshCollider MeshCollider
    {
        get
        {
            if (_meshCollider == null)
                _meshCollider = GetComponent<MeshCollider>();

            return _meshCollider;
        }
    }

    private Renderer _rend;

    public Renderer Renderer
    {
        get
        {
            if (_rend == null)
                _rend = GetComponent<Renderer>();

            return _rend;
        }
    }

    private MeshRenderer _meshRenderer;

    public MeshRenderer MeshRenderer
    {
        get
        {
            if (_meshRenderer == null)
                _meshRenderer = GetComponent<MeshRenderer>();

            return _meshRenderer;
        }
    }

    private SpriteRenderer _spriteRenderer;

    public SpriteRenderer SpriteRenderer
    {
        get
        {
            if (_spriteRenderer == null)
                _spriteRenderer = GetComponent<SpriteRenderer>();

            return _spriteRenderer;
        }
    }

    private SkinnedMeshRenderer _skinnedMeshRenderer;

    public SkinnedMeshRenderer SkinnedMeshRenderer
    {
        get
        {
            if (_skinnedMeshRenderer == null)
                _skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();

            return _skinnedMeshRenderer;
        }
    }

    private MeshFilter _meshFilter;

    public MeshFilter MeshFilter
    {
        get
        {
            if (_meshFilter == null)
                _meshFilter = GetComponent<MeshFilter>();

            return _meshFilter;
        }
    }

    private Camera _camera;

    public Camera Camera
    {
        get
        {
            if (_camera == null)
                _camera = GetComponent<Camera>();

            return _camera;
        }
    }

    private AudioSource _audioSource;

    public AudioSource AudioSource
    {
        get
        {
            if (_audioSource == null)
                _audioSource = GetComponent<AudioSource>();

            return _audioSource;
        }
    }

    private Image _image;

    public Image Image
    {
        get
        {
            if (_image == null)
                _image = GetComponent<Image>();

            return _image;
        }
    }

    private Button _button;

    public Button Button
    {
        get
        {
            if (_button == null)
                _button = GetComponent<Button>();

            return _button;
        }
    }

    private NavMeshAgent _navMeshAgent;

    public NavMeshAgent NavMeshAgent
    {
        get
        {
            if (_navMeshAgent == null)
                _navMeshAgent = GetComponent<NavMeshAgent>();

            return _navMeshAgent;
        }
    }

    private NavMeshObstacle _navMeshObstacle;

    public NavMeshObstacle NavMeshObstacle
    {
        get
        {
            if (_navMeshObstacle == null)
                _navMeshObstacle = GetComponent<NavMeshObstacle>();

            return _navMeshObstacle;
        }
    }
}
