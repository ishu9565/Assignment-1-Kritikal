using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Models;
namespace StudentappDB.DBoperations
{
   public class StudentRepository
    {
        public int AddStudent(StudentDataModel model)
        {
            using (var context =new StudentDBEntities())
            {
                StudentData stu = new StudentData()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    RollNumber = model.RollNumber,
                    
                };

                if(model.HostelData!=null)
                {
                    stu.HostelData = new HostelData()
                    {
                        HostelName = model.HostelData.HostelName,
                        Block = model.HostelData.Block,
                        RoomNumber = model.HostelData.RoomNumber
                    };
                }
                context.StudentData.Add(stu);
                context.SaveChanges();

                return stu.ID;
            }
        }

       public List<StudentDataModel> GetAllStudents()
        {
            using (var context = new StudentDBEntities())
            {

                var result = context.StudentData
                    .Select(x=>new StudentDataModel()
                    {
                        ID =x.ID,
                        HostelID =x==null?0 : x.HostelID,
                        FirstName= x.FirstName,
                        LastName= x.LastName,
                        Email=x.Email,
                        RollNumber=x.RollNumber,
                        HostelData = new HostelDataModel()
                        {
                            ID = x == null ? 0 : x.HostelData.ID,
                            HostelName = x == null ? "" : x.HostelData.HostelName,
                            Block = x == null ? "" : x.HostelData.Block,
                            RoomNumber = x == null ? 0 : x.HostelData.RoomNumber
                        }
                      
                    }).ToList();
                
                return result;
            }
        }

       public StudentDataModel GetStudent(int id)
       {
           using (var context = new StudentDBEntities())
           {

               var result = context.StudentData
                   .Where(x=>x.ID==id)
                   .Select(x => new StudentDataModel()
                   {
                       ID = x.ID,
                       HostelID = x == null ? 0 : x.HostelID,
                       FirstName = x.FirstName,
                       LastName = x.LastName,
                       Email = x.Email,
                       RollNumber = x.RollNumber,
                       HostelData = new HostelDataModel()
                       {
                             ID = x.HostelData.ID,
                           HostelName =  x.HostelData.HostelName,
                           Block =  x.HostelData.Block,
                            RoomNumber = x.HostelData.RoomNumber
                       }

                   }).FirstOrDefault();

               return result;
           }
       }

       public bool UpdateStudent(int id, StudentDataModel model)
       {
           using (var context = new StudentDBEntities())
           {
               var StudentData = context.StudentData.FirstOrDefault(x => x.ID == id);
               if (StudentData != null)
               {
                   StudentData.FirstName = model.FirstName;
                   StudentData.LastName = model.LastName;
                   StudentData.Email = model.Email;
                   StudentData.RollNumber = model.RollNumber;
               }
               context.SaveChanges();
               return true;

           }
       }

       public bool DeleteStudent(int id)
       {
           using (var context = new StudentDBEntities())
           {
               var student = context.StudentData.FirstOrDefault(x => x.ID == id);
               if(student !=null)
               {
                   context.StudentData.Remove(student);
                   context.SaveChanges();
                   return true;
               }
               return false;
           }
       }
    }
}
