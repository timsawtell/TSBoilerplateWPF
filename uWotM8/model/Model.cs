using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uWotM8.model
{
    public sealed class Model
    {
        private static volatile Model _instance;
        private static object syncRoot = new Object();

        public List<Object> people; // list of people to live on the model

        public Model() {
            this.people = new List<Object>();
        }

        public static Model Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                            _instance = Model.savedModel();
                    }
                }

                return _instance;
            }
        }

        private static Model savedModel()
        {
            Model model = new Model();
            try
            {
                Type[] extraTypes = { typeof(Person) };
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Model), extraTypes);
                System.IO.StreamReader file = new System.IO.StreamReader(@"model.xml");
                model = (Model)writer.Deserialize(file);
                file.Close();
            }
            catch (Exception)
            {
                //DILLIGAF?
            }
            return model;
        }

        public void save()
        {
            try
            {
                Type[] extraTypes = { typeof(Person) };
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Model), extraTypes);
                System.IO.StreamWriter file = new System.IO.StreamWriter(@"model.xml");
                writer.Serialize(file, this);
                file.Close();
            }
            catch (Exception)
            {
                // DILLIGAF?
            }
        }
    }
}
