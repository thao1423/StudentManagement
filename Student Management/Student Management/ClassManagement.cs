using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management
{
    class ClassManagement
    { 
        public Class[] GetClasses() 
        {
            var db = new OOPCSEntities();
            var classes = db.Class.ToArray();

            return classes;
        } 
        public void Addclass(string name, string description) 
        {
            var newClass = new Class();
            newClass.Name = name;
            newClass.Description = description;

            var db = new OOPCSEntities();
            db.Class.Add(newClass);
            db.SaveChanges();
        } 
        public void Editclass(int id,string name, string description) 
        {
            var db = new OOPCSEntities();
            var oldClass= db.Class.Find(id);

            oldClass.Name = name;
            oldClass.Description = description;

            db.Entry(oldClass).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        } 
        public void DeleteClass(int id)
        {
            var db = new OOPCSEntities();
            var @class = db.Class.Find(id);
            db.Class.Remove(@class);
            db.SaveChanges();
        } 
        public Class GetClass(int id)
        {
            var db = new OOPCSEntities();
            var @class = db.Class.Find(id);
            return @class;
        }
            
    }
}
