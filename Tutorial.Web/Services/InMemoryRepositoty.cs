using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Web.Model;

namespace Tutorial.Web.Services
{
    public class InMemoryRepositoty : IRepository<Student>
    {
        public IEnumerable<Student> GetAll()
        {

            return new List<Student>
            { new Student
                {
                 Id = 1,
                FirstName = "Nick",
                LastName = "Carter",
                BirthDate=new DateTime(1980,1,4)
            },new Student
                {
            Id = 1,
                FirstName = "Nick",
                LastName = "Carter",
                  BirthDate=new DateTime(1974,6,14)
            },new Student
                {
            Id = 1,
                FirstName = "Nick",
                LastName = "Carter",
                  BirthDate=new DateTime(1978,12,5)
            }
            };
           
        }
    }
}
