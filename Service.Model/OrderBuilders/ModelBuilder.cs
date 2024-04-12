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
        private Model _model = new Model();

        public ModelBuilder(string modelName)
        {
            _model.Name = modelName;
        }

        public Model Build()
        {
            return _model;
        }
    }
}