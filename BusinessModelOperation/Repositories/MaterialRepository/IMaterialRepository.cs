using BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModelOperation
{
    public interface IMaterialRepository
    {
        int AddMaterial(MaterialDetails materialDetails);
        List<MaterialDetails> GetMaterialList();
        int DeleteMaterial(int materialID);
    }
}
