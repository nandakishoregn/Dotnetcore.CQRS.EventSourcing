using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dotnetcore.CQRS.EventSourcing.Training
{
    public class DAPEvent
    {
        private const string filePath = "serialized.json";

        public DAPEvent()
        {
            Load();
        }

        public IList<DAPEventInfo> EventInfos { get; set; } = new List<DAPEventInfo>();
        /// <summary>
        /// to load the serialized data from file\db
        /// </summary>
        public void Load()
        {
            try
            {
                using (var stream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
                using (var sR = new StreamReader(stream))
                {
                    var oSerializedData = sR.ReadToEnd();
                    if (!String.IsNullOrEmpty(oSerializedData))
                    {
                        var serializeSettings = DAPSHelper.SerializerSettings;
                        var oDeSerializedEventInfo = JsonConvert.DeserializeObject<List<DAPEventInfo>>(oSerializedData, serializeSettings);
                        if (oDeSerializedEventInfo.Count > 0)
                        {
                            EventInfos = oDeSerializedEventInfo;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            //var oDeSerializedEventInfo = JsonConvert.DeserializeObject<List<DAPEventInfo>>(File.ReadAllText(filePath));
            //if (oDeSerializedEventInfo.Count > 0)
            //{
            //    EventInfos = oDeSerializedEventInfo;
            //}
        }
        /// <summary>
        /// To save the serialize the data 
        /// </summary>
        public void Save()
        {
            if (EventInfos.Count > 0)
            {
                Newtonsoft.Json.JsonSerializer serializer = DAPSHelper.Serializer;

                //var oSerializedEventInfo = JsonConvert.SerializeObject(EventInfos);
                if (EventInfos.Count > 0)
                {
                    using (var stream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
                    using (var sw = new StreamWriter(stream))
                    using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
                    {
                        serializer.Serialize(writer, EventInfos, typeof(List<DAPEventInfo>));
                    }
                }
            }
        }
        /// <summary>
        /// Undo the last transaction
        /// </summary>
        public void UndoLastTransaction()
        {
            var oLastRecord= EventInfos.LastOrDefault();
            if (oLastRecord != null)
            {
                EventInfos.Remove(oLastRecord);
                this.Save();
            }
        }
    }

    //public class DAPEventsList
    //{
    //    public int Id { get; set; }
    //    public DAPEventInfo EventInfo { get; set; }
    //}

    public class DAPEventInfo
    {
        public DAPEventInfo()
        {
            _createdOn = DateTime.Now;
        }

        [JsonIgnore]
        private DateTime _createdOn { get; set; }
        //private String _createdBy { get; set; }
        public DAPCommand Command { get; set; }

        public int Id { get; set; }
        public DateTime CreatedOn
        {
            get
            {
                return _createdOn;
            }
        }
        [JsonIgnore]
        private string _commandType { get; set; }
        public String CommandType
        {
            get { return Command != null ? Command.GetType().Name : String.Empty; }
        }

        public Object OldTarget { get; set; }
        public String CreatedBy { get; set; }
    }
}