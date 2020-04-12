using System;

namespace TeamProject.Application.Common.Interfaces.Storage
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}