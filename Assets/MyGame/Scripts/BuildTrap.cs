using UnityEngine;

public class BuildTrap : MonoBehaviour
{
    [System.Serializable]
    public class BuildTarget
    {
        public GameObject TrapPreview;
        public GameObject Trap;
    }

    [SerializeField] BuildTarget[] m_buildTargets;

    public void ActiveTrapPreviewByIndex(int index)
    {
        if (index < 0 || index >= m_buildTargets.Length)
            return;

        foreach(var b in m_buildTargets)
        {
            b.TrapPreview.SetActive(false);
        }

        GameObject obj = m_buildTargets[index].TrapPreview;
        if (obj != null)
        {
            obj.SetActive(true);
        }
    }
}
