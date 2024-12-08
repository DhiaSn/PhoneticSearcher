using System.Runtime.Serialization;

namespace PhoneticSearcher.Core.Matching.StringPhoneticKey.Base
{
    [Serializable]
    [DataContract]
    [KnownType(typeof(EditexKey))]
    [KnownType(typeof(Phonix))]
    [KnownType(typeof(SoundEx))]
    [KnownType(typeof(SimpleTextKey))]
    [KnownType(typeof(Metaphone))]
    [KnownType(typeof(DoubleMetaphone))]
    [KnownType(typeof(DaitchMokotoff))]
    public abstract class StringPhoneticKeyBuilder : IStringPhoneticKeyBuilder
    {
        // ***********************Fields***********************

        private int maxLength = 4;

        // ***********************Properties***********************

        [DataMember]
        public int MaxLength
        {
            get { return maxLength; }
            set { maxLength = value; }
        }

        public string Name
        {
            get { return GetType().Name; }
        }

        // ***********************Functions***********************

        public abstract string BuildKey(string str1);
    }
}