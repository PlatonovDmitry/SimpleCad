using SimpleCad.Models;
using SimpleCad.UI;
using SimpleCad.UI.Project;

namespace SimpleCad.Helpers.Extensions
{
    internal static class ProjectExtension
    {
        public static ProjectVm Load(this Project project)
        {
            var output = new ProjectVm();

            foreach (var curGeometry in project.Geometry)
            {
                output.Geometry.Add(curGeometry.GetGeometryVm());
            }

            return output;
        }

        public static Project Save(this ProjectVm vm)
        {
            var output = new Project();
            foreach (var curGeometry in vm.Geometry)
            {
                output.Geometry.Add(curGeometry.SaveGeometry());
            }

            return output;
        }
    }
}
