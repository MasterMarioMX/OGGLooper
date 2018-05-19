using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loopTester
{
    /// <summary>
    /// a class to seek & find tag values NSide Audio files. Only for NAudio Library.
    /// </summary>
    static class tagSeeker
    {
        /// <summary>
        /// A tag counter for ogg files. don't wanna waste space so, it returns a byte number.
        /// </summary>
        /// <param name="tagCollection">the tags you want to count</param>
        /// <returns></returns>
        static public byte getNoOfOggTags(string[] tagCollection)
        {
            return (byte)tagCollection.Length;//what are the odds of somebody using a ogg file that has more than 255 diferent tags?
        }
        /// <summary>
        /// Search for a tag's value, if it finds the tag in the first place.
        /// </summary>
        /// <param name="tagCollection">the bunch'o tags where you'll search the tag for</param>
        /// <param name="target">the tag you want to know the value of.</param>
        /// <param name="isNumeric">is the tag value a number? input true if it does, to return "0" if the tag is not found. Ignore otherwise</param>
        /// <returns></returns>
        static public string getOggTagValue(string[] tagCollection, string target,bool isNumeric =false)
        {
            bool found = false;
            string result = "";
            string[] tagContents = new string[2];
            //this thing asumes that the tags inside the file are like this: "TAGNAME=TAGVALUE" hopefully, NAudio doesn't change that.
            for (int x = 0; x < tagCollection.Length; x++)
            {
                if (tagCollection[x].Contains(target))
                {
                    found = true;
                    tagContents = tagCollection[x].Split('=');
                    result = tagContents[1];
                    break;
                }
            }
            if (found) return result;            
            else { if (isNumeric) { return "0"; } else { return ""; } }
        }
    }    
}
