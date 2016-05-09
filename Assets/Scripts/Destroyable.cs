using UnityEngine;
using System.Collections;

public abstract class  Destroyable :MonoBehaviour{
    public Animation animDestroy;
    public int life;
    protected virtual void Destruct()
    {
        if (animDestroy)
            animDestroy.Play();

        Destroy(this.gameObject);
    }
    public virtual void GetDamage(int dmg)
    {
    }
}
