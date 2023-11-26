using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AreaApplicationSkill : MonoBehaviour
{
    public bool hasTast = false;

    public Image image;

    [SerializeField] private float radius;
    public float Radius
    {
        get { return radius; }
        private set { radius = value; }
    }

    private void Awake()
    {
        image = GetComponentInChildren<Image>(true);
        image.enabled = false;
    }
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y, 0), radius);
    }
#endif
}
