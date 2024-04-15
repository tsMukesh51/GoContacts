using GoContacts.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoContacts.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Contact> Contacts { get; set; }
        DbSet<GroupTag> GroupTags { get; set; }
        DbSet<ContactGroupTag> ContactGroupTags { get; set; }
        DbSet<ApplicationUser> Users { get; set; }

        void Dispose();
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        //void Dispose();
    }
}
