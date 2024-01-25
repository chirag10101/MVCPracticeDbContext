using BusinessAccessLayer;
using BusinessObjects.Models;
namespace BusinessAccessLayer
{
    public class BusinessAccesslayer
    {
        DataAccessLayer.DataAccessLayer dal = new DataAccessLayer.DataAccessLayer();
        public List<Course> GetAllCourses()
        {
            return  dal.GetAllCourses();
        }

        public Course GetCourse(int? id)
        {
            return dal.GetCourse(id);
        }

        public void AddCourse(Course course)
        {
            dal.AddCourse(course);
        }

        public string EditCourse(Course course,int id) { 
            return dal.EditCourse(course,id);
        }

        public string DeleteCourse(Course course,int id) { 
            return dal.DeleteCourse(course,id);
        }
    }
}
