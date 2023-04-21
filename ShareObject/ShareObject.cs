using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels.Http;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ShareObject
{
    
    public class ShareObject: MarshalByRefObject
    {
        public static void InitRemoteService()
        {
            try
            {
                HttpChannel CHANEL = new HttpChannel(7000); //http通道
                ChannelServices.RegisterChannel(CHANEL, false);
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(ShareObject), "Persons", WellKnownObjectMode.Singleton);
            }
            catch { }
        }

        public static ShareObject GetRemoteObject(string ServerIP)
        {
            try
            {
                HttpChannel CHANLE = new HttpChannel();
                ChannelServices.RegisterChannel(CHANLE, false);
                var ps = (ShareObject)Activator.GetObject(typeof(ShareObject), $"http://{ServerIP}:7000/Persons");//创建类的实例

                return ps;
            }
            catch { 
                return  null; }
        }

        public static ObservableCollection<Person> Persons = new ObservableCollection<Person>();

        public void AddPersons()
        {
            Persons.Add(new Person() {Name="Mary", Sex="Female", Age=18});
            Persons.Add(new Person() { Name = "Henry", Sex = "Male", Age = 22 });
            Persons.Add(new Person() { Name = "Julie", Sex = "Female", Age = 19 });
            Persons.Add(new Person() { Name = "Gloria", Sex = "Female", Age = 18 });
            Persons.Add(new Person() { Name = "Annie", Sex = "Female", Age = 15 });
            Persons.Add(new Person() { Name = "Jason", Sex = "Male", Age = 17 });
            Persons.Add(new Person() { Name = "Leo", Sex = "Male", Age = 23 });
            Persons.Add(new Person() { Name = "Dana", Sex = "Male", Age = 20 });
        }

        public void ClearPersons()
        {
            Persons.Clear();
        }

        public ArrayList GetPersonList()
        {
            ArrayList persons = new ArrayList();
            foreach (Person person in Persons)
            {
                persons.Add(person);
            }
            return persons;
        }
    }

    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
    }
}
