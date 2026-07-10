using System;

namespace RaseTheSun.Scripts.Services.WaitingService
{
    public interface IWaitingService
    {
        void Wait(float delay, Action callback);
    }
}