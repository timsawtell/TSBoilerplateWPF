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
        public List<Object> people;

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
                            _instance = new Model();
                    }
                }

                return _instance;
            }
        }

    }
}
