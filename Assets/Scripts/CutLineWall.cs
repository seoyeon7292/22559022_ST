using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutLineWall : MonoBehaviour
{
public void OnTriggerEnter(Collider other)
{
//collier GameObject를 파괴
Destroy(other.gameObject);
}
}
