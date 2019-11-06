using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMR.Tracking.DataAccess
{
    public class LocalDbContext: DbContext, IDisposable
    {
    }
}
