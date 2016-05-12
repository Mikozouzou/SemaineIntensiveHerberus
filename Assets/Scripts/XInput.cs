using UnityEngine;
using System.Collections;
using XInputDotNetPure; // Required in C#

public class XInput : MonoBehaviour
{
    public static XInput instance = null;
    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    bool[] buttondown;
    int[] vibePlayer;
    void Awake()
    {
       
        instance = this;
        buttondown = new bool[2];
        buttondown[0] = false;
        buttondown[1] = false;

        vibePlayer = new int[2];
        vibePlayer[0] = 0;
        vibePlayer[1] = 0;
    }
    

    public void useVibe(int id, float time, float force1, float force2)
    {
        id--;
        vibePlayer[id]++;
        StartCoroutine(vibration((PlayerIndex)(id), time,  force1,  force2));
    }

    IEnumerator vibration(PlayerIndex id, float time, float force1, float force2)
    {
        GamePad.SetVibration(id, force1, force2);
        yield return new WaitForSeconds(time);
        vibePlayer[(int)id]--;
        if (vibePlayer[(int)id] == 0)
            GamePad.SetVibration(id, 0, 0);
    }

    public float getTriggerRight(int id)
    {
        return GamePad.GetState((PlayerIndex)(id - 1)).Triggers.Right;
    }

    public float getTriggerLeft(int id)
    {
        return GamePad.GetState((PlayerIndex)(id - 1)).Triggers.Left;
    }

    public ButtonState getButton(int id, char bt)
    {
        id--;
        
        switch (bt)
        {
            case 'A':
                return GamePad.GetState((PlayerIndex)id).Buttons.A;
            case 'B':
                return GamePad.GetState((PlayerIndex)id).Buttons.B;
                
            case 'X':
                return GamePad.GetState((PlayerIndex)id ).Buttons.X;
                
            case 'Y':
                return GamePad.GetState((PlayerIndex)id ).Buttons.Y;
                
            default:
                Debug.Log("ERROR X INPUT");
                return ButtonState.Released;
        }
        
    }

    public ButtonState getDPad(int id, char bt)
    {
        id--;

        switch (bt)
        {
            case 'U':
                return GamePad.GetState((PlayerIndex)id).DPad.Up;
            case 'D':
                return GamePad.GetState((PlayerIndex)id).DPad.Down;

            case 'L':
                return GamePad.GetState((PlayerIndex)id).DPad.Left;

            case 'R':
                return GamePad.GetState((PlayerIndex)id).DPad.Right;

            default:
                Debug.Log("ERROR X INPUT");
                return ButtonState.Released;
        }

    }
    public float getLeftXStick(int id = 0)
    {
        return GamePad.GetState((PlayerIndex)(id - 1)).ThumbSticks.Left.X;
    }

    public float getLeftYStick(int id=0)
    {
        return GamePad.GetState((PlayerIndex)(id - 1)).ThumbSticks.Left.Y;
    }

    public float getRightXStick(int id = 0)
    {
        return GamePad.GetState((PlayerIndex)(id - 1)).ThumbSticks.Right.X;
    }

    public float getRightYStick(int id = 0)
    {
        return GamePad.GetState((PlayerIndex)(id - 1)).ThumbSticks.Right.Y;
    }

    

    void OnDestroy()
    {
        GamePad.SetVibration((PlayerIndex)0, 0, 0);
        GamePad.SetVibration((PlayerIndex)1, 0, 0);
    }
}
