using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField]
    [Range(0, 100)]
    private int penetration = 0;

    [SerializeField]
    private int cut = 0;

    [SerializeField]
    private int blunt = 0;

    [SerializeField]
    private int fire = 0;

    [SerializeField]
    private int ice = 0;

    [SerializeField]
    private int lightning = 0;

    public int Penetration
    {
        get { return penetration; }
        private set { penetration = value; }
    }
    public int Cut
    {
        get { return cut; }
        private set { cut = value; }
    }
    public int Blunt
    {
        get { return blunt; }
        private set { blunt = value; }
    }
    public int Fire
    {
        get { return fire; }
        private set { fire = value; }
    }
    public int Ice
    {
        get { return ice; }
        private set { ice = value; }
    }
    public int Lightning
    {
        get { return lightning; }
        private set { lightning = value; }
    }
}
