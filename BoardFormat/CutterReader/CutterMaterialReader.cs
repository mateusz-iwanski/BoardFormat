using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TonCut;

namespace BoardFormat.CutterReader
{
    public class CutterMaterialReader
    {
        ICutterReader _reader;

        public CutterMaterialReader(ICutterReader reader)
        {
            _reader = reader;
        }

        public Material GetMaterial(int materialId) =>
            _reader.dataInput.materials.Cast<Material>().ToList().First(p => p.id == materialId)
            ;
        
    }
}
