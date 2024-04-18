using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Models.OrderBuilder
{
    public class ModelStateBuilder
    {
        private ModelState _model = new ModelState();

        public ModelStateBuilder(string modelName)
        {
            _model.Name = modelName;
        }

        public ModelState Build()
        {
            return _model;
        }
    }
}