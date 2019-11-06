using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMR.Tracking.DataAccess.Azure
{
    public class CloudDbContextFactory : IDesignTimeDbContextFactory<CloudDbContext>
    {
        public CloudDbContext CreateDbContext(string[] args)
        {
            return new CloudDbContext("Server=GPHAM-HOME;Database=TrackingDb;Trusted_Connection=True;");
        }
    }
}
