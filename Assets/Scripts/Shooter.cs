using System;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private WeaponInfo[] swords = null;

    public Action OnShoot;

    public int CurrentSword { get; private set; } = 0;

    private float roloadTimestamp;
    private bool nextSwordScheduled;
    private bool previousSwordScheduled;
    private bool shootScheduled;


    void Start()
    {
        roloadTimestamp = Time.time;
        foreach(WeaponInfo sword in swords)
        {
            sword.RefillAmmo();
        }
    }

    void Update()
    {
        if (nextSwordScheduled)
        {
            NextSword();
            nextSwordScheduled = false;
        }
        if(previousSwordScheduled)
        {
            PreviousSword();
            previousSwordScheduled = false;
        }
        if(roloadTimestamp < Time.time)
        {
            if (swords[CurrentSword].CanReload())
            {
                swords[CurrentSword].ReloadAmmo();
                ResetReloadTimer();
            }
        }
        if (shootScheduled)
        {
            Shoot();
            shootScheduled = false;
        }
        /*Debug.Log(CurrentSword + " " + 
                  swords[CurrentSword].Ammo + " / " + 
                  swords[CurrentSword].Capacity + " " + 
                  GetReloadTimeLeft() + " / " +
                  swords[CurrentSword].ReloadTime);*/
    }

    void NextSword()
    {
        if (swords.Length > 1)
        {
            CurrentSword += 1;
            CurrentSword %= swords.Length;
            ResetReloadTimer();
        }
    }
    void PreviousSword()
    {
        if (swords.Length > 1)
        {
            CurrentSword += swords.Length - 1;
            CurrentSword %= swords.Length;
            ResetReloadTimer();
        }
    }

    public void Shoot()
    {
        if (swords[CurrentSword].CanUseAmmo())
        {
            if (!swords[CurrentSword].CanReload())
            {
                ResetReloadTimer();
            }
            swords[CurrentSword].UseAmmo();
            Instantiate(swords[CurrentSword].Bullet, transform.position, transform.rotation);
            OnShoot?.Invoke();
        }
    }

    void ResetReloadTimer()
    {
        roloadTimestamp = Time.time + swords[CurrentSword].ReloadTime;
    }

    public float GetReloadTimeLeft()
    {
        if (!swords[CurrentSword].CanReload())
        {
            return 0;
        }
        return Mathf.Max(roloadTimestamp - Time.time, 0);
    }
    public void ScheduleNextSword()
    {
        nextSwordScheduled = true;
    }

    public void SchedulePreviousSword()
    {
        previousSwordScheduled = true;
    }

    public void ScheduleShoot()
    {
        shootScheduled = true;
    }

    public float GetCurrentWeaponReloadTime()
    {
        return swords[CurrentSword].ReloadTime;
    }

    public GameObject GetCurrentWeaponBullet()
    {
        return swords[CurrentSword].Bullet;
    }

    [System.Serializable]
    class WeaponInfo
    {
        [SerializeField]
        private GameObject bullet = null;

        [SerializeField]
        private int capacity = 1;

        private int ammo;

        [SerializeField]
        private float reloadTime = 1;

        public WeaponInfo(GameObject bullet, int capacity, float reloadTime)
        {
            this.bullet = bullet;
            this.capacity = capacity;
            this.reloadTime = reloadTime;
            this.ammo = capacity;
        }
        public GameObject Bullet
        {
            get { return bullet; }
            set { bullet = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public float ReloadTime
        {
            get { return reloadTime; }
            set { reloadTime = value; }
        }

        public int Ammo
        {
            get { return ammo; }
            private set { ammo = value; }
        }

        public void UseAmmo()
        {
            --ammo;
        }

        public void ReloadAmmo()
        {
            ++ammo;
        }

        public bool CanUseAmmo()
        {
            return ammo > 0;
        }

        public bool CanReload()
        {
            return ammo < capacity;
        }

        public void RefillAmmo()
        {
            ammo = capacity;
        }
    }
}

