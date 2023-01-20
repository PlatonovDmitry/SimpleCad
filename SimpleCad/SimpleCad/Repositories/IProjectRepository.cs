using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCad.Models;

namespace SimpleCad.Repositories
{
    internal interface IProjectRepository
    {
        ProjectGeometry[] GetAllGeometry();

        void AddGeometry(ProjectGeometry geometry);
    }
}
