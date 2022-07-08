
using UniRx;

public class PauseModel
{
    public ReactiveProperty<bool> pause;

    public PauseModel()
    {
        pause = new ReactiveProperty<bool>();
        pause.Value = false;
    }

    public bool IsPause => pause.Value == true;

    public void SetPause(bool newValue)
    {
        pause.Value = newValue;
    }
}
