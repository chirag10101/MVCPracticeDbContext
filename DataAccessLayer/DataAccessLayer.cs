using BusinessObjects.Models;

namespace DataAccessLayer
{
    public class DataAccessLayer
    {
        AppDbContext db = new AppDbContext();
        public List<Course> GetAllCourses()
        {
           return  db.Courses.ToList();
        }

        public Course GetCourse(int? id)
        {
            return db.Courses.FirstOrDefault(x=>x.CourseId == id);
        }

        public Course AddCourse(Course course)
        {

            db.Courses.Add(course);
            db.SaveChanges();
            return course;
        }

        public string EditCourse(Course course,int id)
        {
            var obj = GetCourse(id);

            if (obj != null)
            {
                foreach (Course c in db.Courses.ToList())
                {
                    if (c.CourseId == obj.CourseId)
                    {
                        c.Module = course.Module;
                        c.Description = course.Description;
                        c.Name = course.Name;
                        break;
                    }
                }
                db.SaveChanges();
                return "course edited";
            }
            else
            {
                return "No course found by this id";
            }
        }

        public string DeleteCourse(Course course,int id)
        {
            if(GetCourse(id) != null)
            {
                db.Courses.Remove(course);
                db.SaveChanges();
                return "Record Deleted";
            }
            else
            {
                return "No record with this id";
            }
        }

    }
}