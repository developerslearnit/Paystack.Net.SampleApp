using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PaystackSampleWebApp.Models
{
    public class BaseRepository<C> : IDisposable
       where C : DbContext, new()
    {
        private C _DataContext;

        public virtual C DataContext
        {
            get
            {
                if (_DataContext == null)
                {
                    _DataContext = new C();
                    this.AllowSerialization = true;

                }
                return _DataContext;
            }
        }

        public virtual bool AllowSerialization
        {
            get
            {
                return _DataContext.Configuration.ProxyCreationEnabled;
            }
            set
            {
                _DataContext.Configuration.ProxyCreationEnabled = !value;
            }
        }

        public void Dispose()
        {
            if (DataContext != null) DataContext.Dispose();
        }
    }
}