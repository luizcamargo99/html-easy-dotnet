using HTMLEasyDotnet.Models;
using System;

namespace HTMLEasyDotnet.Actions
{
    public static class Document
    {
        private const int _invalidNumber = -1;
        private const char _minusSign = '<';
        private const string _doubleQuotes = "\"";
        private const string _classText = "class=\"";

        public static string Load(this string url)
        {
            try
            {
                return new HTTPService(url).GetAsyncHtml().Result;
            }
            catch
            {
                return null;
            }
        }
        public static HTMLElement GetElementById(this string document, string id)
        {
            HTMLElement element = new HTMLElement { Id = id };

            int index = document.IndexOf($"id=\"{id}\"");

            if (index == _invalidNumber)
            {
                return element;
            }
            
            int startIndexElement = GetStartElement(document, index);
            int endIndexElement = document.IndexOf(_minusSign, index);
            element.InnerHTML = document.Substring(startIndexElement, endIndexElement - startIndexElement);
            element.NodeName = GetNodeName(element.InnerHTML);

            int startIndexClass = document.IndexOf(_classText, startIndexElement);
            int endIndexClass = document.IndexOf(_doubleQuotes, startIndexClass + _classText.Length);
            element.ClassName = document.Substring(startIndexClass + _classText.Length, endIndexClass - (startIndexClass + _classText.Length));
            element.ClassList = element.ClassName.Split();

            return element;
        }

        private static int GetStartElement(string document, int index)
        {
            int startIndexElement = 0;

            for (int i = index; startIndexElement == 0; i--)
            {
                char letter = document[i];

                if (letter == _minusSign)
                {
                    startIndexElement = i;
                }
            }

            return startIndexElement;
        }

        private static string GetNodeName(string text)
        {
            string name = string.Empty;

            foreach (char letter in text)
            {
                if (string.IsNullOrWhiteSpace(letter.ToString()))
                {
                    break;
                }

                if (letter != _minusSign)
                {
                    name += letter;
                }
            }

            return name;
        }
    }
}
