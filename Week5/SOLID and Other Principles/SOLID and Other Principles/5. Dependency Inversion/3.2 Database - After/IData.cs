using System.Collections.Generic;

namespace DependencyInversionDatabaseAfter
{
    interface IData
    {
        IEnumerable<int> CourseIds();
        IEnumerable<string> CourseNames();


        IEnumerable<string> Search(string substring);


        string GetCourseById(int id);

    }
}
