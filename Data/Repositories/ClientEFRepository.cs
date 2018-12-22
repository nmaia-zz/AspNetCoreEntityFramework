using Data.Repositories.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class ClientEFRepository : EFRepositoryBase<Client>, IClientEFRepository
    {
    }
}
