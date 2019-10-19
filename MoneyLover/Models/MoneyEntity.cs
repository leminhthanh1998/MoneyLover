using MoneyLover.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyLover.Models
{
    public class MoneyEntity : DbContext
    {
        public MoneyEntity()
            : base()
        {
        }


        public DbSet<User> users { get; set; }
        public DbSet<BRANCH> BRANCHes { get; set; }
        public DbSet<TLPROFILE> TLPROFILEs { get; set; }
        public DbSet<CALENDAR> CALENDARs { get; set; }
        public DbSet<CFIMAGE> CFIMAGEs { get; set; }
        public DbSet<CFMAST> CFMASTs { get; set; }
        public DbSet<CIINTTRAN> CIINTTRANs { get; set; }
        public DbSet<CITRAN> cITRANs { get; set; }
        public DbSet<CIMAST> CIMASTs { get; set; }
        public DbSet<CIPRODUCT> CIPRODUCTs { get; set; }
        public DbSet<DEPARTMENTE> DEPARTMENTEs { get; set; }
        public DbSet<TLLOGS> TLLOGs { get; set; }
        public DbSet<AllCode> AllCodes { get; set; }
        public DbSet<GUITHEM>gUITHEMs { get; set; }
    }
}
