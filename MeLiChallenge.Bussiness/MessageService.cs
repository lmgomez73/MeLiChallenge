using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MeLiChallenge.Model;

namespace MeLiChallenge.Business
{
    public class MessageService
    {
        public string DecodeMessage(Message messages)
        {
            string result = "";
            var words = GetMessageWords(messages);
            result = GetOrderedMessage(messages, words);
            return result;
        }


        private List<string> GetMessageWords(Message messages)
        {
            List<String> result;
            result = messages.MessageItems.SelectMany(x => x.Phrases).Distinct().ToList();
            result.RemoveAll(x => x.Equals(""));
            return result;
        }

        private string GetOrderedMessage(Message message, List<string> words)
        {
            Dictionary<string, List<int>> dic = new Dictionary<string, List<int>>();
            string[] resultArray = new string[words.Count()];
            words.ForEach(x => dic.Add(x, new List<int>()));
            foreach (var word in words)
            {
                foreach (var sentence in message.MessageItems)
                {
                    if (sentence.Phrases.Contains(word))
                    {
                        dic[word].Add(Array.IndexOf(sentence.Phrases, word));
                    }
                }
            }
            foreach (var item in dic)
            {
                int index = item.Value.GroupBy(i => i).OrderByDescending(grp => grp.Count())
      .Select(grp => grp.Key).First();
                //if the index of the array is null or empty then there isn't another possible value yet
                if (string.IsNullOrEmpty(resultArray[index]))
                {
                    resultArray[index] = item.Key;
                }
                else
                {
                    string currentWord = resultArray[index];
                    string newWord = item.Key;

                    //if both words have only one possible index, we can't resolve the right index for them
                    if (dic[newWord].Distinct().Count() == 1 && dic[currentWord].Distinct().Count() == 1)
                    {
                        throw new Exception("Unable to decode the message");
                    }
                    //if both of them has as many distinct possible positions as message received, we can't resolve the right index for them
                    if (dic[newWord].Distinct().Count() == message.MessageItems.Count()
                        && dic[currentWord].Distinct().Count() == message.MessageItems.Count())
                    {
                        throw new Exception("Unable to decode the message");
                    }
                    //TODO fix to work with more than 3 satellites

                    //if the new word has more than a possibility, then use one of them
                    if (dic[newWord].Count > 1)
                    {
                        var indexesList = dic[newWord].Where(x => x != index & string.IsNullOrEmpty(resultArray[x]));
                        //if indexeslist = 0 then there is not an empty place to put the value
                        if (indexesList.Count() == 0)
                        {
                            throw new Exception("Unable to decode the message");
                        }
                        resultArray[indexesList.First()] = newWord;
                    }
                    else
                    {
                        var indexesList = dic[currentWord].Where(x => x != index & string.IsNullOrEmpty(resultArray[x]));
                        //if indexeslist = 0 then there is not an empty place to put the value
                        if (indexesList.Count() == 0)
                        {
                            throw new Exception("Unable to decode the message");
                        }
                        resultArray[indexesList.First()] = currentWord;
                        resultArray[index] = newWord;
                    }
                }
            }
            //if there is an empty value, the message couldn't order correctly
            if (resultArray.Any(x => string.IsNullOrEmpty(x)))
            {
                throw new Exception("Unable to decode the message");
            }

            return string.Join(' ', resultArray);
        }


    }
}
