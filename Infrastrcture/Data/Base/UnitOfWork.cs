using Domain.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Base
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        internal AgeRangerDbContext _context { get; set; }

        public UnitOfWork(AgeRangerDbContext context)
        {
            this._context = context;
        }

        public void Commit()
        {
            this._context.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
