public interface IHealthHandler
{
    void AddHealth(float value);
    void SetHealth(float value);
    void SubtractHealth(float value);
    float GetHealth();

    void Kill();
}
