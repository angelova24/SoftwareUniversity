using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> decorations;
        public DecorationRepository()
        {
            this.decorations = new List<IDecoration>();
        }
        public IReadOnlyCollection<IDecoration> Models => this.decorations.AsReadOnly();

        public void Add(IDecoration model)
        {
            decorations.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            var decoration = decorations.FirstOrDefault(x => x.GetType().Name == type);

            return decoration;
        }

        public bool Remove(IDecoration model)
        {
            return this.decorations.Remove(model);
        }
    }
}
