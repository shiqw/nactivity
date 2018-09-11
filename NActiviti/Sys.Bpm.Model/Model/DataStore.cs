﻿namespace org.activiti.bpmn.model
{
    public class DataStore : BaseElement
    {

        protected internal string name;
        protected internal string dataState;
        protected internal string itemSubjectRef;

        public virtual string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }


        public virtual string DataState
        {
            get
            {
                return dataState;
            }
            set
            {
                this.dataState = value;
            }
        }


        public virtual string ItemSubjectRef
        {
            get
            {
                return itemSubjectRef;
            }
            set
            {
                this.itemSubjectRef = value;
            }
        }


        public override BaseElement clone()
        {
            DataStore clone = new DataStore();
            clone.Values = this;
            return clone;
        }

        public override BaseElement Values
        {
            set
            {
                base.Values = value;
                var val = value as DataStore;

                Name = val.Name;
                DataState = val.DataState;
                ItemSubjectRef = val.ItemSubjectRef;
            }
        }

    }

}