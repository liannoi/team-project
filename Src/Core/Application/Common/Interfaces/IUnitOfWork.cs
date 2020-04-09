using System;

namespace TeamProject.Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}