using UnityEngine;

public interface IPipe
{
    bool IsDead {  get; }
    void Init(Bird bird);
    void SetPos(float x, float y);
    void Move();
    void Release();
    void RealRelease(GameObject prefab);
}
