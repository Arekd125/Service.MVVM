using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Models.OrderBuilder
{
    public class ModelBuilder
    {
        private ModelList _model = new ModelList();

        public ModelBuilder(string modelName)
        {
            _model.Name = modelName;
        }

        public ModelList Build()
        {
            return _model;
        }
    }
}