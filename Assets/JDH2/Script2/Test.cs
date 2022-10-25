using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    //public GameManager gameManager;

    public Animator animator;

    [Header("Commons")]
    [Tooltip("dhqmwprxmdp tkdydehlsms ahems fpsejfj zjavhsjsxm")]
    public MeshRenderer[] renderers;
    [Tooltip("ahwk dhqmwprxm")]
    public GameObject hat;
    [Tooltip("qkftk wlwja")]
    public Transform firePoint;

    [System.Serializable]
    public struct Stats
    {
        public int health;
        public float healthRegen;

        [Space(10f)]
        public int attackPoint;
        public float attackSpeed;
        public float attackDelay;

        [Space(10f)]
        public float MoveSpeed;
        public float rotSpeed;

        [Space(10f)]
        public float jumpAmount;
        public bool isjumpAmount;
    }
    [Header("Player Stats")]
    public Stats stats;

    [Header("Infomation")]
    public new string name;
    [Multiline(3)]
    public string desc;
    [TextArea(3,5)]
    public string desc2;


    [Header("Resize Datas")]
    [Range (0.5f,1.5f)]
    public float resizeAmoint;
    public Vector3 minsize;
    public Vector3 maxsize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
