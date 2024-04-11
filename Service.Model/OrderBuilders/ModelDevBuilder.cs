using Serwis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Model.OrderBuilder
{
    public class ModelDevBuilder
    {
        private ModelDevice _model = new ModelDevice();

        public ModelDevBuilder(string modelName)
        {
            _model.Name = modelName;
        }

        public ModelDevice Build()
        {
            return _model;
        }
    }
}