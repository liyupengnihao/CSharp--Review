using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;//序列化命名空间
using System.Text;
using System.Threading.Tasks;

namespace _07
{
    internal class 模拟序列化和反序列化:Person
    {
        //  序列化：将对象转换为二进制
        //  反序列化：将二进制转换为对象
        //  用于传输数据（只有二进制能传输）

        /// <summary>
        /// 序列化写入文本
        /// </summary>
        /// <param name="person">Person类</param>
        /// <param name="name">人名</param>
        /// <param name="age">人年纪</param>
        /// <param name="gender">人性别</param>
        /// <param name="path">文件路径</param>
        public static void SerialPersonMessage(Person person,string name,int age,Gender gender,string path)//序列化
        {
            person.Name=name;
            person.Age=age;
            person.GenderMaleOrFemale=gender;
            using(FileStream fsw=new FileStream(path,FileMode.OpenOrCreate,FileAccess.Write))
            {
                BinaryFormatter bf=new BinaryFormatter();
                bf.Serialize(fsw,person);
            }
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="person">Person类</param>
        /// <param name="path">路径</param>
        /// <returns>Person类</returns>
        public static Person DeserialPersonMessage(string path)
        {
            Person person;
            using (FileStream fsr=new FileStream(path,FileMode.OpenOrCreate,FileAccess.Read))
            {
                BinaryFormatter bf=new BinaryFormatter();
                person=(Person)bf.Deserialize(fsr);
            }
            return person;
        }
    }
    [Serializable]//表示可序列化
    public class Person
    {
        private string _name;
        private int _age;
        private Gender _gender;
        public enum Gender
        {
            Male, Female
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public Gender GenderMaleOrFemale
        {
            get { return _gender; }
            set
            {
                if (value==Gender.Male)
                    _gender = Gender.Male;
                else
                    _gender = Gender.Female;
            }
        }
    }
}
