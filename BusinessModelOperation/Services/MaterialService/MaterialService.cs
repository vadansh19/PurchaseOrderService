using BusinessModelOperation;
using BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModelOperation
{
    public class MaterialService: IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        public MaterialService(IMaterialRepository _materialRepository)
        {
            this._materialRepository = _materialRepository;
        }

        public int AddMaterial(MaterialDetails materialDetails)
        {
            return _materialRepository.AddMaterial(materialDetails);
        }

        public List<MaterialDetails> GetMaterialList()
        {
            return _materialRepository.GetMaterialList();
        }

        public int DeleteMaterial(int materialID)
        {
            return _materialRepository.DeleteMaterial(materialID);
        }
    }
}
