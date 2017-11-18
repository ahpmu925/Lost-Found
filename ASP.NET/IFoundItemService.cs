using LostandFound.Models.Domain;
using LostandFound.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostandFound.Services.Interfaces
{
    public interface IFoundItemService
    {
        int Add(FoundItemAddRequest model, int id);
        List<FoundItem> GetAll();
      
    }
}
