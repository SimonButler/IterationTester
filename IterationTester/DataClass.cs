using System;
using System.Collections.Generic;
using System.Text;

namespace IterationTester
{
    public class DataClass
    {
        public int id;
        public string name;
        public string lastname;
        public long dateOfBirth;
        public Guid guid;

        public DataClass(int id, string name, string lastname, long dateOfBirth, Guid guid)
        {
            this.id = id;
            this.name = name;
            this.lastname = lastname;
            this.dateOfBirth = dateOfBirth;
            this.guid = guid;
        }
    }
}
